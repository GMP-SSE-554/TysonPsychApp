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
    }
}
