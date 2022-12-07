using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Formuls;
using System.Windows.Forms;
namespace CourseWork
{
    public partial class Weight : Form
    {
        IFormulas formulas;
        DataGridView FirstTable, SecondTable;
        public double Result { get; private set; }
        readonly List<string> str = new List<string>();
        public Weight(DataGridView firstTable, DataGridView secondTable)
        {
            InitializeComponent();
            FirstTable= firstTable;
            SecondTable = secondTable;
        }
        public Weight() 
        {
            InitializeComponent();
        }
        public void Re(string data)
        {
            str.Add(data);
        }
        private void Weight_Load(object sender, EventArgs e)
        {
            for (int j = 0; j < str.Count; j++)
            {
                comboBox1.Items.Add(str[j]);
            }

        }

        private void Okey_Click(object sender, EventArgs e)
        {
            double ChestC, Length;
            double Factor=0;            
            string formula = comboBox2.Text;
            if (formula == "Cattle(крупный рогатый скот)")
            {
                textBox3.Clear();
                ToolTip tooltip;
                if (TextCattle1.Text == "")
                {
                    pictureBox3.Visible = true;
                    tooltip = new ToolTip();
                    tooltip.SetToolTip(pictureBox3, "Enter the value");
                }
                else
                {
                    pictureBox3.Visible = false;
                }
                if (TextCattle2.Text == "")
                {
                    pictureBox4.Visible = true;
                    tooltip = new ToolTip();
                    tooltip.SetToolTip(pictureBox4, "Enter the value");
                }
                else
                {
                    pictureBox4.Visible = false;
                }
                if (TextCattle2.Text != "" && TextCattle1.Text != "")
                {
                    formulas = new Cattle(TextCattle1.Text, TextCattle2.Text);
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                }
                try
                {
                    if (radioButton3.Checked == false || radioButton2.Checked == false)
                    {
                        pictureBox1.Visible = true;
                        ToolTip tool = new ToolTip();
                        tool.SetToolTip(pictureBox1, "Choose option");
                    }
                    if (radioButton3.Checked == true)
                    {
                        pictureBox1.Visible = false;
                        textBox3.Clear();
                        Result = formulas.Weight(1);
                        textBox3.Text = "~" + Result + " kg";
                    }
                    if (radioButton2.Checked == true)
                    {
                        pictureBox1.Visible = false;
                        textBox3.Clear();
                        Result = formulas.Weight(2);
                        textBox3.Text = "~" + Result + " kg";
                    }
                }
                catch 
                {
                    MessageBox.Show("You have not entered a value,\nor you entered not number value!");
                }
            }
            if (formula == "Pig-like(свиноподобные)")
            {
                textBox3.Clear();
                formulas = new PigLike(TextPig1.Text, TextPig2.Text);
                ToolTip toolTip;
                if (TextPig1.Text == "")
                {
                    pictureBox5.Visible = true;
                    toolTip = new ToolTip();
                    toolTip.SetToolTip(pictureBox5, "Enter the value");
                }
                else
                {
                    pictureBox5.Visible = false;
                }
                if (TextPig2.Text == "")
                {
                    pictureBox6.Visible = true;
                    toolTip = new ToolTip();
                    toolTip.SetToolTip(pictureBox6, "Enter the value");
                }
                else
                {
                    pictureBox6.Visible = false;
                }
                if (TextCattle2.Text != "" && TextCattle1.Text != "")
                {
                    formulas = new Cattle(TextCattle1.Text, TextCattle2.Text);
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                }
                try
                {
                    if (radioButton1.Checked == false || radioButton4.Checked == false || radioButton5.Checked == false)
                    {
                        pictureBox2.Visible = true;
                        ToolTip tool = new ToolTip();
                        tool.SetToolTip(pictureBox1, "Choose option");
                    }
                    if (radioButton1.Checked == true)
                    {
                        textBox3.Clear();
                        pictureBox2.Visible = false;
                        Result = formulas.Weight(3);
                        textBox3.Text = "~" + Result + " kg";
                    }
                    if (radioButton4.Checked == true)
                    {
                        textBox3.Clear();
                        pictureBox2.Visible = false;
                        Result = formulas.Weight(3);
                        textBox3.Text = "~" + Result + " kg";
                    }
                    if (radioButton5.Checked == true)
                    {
                        textBox3.Clear();
                        pictureBox2.Visible = false;
                        Result = formulas.Weight(3);
                        textBox3.Text = "~" + Result + " kg";
                    }
                }
                catch
                {
                    MessageBox.Show("You have not entered a value,\nor you entered not number value!");
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Name = comboBox2.Text;
            if(Name == "Cattle(крупный рогатый скот)")
            {
                TextPig1.Clear();
                TextPig2.Clear();
                pictureBox1.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else if(Name == "Pig-like(свиноподобные)")
            {
                TextCattle1.Clear();
                TextCattle2.Clear();
                pictureBox2.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }
        private void saver_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==-1) 
            {
                MessageBox.Show("Choose an animal!");
            }
            else
            {
                string Name = comboBox1.Text;
                if (Result!= 0) 
                {
                    for(int i =0; i < SecondTable.Rows.Count;i++)
                    {
                        if (SecondTable.Rows[i].Cells[1].Value.ToString()==Name)
                        {
                            SecondTable.Rows[i].Cells[4].Value = Result+" kg";
                        }
                    }
                    for (int j = 0; j < FirstTable.Rows.Count; j++)
                    {
                        if (FirstTable.Rows[j].Cells[1].Value.ToString() == Name)
                        {
                            FirstTable.Rows[j].Cells[4].Value = Result + " kg";
                        }
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("You haven't done the calculations!");
                }
            }
        }
    }
}
