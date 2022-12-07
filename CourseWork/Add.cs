using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace CourseWork
{
    public partial class Add : Form
    {
        public delegate void AddLine(string Aname, string AType, int num);
        public event AddLine Notify;
        private DataGridView data2;
        private string tab1;
        public Add()
        {
            InitializeComponent();
        }
        public Add(string str, DataGridView data)
        {
            InitializeComponent();
            tab1 = str;
            data2 = data;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string? Aname, AType,Num;
            Aname = textBox1.Text; 
            Num = textBox2.Text;
            int ParseNum=0;
            AType = textBox3.Text;
            bool isNum = int.TryParse(Num, out ParseNum);
            string pattern = @"\s+";
            string target = "";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(Aname, target);
            if (!string.IsNullOrEmpty(result)) 
            {
                if (AType == "" || Num == "")
                {
                    AType = "undefined";
                    Notify?.Invoke(Aname, AType, ParseNum);
                }
                else if (isNum)
                {
                    ParseNum = int.Parse(Num);
                    Notify?.Invoke(Aname, AType, ParseNum);
                }
            } 
            else
            {
                textBox1.Clear();
                MessageBox.Show("Enter the name of the animal!");
            }
        }
    }
}
