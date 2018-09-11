using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace GetMappedDrives
{
    public static class NetworkRegistry
    {

        /// <summary>
        /// Gets the network drive letters and paths
        /// </summary>
        /// <param name="Key"></param>
        /// <returns>returns true is successful</returns>
        public static List<string> GetDrives(RegistryKey Key)
        {
            //RegistryKey Key = Registry.CurrentUser.OpenSubKey("Network");

            var output = new List<string>();
            try
            {
                foreach (string subkey in Key.GetSubKeyNames())
                {
                    var tmp = Registry.GetValue(Key + @"\" + subkey, "RemotePath", null);

                    output.Add(subkey + "," + tmp.ToString());
                    
                }
            }
            catch { return null; }

            return output;
        }
    }
}
