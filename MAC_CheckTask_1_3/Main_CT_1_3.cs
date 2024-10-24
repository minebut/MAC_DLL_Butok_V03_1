using UTL = MAC_DLL.Utilities;
using MyF = MAC_DLL.MAC_My_Functions;
using MyToF = MAC_DLL.MyTableOfFunction;
using FwG = MAC_DLL.Form_with_Graphics;
using System.IO;
using MyToD = MAC_DLL.MyTableOfData;
using System.Net.Http.Headers;

namespace MAC_CheckTask_1_3
{
    class Main_CT_1_3
    {
        public static double par_a, par_b, par_e, ksi1, ksi2;
        static void Main(string[] args)
        {
            par_a = +0.50; par_b = -0.90; ksi1 = +2.90; ksi2 = +4.60; par_e = 1.0E-9;
            //par_a = +1.00; par_b = -0.50; ksi1 = +2.50; ksi2 = +5.00; par_e = 1.0E-9;
            MyToF TF = new MyToF(+1.10, +5.70, 230, MyVariant, "MyF_fx(x) ");

            using (StreamWriter SW = UTL.ResultWriter("CT_1_3_v03_1"))
            {
                 
                SW.WriteLine(TF.ToPrint("Контрольна Таблиця Функції"));
                SW.WriteLine($"f1({ksi1,5:F2}) = {MyVariant(ksi1),12:F9}");
                SW.WriteLine($"f2({ksi2,5:F2}) = {MyVariant(ksi2),12:F9}");
            }
            TF.To_txt_File("Test_CT_1_3.txt", "Нова форма Результатів");
            FwG.SingleGraphic(TF, 300, 500);

        }

        public static double MyVariant(double x)
        {
            return MyF.my_f(x, par_a, par_b, par_e);
        }

        public static double MyF_fx(double x)
        { 
            return MyF.fO(x, par_a, par_b, par_e); 
        }
    }
}
