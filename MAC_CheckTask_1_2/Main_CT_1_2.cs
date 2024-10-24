using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UTL = MAC_DLL.Utilities;
using MyF = MAC_DLL.MAC_My_Functions;
namespace MAC_CheckTask_1_2
{
    class Main_CT_1_2
    {
        static void Main(string[] args)
        {
            My_Variant("CT_1_2_v3_1");

        }
        static void My_Variant(string file)
        {
            using (StreamWriter SW = UTL.ResultWriter(file, "Main_CT_1_2.cs"))
            {
                double x1 = +1.82, x2 = +4.45, a = 0.89, b = -1.73, e = 1.0E-9;
                SW.WriteLine("\r\n\r\n" + file + "\r\n");
                SW.WriteLine($" a = {a,5:F2}  b = {b,5:F2}");
                SW.WriteLine($" my_f({x1,5:F2} ) = {MyF.my_f(x1, a, b, e),13:F10}");
                SW.WriteLine($" my_f({x2,5:F2} ) = {MyF.my_f(x2, a, b, e),13:F10}");
            }
        }
    }
}

