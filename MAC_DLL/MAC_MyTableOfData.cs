using System;
using System.Collections.Generic;
using System.IO;
using FTN = MAC_DLL.MAC_Function_Table_Node;
using CI = System.Globalization.CultureInfo;
using System.Windows.Forms.DataVisualization.Charting;

namespace MAC_DLL
{
    public class MyTableOfData : MyTable
    {
        public string Table_in_File { get; } 

        #region <--- Конструктори --->

        public MyTableOfData(string path, string title)
        {
            List<FTN> Temp = new List<FTN>();
            FileInfo file = new FileInfo(path);
            Table_in_File = $"\r\n Таблиця {title} в файлі {file.Name} :\r\n";

            #region <--- Читання бінарного файлу в список даних --->

            if (file.Extension == ".bin")
            {
                BinaryReader bin_rdr = new BinaryReader(file.OpenRead());
                int i = -1;
                try
                {
                    while (true)
                    {
                        Temp.Add(new FTN(bin_rdr.ReadDouble(), bin_rdr.ReadDouble()));
                        Table_in_File += $"{++i,4}" + Temp[i].ToPrint() + "\r\n";
                    }
                }
                catch (IOException) { }
                bin_rdr.Close();
            }
            #endregion <--- Читання бінарного файлу в список даних --->
            #region <--- Читання форматного файлу в список даних --->
            if (file.Extension == ".txt")
            {
                bool dot_or_comma = CI.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".";
                StreamReader txt_rdr = new StreamReader(file.OpenRead());

                
                string[] txt; string line; int i = -1;
                while (!txt_rdr.EndOfStream)
                {
                    i++; line = txt_rdr.ReadLine();
                    line = dot_or_comma ? line.Replace(",", ".").Trim() : line.Replace(".", ",").Trim();

                    txt = line.Split(new char[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    Temp.Add(new FTN(Convert.ToDouble(txt[0]), Convert.ToDouble(txt[1])));
                    Table_in_File += $"{i,4}" + Temp[i].ToPrint() + "\r\n";
                }
                txt_rdr.Close();
            }
            #endregion <--- Читання форматного файлу в список даних --->
            #region <--- Формування Таблиці Даних --->
            if (Temp != null)
            {
                Temp.Sort((point_i, point_j) => point_i.X.CompareTo(point_j.X));
                Nodes = Temp.ToArray();
                Minimum = new FTN(double.NaN, double.MaxValue);
                Maximum = new FTN(double.NaN, double.MinValue);
                for (int i = 0; i < Length; i++)
                {
                    if (Minimum.F > Nodes[i].F) { Minimum = Nodes[i]; }
                    if (Maximum.F < Nodes[i].F) { Maximum = Nodes[i]; }
                }
            }
            else { Nodes = null; Minimum = null; Maximum = null; }
            Title = title;
            #endregion <--- Формування Таблиці Даних --->
            Roots_Location();
        }
        


        public MyTableOfData() { }

        #endregion <--- Конструктори --->

        #region <--- Перевизначення методів класу MyTable --->

        public override string ToPrint(string Comment)
        {
            return Comment + "\r\n" + Table_in_File + Table_of_Function();
        }
        #endregion <--- Перевизначення методів класу MyTable --->
    }
}
