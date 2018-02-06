using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace SSE554Project1
{
    public class ExcelReader
    {
        private Excel.Application app;
        private Excel.Workbook workbook;
        private Excel._Worksheet worksheet;
        private Excel.Range range;

        /// <summary>
        /// Reads in the first sheet of the Excel file at excelSheetAddress
        /// </summary>
        /// <param name="excelSheetAddress"></param>
        public ExcelReader(string excelSheetAddress)
        {
            app = new Excel.Application();
            workbook = app.Workbooks.Open(excelSheetAddress);
            worksheet = workbook.Sheets[1];
            range = worksheet.UsedRange;
        }

        public List<String> ReadColumn(int columnNumber)
        {
            List<String> columnStrings = new List<String>();

            for (int row = 2; row <= range.Rows.Count; row++)
            {
                if (range.Cells[row, columnNumber] != null && range.Cells[row, columnNumber].Value2 != null)
                {
                    columnStrings.Add(range.Cells[row, columnNumber].Value2.ToString());
                }
            }
            return columnStrings;
        }

        public void Close()
        {
            workbook.Close();
        }

        public void WriteSlidesToFile(List<Slide> slideList)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook OutputWorkbook = xlApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet OutputSheet = OutputWorkbook.Sheets[1];

            OutputSheet.Cells[1, 1].Value = "Answers";
            OutputSheet.Cells[1, 2].Value = "Typing Until Typing Began";
            OutputSheet.Cells[1, 3].Value = "Time Spent Typing";
            for (int i = 0; i < slideList.Count; i++)
            {
                OutputSheet.Cells[2 + i, 1].Value = slideList[i].GetAnswer();
                OutputSheet.Cells[2 + i, 2].Value = slideList[i].TimeUntilTypingBegan;
                OutputSheet.Cells[2 + i, 2].Value = slideList[i].TimeSpentTyping;
            }

            OutputWorkbook.SaveAs(@"C:\Users\Tyson\Desktop\TestOutput.xlsx");
            OutputWorkbook.Close();
        }
    }
}
