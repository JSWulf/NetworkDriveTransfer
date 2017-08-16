using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace NetworkDrives
{
	public class NetworkDrives //: NTuserDat
	{

		#region properties
		private string source;

		public string Source
		{
			get { return source; }
			set {  source = value;  }
		}

		private string destination;

		public string Destination
		{
			get { return destination; }
			set { destination = value; }
		}

		private bool onLine;

		public bool OnLine
		{
			get { return onLine; }
			set { onLine = value; }
		}

		private RegistryKey networkKey;

		public RegistryKey NetworkKey
		{
			get { return networkKey; }
			set { networkKey = value; }
		}

		private int errorLevel = 0;

		public int ErrorLevel
		{
			get { return errorLevel; }
			set { errorLevel = value; }
		}

		List<string> driveLetter = new List<string>();
		List<string> drivePath = new List<string>();

		#endregion


		/// <summary>
		/// Loads the NTuser.Dat file located at source and returns true if successful.
		/// </summary>
		/// <returns>Boolean if successful</returns>
		private RegistryKey loadDat()
		{
			NTuserDat.Load(Source + @"\NTUSER.DAT", "OldUser");

			if (!OnLine)
			{
				try
				{
					return Registry.Users.OpenSubKey(@"OldUser\Network");
				}
				catch
				{
					MessageBox.Show("Error loading NTUSER.DAT" + Environment.NewLine + "Using running system CurrentUser instead.");
					return Registry.CurrentUser.OpenSubKey("Network");
				}
			}
			else
			{
				return Registry.CurrentUser.OpenSubKey("Network");
			}
			
		}

		/// <summary>
		/// Runs the process of reading the network drives from registry and outputing a script file to add them on another computer
		/// </summary>
		/// <returns>string to output result message.</returns>
		public string Run()
		{
			//checkAccess
			if (OnLine && Source.StartsWith(@"\\"))
			{
				return "Cannot access a network path while the user is online..." + Environment.NewLine +
					"Either log the user off, or copy script file to that user account and run there.";
			}
			if (!checkAccess(source, true) || !checkAccess(destination)) {
				return "Error -- Unable to access Source, Destination, or NTUSER.DAT file.";
			}

			NetworkKey = loadDat();

			if (GetDrives(NetworkKey))
			{
				WriteScriptFile(Destination);
			}
			else
			{
				return "Error Getting network drives from registry or none exist.";
			}



			return "VBS file generated successfully.";
		}

		/// <summary>
		/// Checks to see if the directory exists. If it does not, exception alert will show at runtime.
		/// </summary>
		/// <param name="toCheck"></param>
		/// <returns>same as what goes in.</returns>
		public bool checkAccess(string toCheck) { return checkAccess(toCheck, false); }
		public bool checkAccess(string toCheck, bool checkNTDAT)
		{
			ErrorLevel = 1;
			if (Directory.Exists(toCheck))
			{
				ErrorLevel--;
			}
			else
			{
				if (toCheck != null && toCheck.Contains("$"))
				{
					if (Directory.Exists(toCheck.Remove(toCheck.IndexOf('$')+1)))
					{
						if (Directory.Exists(toCheck)) { ErrorLevel--; }
					}
				}
			}

			if (checkNTDAT && OnLine)
			{
				ErrorLevel++;
				if (File.Exists(toCheck + @"\NTUSER.DAT")) { ErrorLevel--; }
			}

			if (ErrorLevel > 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		/// <summary>
		/// Gets the network drive letters and paths
		/// </summary>
		/// <param name="Key"></param>
		/// <returns>returns true is successful</returns>
		private bool GetDrives(RegistryKey Key)
		{
			try
			{
				foreach (string subkey in Key.GetSubKeyNames())
				{
					var tmp = Registry.GetValue(Key + @"\" + subkey, "RemotePath", null);

					driveLetter.Add(subkey);
					drivePath.Add(tmp.ToString());
				}
			} catch { return false; }

			return true;
		}
		/// <summary>
		/// writes the script file
		/// </summary>
		/// <param name="dest">Output to Destination\NetworkDrives.vbs</param>
		private void WriteScriptFile(string dest)
		{
			List<string> FileOut = new List<string>();
			FileOut.Add("On Error Resume Next");
			FileOut.Add("Dim objNetwork");
			FileOut.Add("Set objNetwork = WScript.CreateObject(\"WScript.Network\")");

			for (int i = 0; i < driveLetter.Count; i++)
			{
				FileOut.Add("objNetwork.MapNetworkDrive \"" + driveLetter[i] + ":\", \"" + drivePath[i] + "\", true");
			}

			//File.AppendAllLines(dest + @"\NetworkDrives.vbs", FileOut);
			File.WriteAllLines(dest + @"\NetworkDrives.vbs", FileOut);
			FileOut.Clear();
			driveLetter.Clear();
			drivePath.Clear();
		}

		public void cleanup()
		{
			Registry.Users.Close();
			while (Registry.Users.OpenSubKey("OldUser") != null) {
				NTuserDat.Unload("OldUser");
			}

		}
	}
}
