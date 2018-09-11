using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace GetMappedDrives
{
    class Start
    {
        static void Main(string[] args)
        {
            RegistryKey networkKeys = null;
            if (args.Length > 0)
            {
                //Console.WriteLine("plus 1");
                foreach (var item in args)
                {
                    try
                    {
                        networkKeys = Registry.Users.OpenSubKey(item + "\\Network");
                        Console.WriteLine(item + " worked.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(item + " didn't work: " + e.Message);
                    }
                }
            }

            if (networkKeys == null)
            {
                networkKeys = Registry.CurrentUser.OpenSubKey("Network");
                Console.WriteLine("current user used...");
            }
            //Registry.Users.OpenSubKey(@"OldUser\Network");
            var FileLines = new StringBuilder();
            var nl = Environment.NewLine;

            FileLines.Append("On Error Resume Next \r\n Dim objNetwork \r\n " +
                "Set objNetwork = WScript.CreateObject(\"WScript.Network\") \r\n");

            Console.WriteLine("Getting mapped drives...");

            foreach (var line in NetworkRegistry.GetDrives(networkKeys))
            {
                Console.WriteLine("Got: " + line);

                var sline = line.Split(',');

                FileLines.Append("objNetwork.MapNetworkDrive \"" + sline[0] + ":\", \"" + sline[1] + "\", true \r\n");
            }

            var outputFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\MappedDrives.vbs";
            Console.WriteLine("Writing vbs file to: " + outputFile);

            File.WriteAllText(outputFile, FileLines.ToString());

            Console.WriteLine("Complete -- press ENTER to exit...");
            Console.ReadLine();
        }

        

    }
}
