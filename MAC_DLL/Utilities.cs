using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MAC_DLL
{
  public class Utilities
  {
    public static StreamWriter ResultWriter(string name, params string[] files)
    {
      string projectDir =
             Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

      string file_name = name + "_BUTOK_A_V.txt";

      StreamWriter writer = new StreamWriter(file_name);
      foreach (string file in files)
      {
        writer.WriteLine(file + ":\r\n");
        writer.Flush();
        using (StreamReader reader = new StreamReader(projectDir + '\\' + file))
          reader.BaseStream.CopyTo(writer.BaseStream);
        writer.WriteLine("\r\n// -------------------------------------- //\r\n");
      }
      writer.Write(file_name);
      writer.WriteLine($"  data : {DateTime.Now.ToShortDateString()}" +
                       $"  time : {DateTime.Now.ToShortTimeString()}\r\n");
      return writer;
    }
  }
}
