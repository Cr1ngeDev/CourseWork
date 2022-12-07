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
    public partial class HowToUse : Form
    {
        public HowToUse()
        {
            InitializeComponent();
        }

        private void HowToUse_Load(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                label1.Text = "Посібник з використання програми";
                label2.Text = "1) а) Створіть файл, де послідовно будуть записані наступні параметрі: " +
                    "\n    назва животного, кількість, тип животного(по бажанню).\r" +
                    "    б) Додайте животного вручну, використовуючи відповідну кнопку.\r" +
                    "2) Скористайтеся можливістю видалення обраної вами строки таблиці з животним.\r" +
                    "3) Відсортуйте таблицю за ссавцям, раніше обраним вами в головній таблиці.\r" +
                    "4) Після виконання пункта 3, ви можете відсортувати таблицю за парнокопитними.\r" +
                    "5) За потреби, ви можете скористуватися розрахунком приблизної* ваги животного\r    (крупний рогатий скот або свиноподібні).\r" +
                    "\r   Примітка: ви не зможете відсортувани таблицю за парнокопитніми,\r   допоки не буде виконано пункт 3.";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked== true) 
            {
                label1.Location = new Point(173, 9);
                label1.Text = "Guide to using the program";
                label2.Text = "1) a) Create a file where the following parameters will be recorded sequentially: " +
                    "\n    name of the animal, number, type of animal (optional).\r" +
                    "     b) Add the animal manually using the appropriate button.\r" +
                    "2) Take advantage of the option to delete the selected period of the table with the animal.\r" +
                    "3) Sort the table by the mammals previously selected by you in the main table.\r" +
                    "4) After completing point 3, you have the option to sort the table by atriodactyls.\r" +
                    "5) If necessary, you can use the calculation of the approximate* weight of the animal\r    (cattle or swine).\r" +
                    "\r   Note: You will not be able to even sort the table until step 3 is completed.";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked== true) 
            {
                label1.Location = new Point(150,9);
                label1.Text = "Посібник з використання програми";
                label2.Text = "1) а) Створіть файл, де послідовно будуть записані наступні параметрі: " +
                    "\n    назва животного, кількість, тип животного(по бажанню).\r" +
                    "    б) Додайте животного вручну, використовуючи відповідну кнопку.\r" +
                    "2) Скористайтеся можливістю видалення обраної вами строки таблиці з животним.\r" +
                    "3) Відсортуйте таблицю за ссавцям, раніше обраним вами в головній таблиці.\r" +
                    "4) Після виконання пункта 3, ви можете відсортувати таблицю за парнокопитними.\r" +
                    "5) За потреби, ви можете скористуватися розрахунком приблизної* ваги животного\r    (крупний рогатий скот або свиноподібні).\r" +
                    "\r   Примітка: ви не зможете відсортувани таблицю за парнокопитніми,\r   допоки не буде виконано пункт 3.";
            }
        }
    }
}
