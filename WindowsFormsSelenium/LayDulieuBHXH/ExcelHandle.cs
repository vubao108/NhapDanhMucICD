using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace LayDulieuBHXH
{
    class ExcelHandle
    {
        private Excel.Worksheet xlWorkSheet;
        private Excel.Workbook xlWorkBook;
        private Excel.Application xlApp;
        object misValue = System.Reflection.Missing.Value;
        public void open(string workbookPath, int sheetNum)
        {

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlApp.Visible = true;


            //Excel.Workbook xlWorkBook;
           
           

             xlWorkBook = xlApp.Workbooks.Open(workbookPath, 0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheetNum);
        }
        public  void write(int rowNum, Dictionary<string,string> data)
        { 


            xlWorkSheet.Cells[rowNum, 1] = data["stt"];
            xlWorkSheet.Cells[rowNum, 2] = data["ma"];
            xlWorkSheet.Cells[rowNum, 3] = data["ten"];
            xlWorkSheet.Cells[rowNum, 4] = data["sttpd"];
            xlWorkSheet.Cells[rowNum, 5] = data["hoatchat"];
            xlWorkSheet.Cells[rowNum, 6] = data["maduongdung"];
            xlWorkSheet.Cells[rowNum, 7] = data["duongdung"];
            xlWorkSheet.Cells[rowNum, 8] = data["hamluong"];
            xlWorkSheet.Cells[rowNum, 9] = data["sodk"];
            xlWorkSheet.Cells[rowNum, 10] = data["nhasx"];
            xlWorkSheet.Cells[rowNum, 11] = data["nuocsx"];
            xlWorkSheet.Cells[rowNum, 12] = data["quycach"];
            xlWorkSheet.Cells[rowNum, 13] = data["dvt"];
            xlWorkSheet.Cells[rowNum, 14] = data["soluong"];
            xlWorkSheet.Cells[rowNum, 15] = data["dongia"];
            xlWorkSheet.Cells[rowNum, 16] = data["thanhtien"];
            xlWorkSheet.Cells[rowNum, 17] = data["tennhathau"];
            xlWorkSheet.Cells[rowNum, 18] = data["quyetdinh"];
            xlWorkSheet.Cells[rowNum, 19] = data["ngayHL"];
            xlWorkSheet.Cells[rowNum, 20] = data["ngayHH"];
            xlWorkSheet.Cells[rowNum, 21] = data["goithau"];
            xlWorkSheet.Cells[rowNum, 22] = data["loaithuoc"];
            xlWorkSheet.Cells[rowNum, 23] = data["nhomthau"];
            xlWorkSheet.Cells[rowNum, 24] = data["nam"];
            xlWorkSheet.Cells[rowNum, 25] = data["trangthai"];
            xlWorkSheet.Cells[rowNum, 26] = data["mieuta"];


            /*
        xlWorkSheet.Cells[1, 1] = "ID";
        xlWorkSheet.Cells[1, 2] = "Name";
        xlWorkSheet.Cells[2, 1] = "1";
        xlWorkSheet.Cells[2, 2] = "One";
        xlWorkSheet.Cells[3, 1] = "2";
        xlWorkSheet.Cells[3, 2] = "Two";
        */


            // xlWorkBook.SaveAs("d:\\Work\\csharp-Excel.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, 
        }
        public void writeFromList(int rowNum, string[] datalist)
        {

            if (datalist.Length >= 25)
            {
                xlWorkSheet.Cells[rowNum, 1] = datalist[0];
                xlWorkSheet.Cells[rowNum, 2] = datalist[1];
                xlWorkSheet.Cells[rowNum, 3] = datalist[2];
                xlWorkSheet.Cells[rowNum, 4] = datalist[3];
                xlWorkSheet.Cells[rowNum, 5] = datalist[4];
                xlWorkSheet.Cells[rowNum, 6] = datalist[5];
                xlWorkSheet.Cells[rowNum, 7] = datalist[6];
                xlWorkSheet.Cells[rowNum, 8] = datalist[7];
                xlWorkSheet.Cells[rowNum, 9] = datalist[8];
                xlWorkSheet.Cells[rowNum, 10] = datalist[9];
                xlWorkSheet.Cells[rowNum, 11] = datalist[10];
                xlWorkSheet.Cells[rowNum, 12] = datalist[11];
                xlWorkSheet.Cells[rowNum, 13] = datalist[12];
                xlWorkSheet.Cells[rowNum, 14] = "\t" + datalist[13];
                xlWorkSheet.Cells[rowNum, 15] = "\t" + datalist[14];
                xlWorkSheet.Cells[rowNum, 16] = "\t" + datalist[15];
                xlWorkSheet.Cells[rowNum, 17] = datalist[16];
                xlWorkSheet.Cells[rowNum, 18] = datalist[17];
                xlWorkSheet.Cells[rowNum, 19] = datalist[18];
                xlWorkSheet.Cells[rowNum, 20] = datalist[19];
                xlWorkSheet.Cells[rowNum, 21] = datalist[20];
                xlWorkSheet.Cells[rowNum, 22] = datalist[21];
                xlWorkSheet.Cells[rowNum, 23] = datalist[22];
                xlWorkSheet.Cells[rowNum, 24] = datalist[23];
                xlWorkSheet.Cells[rowNum, 25] = datalist[24];
            }
// xlWorkSheet.Cells[rowNum, 26] = datalist[25];


            /*
        xlWorkSheet.Cells[1, 1] = "ID";
        xlWorkSheet.Cells[1, 2] = "Name";
        xlWorkSheet.Cells[2, 1] = "1";
        xlWorkSheet.Cells[2, 2] = "One";
        xlWorkSheet.Cells[3, 1] = "2";
        xlWorkSheet.Cells[3, 2] = "Two";
        */


            // xlWorkBook.SaveAs("d:\\Work\\csharp-Excel.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, 
        }
        public void writeCell(int row, int col, string data)
        {
            xlWorkSheet.Cells[row, col] = data;
        }
        public void close()
        {
            
            xlWorkBook.Save();
            // xlWorkBook.Close(true, misValue, misValue);
            //xlApp.Quit();

         //   Marshal.ReleaseComObject(xlWorkSheet);
         //   Marshal.ReleaseComObject(xlWorkBook);
         //   Marshal.ReleaseComObject(xlApp);
        }
}
}
