﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CourseWork
{
    public partial class Form3 : Form
    {
        public string FileName { get; private set; }
        public Form3(string FileName)
        {
            InitializeComponent();
            this.FileName = FileName;
        }
        public void ErrorWay()
        {
            ErrorLabel.Text = "Error File: "+ FileName;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
