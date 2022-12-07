using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.LinkLabel;
using System.Globalization;
using static CourseWork.Add;
using System.Data.SqlTypes;
using System.Threading;
using System.Xml;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        Add addline;
        IAnimals animals;
        private int indexRow;
        private string? FValue, SValue, TValue;
        public string?[] Lines { get; private set; }
        public int count;
        public Form1()
        {
            InitializeComponent();
        }
        
        // SAVE EVENTS
        private void saveMammalsTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileName = saveFileDialog1.FileName;
                using (var sw = new StreamWriter(FileName,true))
                {
                    try
                    {
                        sw.WriteLine("Mammals table:");
                        for (int a = 0; a < SortedMammals.Rows.Count; a++)
                        {
                            for (int b = 0; b < SortedMammals.Columns.Count; b++)
                            {
                                sw.Write(SortedMammals.Rows[a]?.Cells[b]?.Value?.ToString() + "\t");
                            }
                            sw.WriteLine();
                        }
                        sw.WriteLine(label2.Text);
                        sw.WriteLine();
                        MessageBox.Show("File saved successfully!");
                    }
                    catch
                    {
                        MessageBox.Show("Error!");
                    }
                    finally
                    {
                        sw.Close();
                        saveFileDialog1.Dispose();
                    }
                }
            }
        }
        private void saveArtiodactylTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileName = saveFileDialog1.FileName;
                using (var sw = new StreamWriter(FileName,true))
                {
                    try
                    {
                        sw.WriteLine("Artiodactyl table:");
                        for (int a = 0; a < SortedTable.Rows.Count; a++)
                        {
                            for (int b = 0; b < SortedTable.Columns.Count; b++)
                            {
                                sw.Write(SortedTable.Rows[a].Cells[b].Value?.ToString() + "\t");
                            }
                            sw.WriteLine();
                        }
                        sw.WriteLine(label3.Text);
                        sw.WriteLine();
                        MessageBox.Show("File saved successfully!");
                    }
                    catch
                    {
                        MessageBox.Show("Error!");
                    }
                    finally
                    {
                        sw.Close();
                        saveFileDialog1.Dispose();
                    }
                }
            }
        }
        private void saveBothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileName = saveFileDialog1.FileName;
                using (var sw = new StreamWriter(FileName))
                {
                    try
                    {
                        sw.WriteLine("Mammals table:");
                        if(SortedMammals.Rows.Count == 0)
                        {
                            sw.WriteLine("Mammals table is empty, check your table in program.");
                        }
                        else
                        {
                            for (int a = 0; a < SortedMammals.Rows.Count; a++)
                            {
                                for (int b = 0; b < SortedMammals.Columns.Count; b++)
                                {
                                    sw.Write(SortedMammals.Rows[a]?.Cells[b]?.Value?.ToString() + "\t");
                                }
                                sw.WriteLine();
                            }
                            sw.WriteLine(label2.Text);
                        }                        
                        sw.WriteLine();
                        sw.WriteLine("Artiodactyl table:");
                        if(SortedTable.Rows.Count == 0)
                        {
                            sw.WriteLine("Artiodactyl table is empty, check your table in program.");
                        }
                        else
                        {
                            for (int a = 0; a < SortedTable.Rows.Count; a++)
                            {
                                for (int b = 0; b < SortedTable.Columns.Count; b++)
                                {
                                    sw.Write(SortedTable.Rows[a].Cells[b].Value?.ToString() + "\t");
                                }
                                sw.WriteLine();
                            }
                            sw.WriteLine(label3.Text);
                        }                        
                        sw.WriteLine();
                        MessageBox.Show("File saved successfully!");
                    }
                    catch
                    {
                        MessageBox.Show("Error!");
                    }
                    finally
                    {
                        sw.Close();
                        saveFileDialog1.Dispose();
                    }
                }
            }
        }   
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "Text Files|*.txt";
            string FileName;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                if (new FileInfo(OpenFile.FileName).Length != 0)
                {
                    FileName = OpenFile.FileName;
                    Lines = File.ReadAllLines(FileName);                  
                    animals = new Animal(dataGridView2);
                    animals.Strings(Lines);
                    animals.ErrorString = FileName;
                    animals.Result();
                    button4.Enabled= true;
                    label4.Visible = false;
                    Output();
                }
                else
                {
                    MessageBox.Show("File is empty or do not exist!");
                }
            }

        }       
        // SAVE EVENTS

        // SOME MENU SETTINGS
        private void aboutToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            aboutToolStripMenuItem.ForeColor = Color.Black;
        }
        private void aboutToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            aboutToolStripMenuItem.ForeColor = Color.White;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void abotProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();      
            about.ShowDialog();
        }
        private void howToUseProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HowToUse how = new HowToUse();
            how.Show();
        }
        // SOME MENU SETTINGS 

        // ALL MY BUTTONS
        private void button3_Click(object sender, EventArgs e)
        {
            Weight forms = new Weight(SortedMammals,SortedTable);
            for (int i = 0; i < SortedTable.Rows.Count; i++)
            {
                forms.Re(SortedTable[1, i].Value.ToString());
            }
            forms.Show();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            addline = new Add();
            addline.Show();           
            addline.Notify += GetValue;
            animals = new Animal(dataGridView2);
            void GetValue(string AName, string? AType, int num)
            {                
                dataGridView2.Rows.Add(false, AName, num, AType, false);
                Output();
                button4.Enabled = true;
                label4.Visible = false;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SortedMammals.Rows.Clear();
            animals = new Mammals(SortedMammals, dataGridView2);
            animals.ErrorString = tabPage1.Text;
            animals.Result();
            button2.Enabled = true;
            label4.Visible = false;
            label5.Visible = false;
            Output();
        }
        private void button2_Click(object sender, EventArgs e)
        {          
            SortedTable.Rows.Clear();
            animals = new Artiodactyl(SortedTable, SortedMammals);
            animals.ErrorString = tabPage3.Text;
            animals.Result();
            Output();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count == 0) 
            {
                MessageBox.Show("Table is empty!");
            }
            else
            {
                dataGridView2.Rows.Clear();
                Output();
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int CountCheckBox = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                bool isChecked = (bool)dataGridView2.Rows[i]?.Cells[0].Value;
                if (isChecked == true)
                {
                    CountCheckBox++;
                }
            }
            if(CountCheckBox!=0)
            {
                for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
                {
                    bool isChecked = (bool)dataGridView2.Rows[i]?.Cells[0].Value;
                    if (isChecked == true)
                    {
                        dataGridView2.Rows.RemoveAt(i);
                    }
                }
                Output();
            }
            else
            {
                ErrorSort error = new ErrorSort("You have not selected rows to delete!");
                error.GeneralError();
                error.ShowDialog();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count!=0) 
            {
                TextForm txtF = new TextForm(FValue, SValue, TValue);
                if (txtF.ShowDialog() == DialogResult.OK)
                {
                    DataGridViewRow dataGridViewRow = dataGridView2.Rows[indexRow];
                    dataGridViewRow.Cells[1].Value = txtF.ReturnTextBox1();
                    dataGridViewRow.Cells[2].Value = txtF.ReturnTextBox2();
                    dataGridViewRow.Cells[3].Value = txtF.ReturnTextBox3();
                    Output();
                }
            }
            else
            {
                MessageBox.Show("You cannot edit rows unless the table exists!");
            }
        }
        // ALL MY BUTTONS

        // ELSE
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dataGridView2.Rows[indexRow];
            FValue = row.Cells[1].Value.ToString();
            SValue = row.Cells[2].Value.ToString();
            TValue = row.Cells[3].Value.ToString();
        }
        public void Output()
        {
            EventMes eventMessage = new EventMes();
            if (tabControl1.SelectedTab.Text == "Main Table")
            {
                label1.Visible = true;
                eventMessage.Output += animals.PrintResult;
                label1.Text = eventMessage.PrintEvent();
            }
            else if(tabControl1.SelectedTab.Text == "Mammals")
            {
                label2.Visible=true;
                eventMessage.Output += animals.PrintResult;
                label2.Text = eventMessage.PrintEvent();              
            }
            else if(tabControl1.SelectedTab.Text == "Artiodactyls")
            {
                label3.Visible=true;
                eventMessage.Output += animals.PrintResult;
                label3.Text = eventMessage.PrintEvent();
            }
        }
        // ELSE

        // TOOL TIP
        private void label4_MouseHover(object sender, EventArgs e)
        {
            ToolTip tool = new ToolTip();
            tool.SetToolTip(label4, "To activate this button,\nyou must choose at least, one animal.");
        }
        private void label5_MouseHover(object sender, EventArgs e)
        {
            ToolTip tool = new ToolTip();
            tool.SetToolTip(label5, "To activate this button,\nyou must add animals to Mammals Table.");
        }
        // TOOL TIP
    }
}
