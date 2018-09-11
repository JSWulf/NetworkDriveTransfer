using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetMappedDrives
{
    public class NetworkDrive
    {
        NetworkDrive()
        {
            //donothing
        }
        NetworkDrive(string letter, string path)
        {
            DriveLetter = letter;
            Path = path;
        }
        public string DriveLetter { get; set; }
        public string Path { get; set; }
    }
}
