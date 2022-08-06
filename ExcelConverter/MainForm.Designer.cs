namespace ExcelConverter
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.excelFileTextBox = new System.Windows.Forms.TextBox();
            this.findExcelFileButton = new System.Windows.Forms.Button();
            this.jsonFileTextBox = new System.Windows.Forms.TextBox();
            this.classNameTextBox = new System.Windows.Forms.TextBox();
            this.removeLineButton = new System.Windows.Forms.Button();
            this.addLineButton = new System.Windows.Forms.Button();
            this.convertStartButton = new System.Windows.Forms.Button();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.ExcelFileLabel = new System.Windows.Forms.Label();
            this.JsonFileLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // excelFileTextBox
            // 
            this.excelFileTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.excelFileTextBox.Font = new System.Drawing.Font("굴림", 11F);
            this.excelFileTextBox.Location = new System.Drawing.Point(12, 35);
            this.excelFileTextBox.Name = "excelFileTextBox";
            this.excelFileTextBox.ReadOnly = true;
            this.excelFileTextBox.Size = new System.Drawing.Size(270, 24);
            this.excelFileTextBox.TabIndex = 2;
            // 
            // findExcelFileButton
            // 
            this.findExcelFileButton.BackColor = System.Drawing.SystemColors.Control;
            this.findExcelFileButton.Font = new System.Drawing.Font("굴림", 11F);
            this.findExcelFileButton.Location = new System.Drawing.Point(288, 35);
            this.findExcelFileButton.Name = "findExcelFileButton";
            this.findExcelFileButton.Size = new System.Drawing.Size(75, 23);
            this.findExcelFileButton.TabIndex = 0;
            this.findExcelFileButton.Text = "찾기";
            this.findExcelFileButton.UseVisualStyleBackColor = false;
            this.findExcelFileButton.Click += new System.EventHandler(this.findExcelFileButton_Click);
            // 
            // jsonFileTextBox
            // 
            this.jsonFileTextBox.Font = new System.Drawing.Font("굴림", 11F);
            this.jsonFileTextBox.Location = new System.Drawing.Point(461, 35);
            this.jsonFileTextBox.Name = "jsonFileTextBox";
            this.jsonFileTextBox.Size = new System.Drawing.Size(120, 24);
            this.jsonFileTextBox.TabIndex = 2;
            // 
            // classNameTextBox
            // 
            this.classNameTextBox.Font = new System.Drawing.Font("굴림", 11F);
            this.classNameTextBox.Location = new System.Drawing.Point(587, 35);
            this.classNameTextBox.Name = "classNameTextBox";
            this.classNameTextBox.Size = new System.Drawing.Size(120, 24);
            this.classNameTextBox.TabIndex = 2;
            // 
            // removeLineButton
            // 
            this.removeLineButton.BackColor = System.Drawing.SystemColors.Control;
            this.removeLineButton.Font = new System.Drawing.Font("굴림", 11F);
            this.removeLineButton.Location = new System.Drawing.Point(713, 35);
            this.removeLineButton.Name = "removeLineButton";
            this.removeLineButton.Size = new System.Drawing.Size(75, 23);
            this.removeLineButton.TabIndex = 0;
            this.removeLineButton.Text = "제거";
            this.removeLineButton.UseVisualStyleBackColor = false;
            this.removeLineButton.Click += new System.EventHandler(this.removeLineButton_Click);
            // 
            // addLineButton
            // 
            this.addLineButton.BackColor = System.Drawing.SystemColors.Control;
            this.addLineButton.Font = new System.Drawing.Font("굴림", 18F);
            this.addLineButton.Location = new System.Drawing.Point(632, 368);
            this.addLineButton.Name = "addLineButton";
            this.addLineButton.Size = new System.Drawing.Size(75, 70);
            this.addLineButton.TabIndex = 0;
            this.addLineButton.Text = "추가";
            this.addLineButton.UseVisualStyleBackColor = false;
            this.addLineButton.Click += new System.EventHandler(this.addLineButton_Click);
            // 
            // convertStartButton
            // 
            this.convertStartButton.BackColor = System.Drawing.SystemColors.Control;
            this.convertStartButton.Font = new System.Drawing.Font("굴림", 18F);
            this.convertStartButton.Location = new System.Drawing.Point(713, 368);
            this.convertStartButton.Name = "convertStartButton";
            this.convertStartButton.Size = new System.Drawing.Size(75, 70);
            this.convertStartButton.TabIndex = 0;
            this.convertStartButton.Text = "변환";
            this.convertStartButton.UseVisualStyleBackColor = false;
            this.convertStartButton.Click += new System.EventHandler(this.convertStartButton_Click);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Font = new System.Drawing.Font("굴림", 18F);
            this.LogTextBox.Location = new System.Drawing.Point(12, 388);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(558, 35);
            this.LogTextBox.TabIndex = 1;
            // 
            // ExcelFileLabel
            // 
            this.ExcelFileLabel.AutoSize = true;
            this.ExcelFileLabel.Font = new System.Drawing.Font("굴림", 9F);
            this.ExcelFileLabel.Location = new System.Drawing.Point(12, 9);
            this.ExcelFileLabel.Name = "ExcelFileLabel";
            this.ExcelFileLabel.Size = new System.Drawing.Size(61, 12);
            this.ExcelFileLabel.TabIndex = 3;
            this.ExcelFileLabel.Text = "Excel File";
            // 
            // JsonFileLabel
            // 
            this.JsonFileLabel.AutoSize = true;
            this.JsonFileLabel.Font = new System.Drawing.Font("굴림", 9F);
            this.JsonFileLabel.Location = new System.Drawing.Point(459, 9);
            this.JsonFileLabel.Name = "JsonFileLabel";
            this.JsonFileLabel.Size = new System.Drawing.Size(98, 12);
            this.JsonFileLabel.TabIndex = 4;
            this.JsonFileLabel.Text = "Json File (.json)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F);
            this.label1.Location = new System.Drawing.Point(588, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Namespace.Class";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.JsonFileLabel);
            this.Controls.Add(this.ExcelFileLabel);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.addLineButton);
            this.Controls.Add(this.convertStartButton);
            this.Name = "MainForm";
            this.Text = "Excel Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox excelFileTextBox;
        private System.Windows.Forms.Button findExcelFileButton;
        private System.Windows.Forms.TextBox jsonFileTextBox;
        private System.Windows.Forms.TextBox classNameTextBox;
        private System.Windows.Forms.Button removeLineButton;
        private System.Windows.Forms.Button addLineButton;
        private System.Windows.Forms.Button convertStartButton;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Label ExcelFileLabel;
        private System.Windows.Forms.Label JsonFileLabel;
        private System.Windows.Forms.Label label1;
    }
}
