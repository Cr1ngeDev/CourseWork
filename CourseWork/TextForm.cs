using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class TextForm : Form
    {
        private string FValue, SValue, TValue;
        private DataGridView data;
        public TextForm(string FValue, string SValue, string TValue)
        {
            InitializeComponent();
            this.FValue = FValue;
            this.SValue = SValue;
            this.TValue = TValue;
        }
        private void TextForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = FValue;
            textBox2.Text = SValue;
            textBox3.Text = TValue;
        }
        public string ReturnTextBox1()
        {
            return textBox1.Text;
        }
        public string ReturnTextBox2()
        {
            foreach(string S in textBox2.Text.Split())
            {
                int number;
                bool success = int.TryParse(S, out number);
                if (success)
                {
                    textBox2.Text = number.ToString();
                    return textBox2.Text;
                }
                else
                {
                    MessageBox.Show("You entered the wrong data format!");
                }
            }
            return "0";
        }
        public string ReturnTextBox3()
        {
            if(textBox3.Text!="")
            {
                return textBox3.Text;
            }
            return "undefined";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
