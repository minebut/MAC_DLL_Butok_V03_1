using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTN = MAC_DLL.MAC_Function_Table_Node;

namespace MAC_DLL
{
    public class MyTableOfFunction : MyTable
    {
        protected Func<double, double> Fx;

        public MyTableOfFunction(double xo, double xn, int n,
            Func<double, double> f_x, string title)
        {
            Title = title;
            Fx = f_x;
            Nodes = new FTN[n + 1];
            Minimum = new FTN(double.NaN, double.MaxValue);
            Maximum = new FTN(double.NaN, double.MinValue);

            double hx = (xn - xo) / n, xi;
            for (int i = 0; i <= n; i++)
            {
                xi = xo + i * hx;
                Nodes[i] = new FTN(xi, Fx(xi));
                if (Minimum.F > Nodes[i].F) { Minimum = Nodes[i]; }
                if (Maximum.F < Nodes[i].F) { Maximum = Nodes[i]; }

            }
            Roots_Location();
        }
        #region<--- Перевизначення методів класу MyTable --->
        public override string ToPrint(string Comment)
        {
            return Comment + "\r\n" + Table_of_Function();
        }
        #endregion<--- Перевизначення методів класу MyTable --->

        #region<--- Методи обробки таблиці функції--->
        public override void Roots_Correction(double eps)
        {
            if(Roots != null)
            {
                foreach(Root root in Roots) MAC_Equations.Dichotomy(Fx,root,eps);
            }
        }
        #endregion<--- Методи обробки таблиці функції--->
    }

}
