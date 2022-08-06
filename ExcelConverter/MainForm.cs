using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExcelConverter
{
    public partial class MainForm : Form
    {
        private List<Dictionary<Control, Control>> controlsList = new List<Dictionary<Control, Control>>();
        private Control rControl;
        private int controlsIdx = 0;
        private int controlsStartLocationY;

        public MainForm()
        {
            InitializeComponent();

            Log("프로그램 시작");
            LogConsole(String.Format("프로그램 시작\n"));

            this.AllowDrop = true;
            this.DragEnter += MainFormDragEnter;
            this.DragDrop += MainFormDragDrop;

            rControl = excelFileTextBox;
            controlsStartLocationY = rControl.Location.Y;

            CreateControls();
        }

        private void MainFormDragEnter(object sender, DragEventArgs e) 
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void MainFormDragDrop(object sender, DragEventArgs e) 
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            RemoveAllControls();
            for (int i = 0; i < 10 && i < files.Length; i++)
            {
                CreateControls();
                controlsList[i][excelFileTextBox].Text = files[i];
            }
        }

        private void findExcelFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                controlsList[ToControlLineIdx((int)(sender as Control).Tag)][excelFileTextBox].Text = openFileDialog.FileName;
        }

        private void removeLineButton_Click(object sender, EventArgs e)
        {
            RemoveControls(ToControlLineIdx((int)(sender as Control).Tag));
        }

        private void addLineButton_Click(object sender, EventArgs e)
        {
            if (controlsList.Count < 10) CreateControls();
        }

        private void convertStartButton_Click(object sender, EventArgs e)
        {
            StartConvert();
        }

        private void StartConvert()
        {
            Log("변환 중...");
            ExcelReader excelReader = new ExcelReader();

            for (int i = 0; i < controlsList.Count; i++)
            {
                var controls = controlsList[i];

                if (controls[excelFileTextBox].Text == string.Empty)
                {
                    LogConsole(string.Format("{0} : 변환실패, 항목이 비어있음", i));
                    continue;
                }

                string excelFileName = controls[excelFileTextBox].Text;
                string simpleExcelFileName = excelFileName.Substring(excelFileName.LastIndexOf('\\') + 1);
                simpleExcelFileName = simpleExcelFileName.Substring(0, simpleExcelFileName.LastIndexOf('.'));
                var data = excelReader.ConvertToList(excelFileName);

                string jsonFileName = controls[jsonFileTextBox].Text;
                if (jsonFileName == string.Empty)
                {
                    jsonFileName = simpleExcelFileName + ".json";
                }

                string fullClassName = controls[classNameTextBox].Text;
                if (fullClassName == string.Empty)
                {
                    fullClassName = simpleExcelFileName;
                }

                string namespaceName = null;
                string className = fullClassName;
                int dotIdx = fullClassName.LastIndexOf('.');
                if (dotIdx != -1)
                {
                    namespaceName = fullClassName.Substring(0, dotIdx);
                    className = fullClassName.Substring(dotIdx + 1);
                }

                JsonConverter.ToJsonFile(".\\" + jsonFileName, data);
                LogConsole(string.Format("{0} : json 파일 생성\t: {1}", i, jsonFileName));

                CodeConverter codeConverter = new CodeConverter(namespaceName, ".\\" + className + ".cs");
                codeConverter.ToCsCodeFile(data);
                LogConsole(string.Format("{0} : cs 코드 파일 생성\t: {1}", i, className + ".cs"));
            }

            Log("변환완료");
            LogConsole(String.Format("모든 작업 종료\n"));
        }

        private void CreateControls()
        {
            Dictionary<Control, Control> controls = new Dictionary<Control, Control>()
            {
                { excelFileTextBox, CopyControl(excelFileTextBox, new TextBox(), controlsIdx) },
                { findExcelFileButton, CopyControl(findExcelFileButton, new Button(), controlsIdx) },
                { jsonFileTextBox, CopyControl(jsonFileTextBox, new TextBox(), controlsIdx) },
                { classNameTextBox, CopyControl(classNameTextBox, new TextBox(), controlsIdx) },
                { removeLineButton, CopyControl(removeLineButton, new Button(), controlsIdx) }
            };
            (controls[excelFileTextBox] as TextBox).ReadOnly = true;
            controls[findExcelFileButton].Click += new EventHandler(findExcelFileButton_Click);
            controls[removeLineButton].Click += new EventHandler(removeLineButton_Click);
            controlsIdx++;

            controlsList.Add(controls);
            Controls.AddRange(controls.Values.ToArray());

            UpdateControlsLocation();
        }

        private void RemoveControls(int listIdx)
        {
            Dictionary<Control, Control> controls = controlsList[listIdx];
            foreach (Control control in controls.Values)
                Controls.Remove(control);
            controlsList.RemoveAt(listIdx);

            UpdateControlsLocation();
        }

        private void RemoveAllControls()
        {
            foreach (var controls in controlsList)
                foreach (Control control in controls.Values)
                    Controls.Remove(control);
            controlsList.Clear();
        }

        private Control CopyControl(Control sourceControl, Control destControl, int idx)
        {
            destControl.BackColor = sourceControl.BackColor;
            destControl.Font = sourceControl.Font;
            destControl.Location = sourceControl.Location;
            destControl.Name = sourceControl.Name + idx;
            destControl.Size = sourceControl.Size;
            destControl.TabIndex = sourceControl.TabIndex;
            destControl.Text = sourceControl.Text;
            destControl.Tag = idx;

            return destControl;
        }

        private void UpdateControlsLocation()
        {
            foreach (var controls in controlsList)
                foreach (Control control in controls.Values)
                    control.Location = new Point(control.Location.X, controlsStartLocationY+ToControlLineIdx((int)control.Tag) *30);
        }

        private int ToControlLineIdx(int controlTag)
        {
            for (int i = 0; i < controlsList.Count; i++)
                if ((int)controlsList[i][rControl].Tag == controlTag) return i;
            return -1;
        }

        private void Log(string text)
        {
            this.LogTextBox.Text = text;
        }

        private void LogConsole(string text)
        {
            Console.WriteLine(text);
        }
    }
}
