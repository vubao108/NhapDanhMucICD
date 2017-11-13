using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelWinform
{
    public partial class ExcelWinform : Form
    {
        private string text_file;
        public string Text_file
        {
            get {
                return text_file; 
             }
            
            set
            {
                text_file = value;
                lbText.Text = text_file;
            }
        }

        public string Excel_file { get => excel_file;
            set  { excel_file = value;
                lbExcel.Text = excel_file;
            }
        }

        private string excel_file;

        public ExcelWinform()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (text_file != null && Excel_file != null) {
                int sheet ;
                int start_position_row ;
                if(!int.TryParse(textBox1.Text, out sheet))
                
                {
                    sheet = 1;
                }
                 
                if(!int.TryParse(tbRowStart.Text, out start_position_row))
                {
                    start_position_row = 2;
                }
                                
                    
                
                lbResult.Text = "dang xu ly";

                //Task convert_task = Task.Run(() => Process.process(text_file, Excel_file,sheet, start_position_row ));
                //await convert_task;
                Process.update_Process = this.excel_handle_update_process;
                await Task.Run(() => Process.process(text_file, Excel_file, sheet, start_position_row));
                lbResult.Text = "Da xong";

            }
        }
        
        private int excel_handle_update_process(float percent )
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => excel_handle_update_process(percent)));
            }
            else
            {
                lbResult.Text = "Dang xu ly : " + percent + " row";

            }
            return (int)percent;
            
        }
        

        private void btText_Click(object sender, EventArgs e)
        {
            DialogResult text_result = openFileDialog1.ShowDialog();
            if(text_result == DialogResult.OK)
            {
                this.Text_file = openFileDialog1.FileName;
            }
            
        }

        private void btExcel_Click(object sender, EventArgs e)
        {
            DialogResult text_result = openFileDialog2.ShowDialog();
            if (text_result == DialogResult.OK)
            {
                this.Excel_file = openFileDialog2.FileName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
