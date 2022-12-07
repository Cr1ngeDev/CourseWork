using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using CourseWork;
using EnumAnimals;
using static CourseWork.Add;
namespace CourseWork
{
    public delegate string PrintCount();    
    interface IAnimals
    {
        void Strings(string[] lines);
        void Result();
        string ErrorString { get; set; }
        string PrintResult();
    }
    class EventMes
    {
        public event PrintCount Output;
        public string PrintEvent()
        {
            if(Output != null) 
            {
                return Output.Invoke();
            }
            return "";
        }
    }
    class Animal : IAnimals
    {
        private string[] lines;
        protected DataGridView ThisData;
        protected string[] buffer;
        public virtual string ErrorString { get; set; }
        public Animal(DataGridView data)
        {
            this.ThisData = data;
        }
        public void Strings(string[] lines)
        {
            this.lines = lines;
        }
        public void Result()
        {
            int Num;
            if (lines != null)
            {
                try
                {
                    foreach (string S in lines)
                    {
                        buffer = S.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (buffer.Length == 2)
                        {
                            try
                            {
                                Num = Convert.ToInt32(buffer[1]);
                                ThisData.Rows.Add(false, buffer[0], Num, "undefined", false);
                            }
                            catch
                            {
                                MessageBox.Show("You entered incorrect format!");
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                Num = Convert.ToInt32(buffer[1]);
                                ThisData.Rows.Add(false, buffer[0], Num, buffer[2], false);
                            }
                            catch
                            {
                                MessageBox.Show("You entered incorrect format!");
                                return;
                            }
                        }
                    }

                }
                catch
                {
                    Form3 ErrorF = new Form3(ErrorString);
                    ErrorF.ErrorWay();
                    ErrorF.ShowDialog();
                }
            }
        }
        private int CalcCount()
        {
            int Count = 0;
            int Num;
            string res;
            try
            {
                if(this.ThisData != null)
                {                   
                    for (int i = 0; i < ThisData.Rows.Count; i++)
                    {
                        Count += Convert.ToInt32(ThisData.Rows[i].Cells[2].Value.ToString());
                    }
                    return Count;
                }               
            }
            catch
            {
                MessageBox.Show("Incorrect input format");
            }
            return 0;
        }
        public string PrintResult()
        {
            int resultOfFun = CalcCount();
            string res;
            if (resultOfFun != 0) 
            {
                res = "Number of all animals in the current table: "+ resultOfFun;
                return res;
            }           
            return "Number of all animals in the current table: " + 0;
        }
    }
    class Mammals : Animal, IAnimals
    {
        private DataGridView OldD;
        private DataGridView NewData;
        public override string ErrorString { get; set; }
        public Mammals(DataGridView ThisData, DataGridView OldData) : base(OldData)
        {
            OldD = OldData;//old
            NewData = ThisData;//empty
        }    
        public void Result()
        {
            NewData.Rows.Clear();
            try
            {
                int CountCheckBox = 0; 
                string?[] buffer;
                int C = 0;
                int count = 1;
                for(int i = 0; i < OldD.Rows.Count; i++) 
                {
                    bool isChecked = (bool)OldD.Rows[i]?.Cells[4].Value;
                    if (isChecked==true) 
                    {
                        CountCheckBox++;
                    }
                }
                if(CountCheckBox!= 0)
                {
                    string[] SortedLines = new string[CountCheckBox];
                    for (int i = 0; i < OldD.Rows.Count; i++)
                    {
                        bool IsChecked = (bool)OldD.Rows[i].Cells[4].Value;
                        string str = string.Empty;
                        for (int j = 1; j < OldD.Columns.Count-1; j++)
                        {
                            if (IsChecked == true)
                            {
                                str += OldD.Rows[i]?.Cells[j]?.Value.ToString() + " ";
                            }
                        }
                        if (str != "")
                        {
                            SortedLines[C] = str;
                            C++;
                        }
                    }
                    if (SortedLines.Length > 0)
                    {
                        foreach (string S in SortedLines)
                        {
                            int? n;
                            buffer = S.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            try
                            {
                                n = Convert.ToInt32(buffer[1]);
                                NewData.Rows.Add(count,buffer[0], n??0, buffer[2]??"undefined");
                                count++;
                            }
                            catch
                            {
                                MessageBox.Show("Error while writing data to table!");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    ErrorSort error = new ErrorSort(ErrorString);
                    error.CheckTabName();
                    error.ShowDialog();
                }
                        
            }
            catch
            {
                MessageBox.Show("Error while reading data from table!");
            }
        }
        private int CalcCount()
        {
            int Count = 0;
            int Num;
            string res;
            try
            {
                if (this.NewData != null)
                {
                    for (int i = 0; i < NewData.Rows.Count; i++)
                    {
                        Count += Convert.ToInt32(NewData.Rows[i].Cells[2].Value.ToString());
                    }
                    return Count;
                }
            }
            catch
            {
                MessageBox.Show("Incorrect input format");
            }
            return 0;
        }
        public new string PrintResult()
        {
            int resultOfFun = CalcCount();
            string res;
            if (resultOfFun != 0)
            {
                res = "Number of all animals in the current table: " + resultOfFun;
                return res;
            }
            return "Number of all animals in the current table: " + 0;
        }
    }
    sealed class Artiodactyl : Mammals, IAnimals
    {
        private DataGridView NewData;
        private DataGridView OldData;
        public override string ErrorString { get; set; }
        public Artiodactyl(DataGridView ThisData, DataGridView OldNewData):base(ThisData, OldNewData)
        {
            NewData = ThisData;
            OldData = OldNewData;
        }
        public void Result()
        {
            string?[] NewLines = new string[OldData.RowCount];
            string?[] buffer;
            int count = 1;
            try
            {
                for(int i = 0;i< OldData.Rows.Count;i++) 
                {
                    string str = string.Empty;
                    for(int j=1;j< OldData.Columns.Count-1;j++)
                    {
                        str += OldData.Rows[i]?.Cells[j]?.Value.ToString() + " ";
                    }
                    NewLines[i] = str;
                }
                if(NewLines.Length > 0) 
                {
                    foreach (string S in NewLines)
                    {
                        buffer = S.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            for (int i = 0; i < Enums.AnimalsToCheck.Length; i++)
                            {
                                if (buffer.Length == 2)
                                {
                                    if (buffer[0].ToLower() == Enums.AnimalsToCheck[i])
                                    {
                                        NewData.Rows.Add(count, buffer[0], buffer[1], "undefined");
                                        count++;
                                    }
                                }
                                else
                                {
                                    if (buffer[0].ToLower() == Enums.AnimalsToCheck[i] || buffer[2].ToLower() == Enums.AnimalsToCheck[i])
                                    {
                                        NewData.Rows.Add(count, buffer[0], buffer[1], buffer[2]);
                                        count++;
                                    }
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Error, something went wrong while writing the data to the table!");
                        }
                    }
                }
                else
                {
                    ErrorSort error = new ErrorSort(ErrorString);
                    error.CheckTabName();
                    error.ShowDialog();
                }
            }
                
            catch
            {
                MessageBox.Show("Ops! Error!\nMaybe file is empty?");
            }
        }
        private int CalcCount()
        {
            int Count = 0;
            int Num;
            string res;
            try
            {
                if (this.NewData != null)
                {
                    for (int i = 0; i < NewData.Rows.Count; i++)
                    {
                        Count += Convert.ToInt32(NewData.Rows[i].Cells[2].Value.ToString());
                    }
                    return Count;
                }
            }
            catch
            {
                MessageBox.Show("Incorrect input format");
            }
            return 0;
        }
        public new string PrintResult()
        {
            int resultOfFun = CalcCount();
            string res;
            if (resultOfFun != 0)
            {
                res = "Number of all animals in the current table: " + resultOfFun;
                return res;
            }
            return "Number of all animals in the current table: " + 0;
        }
    }
}
