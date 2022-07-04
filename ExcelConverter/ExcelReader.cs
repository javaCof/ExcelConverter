using System;
using System.IO;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelConverter
{
    public class ExcelReader
    {
        private Excel.Application application;

        public ExcelReader()
        {
            application = new Excel.Application();
            application.Visible = false;
        }

        public List<List<string>> ConvertToList(string path, int sheetNum = 1)
        {
            List<List<string>> excelData = new List<List<string>>();
            Excel.Workbook workbook = application.Workbooks.Open(path);
            if (workbook == null) throw new FileNotFoundException();
            if (sheetNum > workbook.Worksheets.Count) throw new ArgumentOutOfRangeException();

            Excel.Worksheet sheet = workbook.Worksheets[sheetNum];
            Excel.Range range = sheet.UsedRange;
            for (int row = 1; row <= range.Rows.Count; row++)
            {
                excelData.Add(new List<string>());
                for (int column = 1; column <= range.Columns.Count; column++)
                    excelData[row - 1].Add((range.Cells.Value2[row, column] ?? "").ToString());
            }
            workbook.Close();

            return excelData;
        }

        ~ExcelReader()
        {
            application.Quit();
        }
    }
}
