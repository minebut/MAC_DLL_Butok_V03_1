using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CLS = MAC_DLL.MAC_Series;
using UTL = MAC_DLL.Utilities;
using System.Runtime.Remoting.Messaging;

namespace MAC_LabWork_1_1
{
    class Main_LW_1_1
    {
        static int kF = 0;
        static double Eps = 1.0E-9, Dlt = 1.0E-8;
        static void Main(string[] args)
        {
            //CommonTest("Lw_1_1_Test", 10000);
            MyVariant("LW_1_1_v3", 15100);
        }
        static void MyVariant(string name, int N)
        {
            using (StreamWriter SW = MAC_DLL.Utilities.ResultWriter(name, "Main_LW_1_1.cs"))
            {
                double SN = MAC_DLL.MAC_Series.Sum_of_Numbers_Series(0, N, My_sk);
                SW.WriteLine($"\r\n Summa SN : {N,8} {SN,20:F10}");

                double True_Sum1 =Math.PI/(2.0 * Math.Sqrt(3.0));
                double S1 = MAC_DLL.MAC_Series.Sum_of_Number_Series_A(0, Eps, My_si, ref kF);
                SW.WriteLine($"\r\n Summa S1: {kF,8} {S1,20:F10}\r\n{True_Sum1,40:F10}");
            }
        }
        static double My_sk(int k)
        { return 1.0 / ((k+1.0)*(3.0 * k + 1.0)); }

        static double My_si(int i)
        {
            return Math.Pow(-1, i) / ((i + 1.0)*(3.0 * i + 1.0));
        }

        static void CommonTest(string name, int N)
        {
            using (StreamWriter SW = UTL.ResultWriter(name, "LW_1_1_Test"))
            {
                double SN = CLS.Sum_of_Numbers_Series(0, N, My_sk);
                SW.WriteLine($"\r\n Summa SN : {N,8} {SN,20:F15}");


                SW.WriteLine("\r\n Summa 1 :");
                double True_Sum1 = Math.PI * Math.PI / 8.0 - 1.0;
                double S1_N = CLS.Sum_of_Numbers_Series(1, N, My_ak);
                SW.WriteLine($"{N,8}{S1_N,20:F15}\r\n{True_Sum1,28:F15}");

                double S1_A = CLS.Sum_of_Number_Series_A(1, Eps, My_ak, ref kF);
                SW.WriteLine($"{kF,8}{S1_A,20:F15}");
                double S1_D = CLS.Sum_of_Number_Series_A(1, Dlt, My_ak, ref kF);
                SW.WriteLine($"{kF,8}{S1_D,20:F15}");



                SW.WriteLine("\r\n Summa 2 :");
                double True_Sum2 = Math.Pow(Math.PI, 3.0) / 32.0; ;
                double S2_N = CLS.Sum_of_Numbers_Series(0, N, My_bk);
                SW.WriteLine($"{N,8}{S2_N,20:F15}\r\n{True_Sum2,28:F15}");

                double S2_A = CLS.Sum_of_Number_Series_A(1, Eps, My_bk, ref kF);
                SW.WriteLine($"{kF,8}{S2_A,20:F15}");
                double S2_D = CLS.Sum_of_Number_Series_A(1, Dlt, My_bk, ref kF);
                SW.WriteLine($"{kF,8}{S2_D,20:F15}");
            }
        }
        static double My_ak(int k)
        {
            double a = 2.0 * k + 1.0;
            return 1.0 / (a * a);
        }
        static double My_bk(int k)
        {
            double b = 2.0 * k + 1.0;
            if ((k % 2) == 0)
                return 1.0 / (b * b * b);
            else
                return -1.0 / (b * b * b);
        }
    }
}
