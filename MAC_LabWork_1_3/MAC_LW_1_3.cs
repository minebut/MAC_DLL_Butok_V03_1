using System.IO;
using FwG = MAC_DLL.Form_with_Graphics;
using MyToD = MAC_DLL.MyTableOfData;
using UTL = MAC_DLL.Utilities;
namespace MAC_LabWork_1_3
{
    class MAC_LW_1_3
    {
        static void Main(string[] args)
        {
            using (StreamWriter SW = UTL.ResultWriter("LW_1_3_Resul"))
            {

                MyToD T1 = new MyToD("MAC_LW_1_3_v03.bin", "binary file");
                string txt = $"\r\n Прочитано рядків: {T1.Length,0}" + T1.ToPrint("   Обробка файлу *.bin");
                SW.WriteLine(txt);


                MyToD T2 = new MyToD("MAC_LW_1_3_v03.txt", "text      file");
                txt = $"\r\n\r\n\r\n    Прочитано рядків: {T2.Length,0}" + T2.ToPrint("  Обробка Файлу * .txt");
                SW.WriteLine(txt);

                //FwG.SingleGraphic(T2, 300, 500);
                T2.To_txt_File("Test_LW_1_3.txt", "Нова Форма Результатів");
            }


            //LW_1_3("MAC_LW_1_3_v03.bin", "MAC_LW_1_3_v03.txt", "LW_1_3_v03");
        }
        static void LW_1_3(string f_bin, string f_txt, string f_res)
        {
            using (StreamWriter SW = UTL.ResultWriter(f_res))
            {

                MyToD T1 = new MyToD("MAC_LW_1_3_v00.bin", "binary file");
                string txt = $"\r\n Прочитано рядків: {T1.Length,0}" + T1.ToPrint("   Обробка файлу *.bin");
                SW.WriteLine(txt);


                MyToD T2 = new MyToD(f_txt, "text      file");
                txt = $"\r\n\r\n\r\n    Прочитано рядків: {T2.Length,0}"+ T2.ToPrint("  Обробка Файлу * .txt");
                SW.WriteLine(txt);

                //FwG.SingleGraphic(T2, 300, 500);
                T2.To_txt_File("Test_LW_1_3.txt", "Нова Форма Результатів");
            }
        }
    }
}

