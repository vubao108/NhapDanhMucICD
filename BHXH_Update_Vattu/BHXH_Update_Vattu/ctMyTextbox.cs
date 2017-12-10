using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BHXH_Update_Vattu
{
    public partial class ctMyTextbox : UserControl
    {
        private AutoCompleteStringCollection _autoCompleteStringCollection;
        public AutoCompleteStringCollection AutoCompleteStringCollection { 
            set {
                this._autoCompleteStringCollection = value;
                bind_auto_complete();
            }
        }

        public String Text {

            get {

                return textBox1.Text; }
            set
            {
                textBox1.Text = value;
            }
       
         }
        public ctMyTextbox()
        {
           
            InitializeComponent();
           // bind_auto_complete();
        }

        private void bind_auto_complete()
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = _autoCompleteStringCollection;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
