using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWinform
{
    class Process
    {
        public  delegate int Del_update_process(float current_percent);
        public static Del_update_process update_Process;

        public static void process(string datafile, string xlsdata, int sheet = 1, int row_start = 2 )
        {
            // string datafile = "D:\\Work\\data_bhxh.txt";
           
            string[] lines = File.ReadAllLines(datafile);
            ExcelHandle eh = new ExcelHandle();
            eh.open(xlsdata, sheet );
            int i = 0;
            
            foreach (var linetmp in lines)
            {
                
                if (!String.IsNullOrWhiteSpace(linetmp) && !String.IsNullOrEmpty(linetmp))
                {

                    var datalist = linetmp.Split(new char[] { '|' });
                    int position_row_to_write = row_start + i;  
                    eh.writeFromList(position_row_to_write, datalist);
                }
                ++i;
                if (update_Process != null)
                {
                    update_Process(i);
                }
            }

            

            eh.close();

        }
    }

}
