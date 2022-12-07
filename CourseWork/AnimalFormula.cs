using CourseWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Formuls
{
    interface IFormulas
    {
        double Weight(int Condition);
    }
    class Cattle : IFormulas
    {
        private string FirstOpt;
        private string SecOpt;
        private double Factor = 0.0;
        private double ChestC;
        private double Length;
        private double Result = 0;

        public Cattle(string FirstOpt, string SecOpt)
        {
            this.FirstOpt = FirstOpt;
            this.SecOpt = SecOpt;
        }

        public double Weight(int Condition)
        {
            if (FirstOpt != "" || SecOpt != "")
            {
                ChestC = Convert.ToDouble(FirstOpt);
                Length = Convert.ToDouble(SecOpt);
                if (Condition == 1)
                {
                    Factor = 2.0;
                    Result = ChestC * Length / 100.0 * Factor;
                    Result = Math.Round(Result, 1);
                }
                if (Condition == 2)
                {
                    Factor = 2.5;
                    Result = ChestC * Length / 100.0 * Factor;
                    Result = Math.Round(Result, 1);
                }
            }
            return Result;
        }
    }
    internal class PigLike : IFormulas
    {
        private string FirstOpt;
        private string SecOpt;
        private double Chest;
        private double Len;
        private double Result = 0.0;

        public PigLike(string FirstOpt, string SecOpt)
        {
            this.FirstOpt = FirstOpt;
            this.SecOpt = SecOpt;
        }

        public double Weight(int Condition)
        {

            Chest = Convert.ToDouble(FirstOpt);
            Len = Convert.ToDouble(SecOpt);
            if (Condition == 3)
            {
                Result = Chest * Len / 142.0;
                Result = Math.Round(Result, 1);
            }
            if (Condition == 4)
            {
                Result = Chest * Len / 156.0;
                Result = Math.Round(Result, 1);
            }
            if (Condition == 5)
            {
                Result = Chest * Len / 162.0;
                Result = Math.Round(Result, 1);
            }
            return Result;
        }
    }
}