using System;
using SSE554Project1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class TestExcelReader
    {
        [TestMethod]
        public void ExcelReaderCanReadColumns()
        {
            ExcelReader excelReader = new ExcelReader(@"C:\Users\Tyson\documents\visual studio 2017\Projects\SSE554Project1\UnitTests\TestFile.xlsx");

            List<String> expectedList = new List<String>(new string[] { "Testing", "1", "2", "3" });

            List<String> actualList = excelReader.ReadColumn(2);
            
            excelReader.Close();

            Assert.IsTrue(expectedList.SequenceEqual(actualList));
        }
    }
}