using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAC_DLL
{
    public class MyExtendedTableOfFunctions : MyTableOfFunction
    {
        protected Func<double, double> D1Fx, D2Fx;

        public MyExtendedTableOfFunctions(double xo, double xn, int n, Func<double, double> fx,
                                            Func<double, double> d1fx, Func<double, double> d2fx, string title)
                                            : base(xo, xn, n, fx, title)
        {
            D1Fx = d1fx; D2Fx = d2fx;
        }

        public override void Roots_Correction(double eps)
        {
            if (Roots != null)
            {
                foreach (Root root in Roots)
                    MAC_Equations.Tangent(Fx, D1Fx, D2Fx, root, eps);
            }
        }
    }
}
