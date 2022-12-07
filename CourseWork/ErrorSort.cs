using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class ErrorSort : Form
    {
        private string ErrorText;
        public ErrorSort(string name)
        {
            InitializeComponent();
            ErrorText= name;
        }
        public void CheckTabName()
        {
            if(ErrorText.ToLower() =="main table")
            {
                label1.Text = "You will not be able to sort this table,\nuntil you check the boxes in the table \"Main Table\"";
            }
            else if(ErrorText.ToLower() == "mammals")
            {
                label1.Text = "You will not be able to sort this table,\nuntil you check the boxes in the table \"Mammals\"";
            }
        }
        public void GeneralError()
        {
            label1.Text = ErrorText;
            label1.Location = new Point(68, 48);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
        }
    }
}
