using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLE = MAC_DLL.MAC_Equations;
using UTL = MAC_DLL.Utilities;
using System.IO;
using MToF = MAC_DLL.MyTableOfFunction;
using FwG = MAC_DLL.Form_with_Graphics;
namespace MAC_LabWork_1_4
{
    class Main_LW_1_4
    {
        static double a = +0.12, b = -1.7;
        static void Main(string[] args)
        {
            MyVariant(1.0E-12);//Test_2_LW_1_4(1.0E-12);//Test_1_LW_1_4();
        }
        static void MyVariant(double epsilon)
        {
            using (StreamWriter SW = UTL.ResultWriter("Main_LW_1_4"))
            {
                //MToF eq_43 = new MToF(0.0, 15.0, 300, F_43, "Test_4_3");
                MToF eq_43 = new MToF(-14.5, -11.0, 700, My_f, "MyVariant");
                
                eq_43.Roots_Correction(epsilon);
                SW.WriteLine(eq_43.Table_of_Roots("Equation 4.3"));
                FwG.SingleGraphic(eq_43, 300, 500);

            }
        }
        static double My_f(double x)
        {
            return  Math.Tanh(a * x) - b * Math.Cos(x * Math.Sqrt(Math.Log10(4) + Math.PI * Math.PI));
        }
        static void Test_2_LW_1_4(double epsilon) 
        {
            using (StreamWriter SW = UTL.ResultWriter("Main_LW_1_4"))
            {
                //MToF eq_43 = new MToF(0.0, 15.0, 300, F_43, "Test_4_3");
                MToF eq_43 = new MToF(0.0, 15.0, 300, F_43, "MyVariant");

                eq_43.Roots_Correction(epsilon);
                SW.WriteLine(eq_43.Table_of_Roots("Equation 4.3"));
                FwG.SingleGraphic(eq_43, 300, 500);
            }
        }
        static double F_43(double x)
        {
            return Math.Tanh(x) - 2.0 * Math.Cos(Math.Sqrt(10.0) * x);
        }
        static void Test_1_LW_1_4()
        {
            using (StreamWriter SW = UTL.ResultWriter("Main_LW_1_4"))
            {
                double root = CLE.Dichotomy(0.3,0.6,1.0E-12,Cos_pi_x,out int k);
                SW.WriteLine($"x = {root,18:F15}      err = {Cos_pi_x(root),7:E1} K={k}");    
            }
        }
        static double Cos_pi_x(double x) { return Math.Cos(Math.PI * x); }
    }
}
