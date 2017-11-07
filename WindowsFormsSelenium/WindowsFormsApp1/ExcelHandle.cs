using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
namespace WindowsFormsApp1
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
            xlWorkSheet.Cells[rowNum, 4] = data["duong_dung"];
            xlWorkSheet.Cells[rowNum, 5] = data["stt_hoatchat"];
            xlWorkSheet.Cells[rowNum, 6] = data["hoat_chat"];
            xlWorkSheet.Cells[rowNum, 7] = data["ham_luong"];
            xlWorkSheet.Cells[rowNum, 8] = data["so_dang_ky"];
            xlWorkSheet.Cells[rowNum, 9] = data["nha_sx"];
            xlWorkSheet.Cells[rowNum, 10] = data["nuoc_sx"];
            xlWorkSheet.Cells[rowNum, 11] = data["quy_cach"];
            xlWorkSheet.Cells[rowNum, 12] = data["don_vi_tinh"];
            xlWorkSheet.Cells[rowNum, 13] = data["ma_nha_thau"];
            xlWorkSheet.Cells[rowNum, 14] = data["ten_nha_thau"];
            xlWorkSheet.Cells[rowNum, 15] = data["quyet_dinh"];
            xlWorkSheet.Cells[rowNum, 16] = data["ngay_cong_bo"];
            xlWorkSheet.Cells[rowNum, 17] = data["tieu_chuan"];
            xlWorkSheet.Cells[rowNum, 18] = data["goi_thau"];
            xlWorkSheet.Cells[rowNum, 19] = data["nhom_thuoc"];
            xlWorkSheet.Cells[rowNum, 20] = data["han_dung"];
            xlWorkSheet.Cells[rowNum, 21] = data["nam"];
            xlWorkSheet.Cells[rowNum, 22] = data["mieu_ta"];
            xlWorkSheet.Cells[rowNum, 23] = data["trang_thai"];


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
        public void close()
        {
            
            xlWorkBook.Save();
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
}
}
