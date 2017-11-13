using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LayDulieuBHXH
{
    class Program
    {
        

        static void Main(string[] args)
        {
            process();
            
        }

        static void  process()
        {
            // string datafile = "D:\\Work\\data_bhxh.txt";
            string datafile = "D:\\Work\\bhxh_nghean\\bhxh_nghean.txt";
            var xlsdata = "D:\\Work\\BHXH_nghean.xlsx";
            string[] lines = File.ReadAllLines(datafile);
            ExcelHandle eh = new ExcelHandle();
            eh.open(xlsdata, 1);
            int i = 0;
            foreach(var linetmp in lines)
            {
                ++i;
                if (!String.IsNullOrWhiteSpace(linetmp) && !String.IsNullOrEmpty(linetmp))
                {
                    
                    var datalist = linetmp.Split(new char[] { '|' });
                    eh.writeFromList(i + 1, datalist);
                }
            }

            /*
            for(int i=0; i < lines.Length; i ++)
            {
                var linetmp = lines[i];
                //Console.WriteLine(lines[i]);

                if (!String.IsNullOrWhiteSpace(linetmp))
                {
                    string[] datalist = linetmp.Split(new char[] { ' ' });
                    int row = int.Parse(datalist[0]);
                    int col = int.Parse(datalist[1]);
                    string data = "";
                    for(int j = 2; j < datalist.Length; j++)
                    {
                        if (j != 2)
                        {
                            data = data + " " + datalist[j];
                        }
                        else
                        {
                            data = data + datalist[j];
                        }
                    }
                    Console.WriteLine("{0} {1} {2}", row, col, data);
                    eh.writeCell(row, col, data);

                }
               
                
               
               // eh.writeFromList(i + 2, datalist);
                // Console.WriteLine($"{0} \t {1}", line.Length, line);
               // Console.ReadKey();
            }
            */

           eh.close();

        }
    }
}
