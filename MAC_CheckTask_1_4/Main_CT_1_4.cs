using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HD_F = MAC_Hidden_Data.Functions;
using UTL = MAC_DLL.Utilities;
using MyToF = MAC_DLL.MyTableOfFunction;
using FWG = MAC_DLL.Form_with_Graphics;


namespace MAC_CheckTask_1_4
{
    class Main_CT_1_4
    {
        public static double a = -0.82, b = -0.76, fz = -0.04;
        static void Main(string[] args)
        {
            double xo = -4.2, xn = +3.7, eps = 1.0E-10; int n = 400, k = 0;
            MyToF TF = new MyToF(xo, xn, n, Fx, " F(x)");
            TF.Roots_Correction(eps);
            using (StreamWriter SW = UTL.ResultWriter("CT_1_4_v3_1", "Main_CT_1_4.cs"))
            {
                SW.WriteLine(TF.Table_of_Roots(" Roots of F(x)"));
                if (TF.Roots != null) k = TF.Roots.Count;
                if (k > 1)
                {
                    double minR = TF.Roots[0].X, maxR = TF.Roots[k - 1].X;
                    SW.WriteLine($" Minor Root = {minR,14:F10}");
                    SW.WriteLine($" Major Root = {maxR,14:F10}");
                    SW.WriteLine($"   Distanse = {(maxR - minR),14:F10}");
                }
            }
            FWG.SingleGraphic(TF, 300, 500);
        }
        public static double Fx(double x) { return HD_F.CT_1_4_F03(x, a, b) - fz; }
    }
}
