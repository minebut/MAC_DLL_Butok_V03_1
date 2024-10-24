using System;
using System.IO;
using MyF = MAC_DLL.MAC_My_Functions;
using UTL = MAC_DLL.Utilities;
namespace MAC_LabWork_1_2
{
    class Main_LW_1_2
    {
        static double A, B, C, e;
        static void Main(string[] args)
        {
            //Console.WriteLine(TestMySinhCosh());
            //Console.WriteLine(TestMySinCos());
            //Console.WriteLine($"{Math.Log(MyF.MyExp(-10.3, 1.0e-20)),36:F22}");
            //A = 15.0; B = 17.0; C = -11.0; e = 1.0E-20;
            //A = 1.50; B = 1.70; C = -1.10; e = 1.0E-20;
            //Console.WriteLine(Test_DLL());
            //Console.WriteLine(Test_Math());
            //MyVariant("LW_1_2_v00");
            MyVariant3_1("LW_1_2_v3_1");
        }
        static void MyVariant3_1(string file) 
        {
            using (StreamWriter SW = UTL.ResultWriter(file, "Main_LW_1_2.cs"))
            {
                SW.WriteLine("\r\n\r\n" + file + "\r\n");
                A = +15.70;
                B = +9.90;
                e = 1.0E-19;
                SW.WriteLine(" Test 1 " + Test_DLL());
                SW.WriteLine(" Test 1 " + Test_Math() + "\r\n");
                A = +4.25;
                B = 7.36;
                e = 1.0E-19;
                SW.WriteLine(" Test 2 " + Test_DLL());
                SW.WriteLine(" Test 2 " + Test_Math() + "\r\n");
                SW.Close();
            }
        }
        static void MyVariant(string file) 
        {
            using (StreamWriter SW = UTL.ResultWriter(file, "Main_LW_1_2.cs")) 
            {
                SW.WriteLine("\r\n\r\n" + file + "\r\n");
                A = 15.7;
                B = 18.3;
                C = -11.9;
                e = 1.0E-19;
                SW.WriteLine("Test 1" + Test_DLL());
                SW.WriteLine("Test 1" + Test_Math() + "\r\n");
                A = 1.57;
                B = 1.83;
                C = -1.19;
                e = 1.0E-19;
                SW.WriteLine("Test 2" + Test_DLL());
                SW.WriteLine("Test 2" + Test_Math() + "\r\n");
                SW.Close();
            }
        }
        static string Test_DLL()
        {
            double p1 = MyF.MyCos(A + B, e) ;
            double p2 = MyF.MyCos(A - B, e);
            double F1 = 2 * MyF.MyCos(A, e) * MyF.MyCos(B, e) , F2 = p1 + p2 ;
            return ($"MAC = {F1,19:F16}    error={Math.Abs(F1 - F2),10:E2}");
        }
        static string Test_Math()
        {
            double q1 = Math.Cos(A + B);
            double q2 = Math.Cos(A - B);
            double F1 = 2 * Math.Cos(A) * Math.Cos(B), F2 = q1 + q2 ;
            return ($"Math = {F1,19:F16}    error ={Math.Abs(F1 - F2),10:E2}");
        }
        
        static string TestMySinhCosh()
        {
            string txt = "TestMySinhCosh()\r\n";
            double unit, error, e = 1.0E-20;
            for (double x = 0.0; x <= 20.0; x += 1.0)
            {
                unit = (MyF.MyCosh(x, e) - MyF.MySinh(x, e)) * (MyF.MyCosh(x, e) + MyF.MySinh(x,e)); // (1.2.16)
                error = Math.Abs(1.0 - unit);
                txt += $"{x,7:F1}{unit,22:F16}{error,22:F16}\r\n";
            }

            return txt;
        }
        static string TestMySinCos()
        {
            string txt = "      Test of MySinCos() \r\n";
            double unit, error, e = 1.0E-20;
            for (double x = 1.0; x <= 40.0; x += 1.0)
            {
                unit = MyF.MyCos(x, e) * MyF.MyCos(x, e) + MyF.MySin(x, e) * MyF.MySin(x, e); // (1.2.12)
                error = Math.Abs(1.0 - unit);
                txt += $"{x,7:F1} {unit,20:F16} {error,20:F16}\r\n";
            }
            return txt;
        }


    }    
}
