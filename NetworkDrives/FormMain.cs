using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkDrives
{
	public partial class FormMain : Form
	{
		NetworkDrives NetDrives = new NetworkDrives();

		public FormMain()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            NTuserDat.Unload("OldUser");
            //set defaults
            if (Environment.GetCommandLineArgs().Length > 2)
			{
				/*string checkme = "";
				foreach (string arg in Environment.GetCommandLineArgs())
				{
					checkme = checkme + arg + Environment.NewLine;
				}
				MessageBox.Show(checkme);// */

				Source.Text = @"\\" + Environment.GetCommandLineArgs()[1] + @"\C$\Users\" + Environment.GetCommandLineArgs()[2];
				destination.Text = @"\\" + Environment.GetCommandLineArgs()[1] + @"\C$\Users\" + Environment.GetCommandLineArgs()[2] + @"\Desktop";
				checkBox1.Checked = false;
			}
			else
			{
				Source.Text = @"C:\Users\" + Environment.UserName;
				destination.Text = @"C:\Users\" + Environment.UserName + @"\Desktop";
				checkBox1.Checked = true;
			}

            //if (!NetDrives.CheckCleanup())
            //{
            //    //MessageBox.Show("Old data from last transfer is still in registry. Restart program to send another attempt at removal. If still fails restart your computer.");
            //    Application.Exit();
            //}

        }
		private void Form1_unLoad(object sender, EventArgs e)
		{
			//NetDrives.cleanup();
			NTuserDat.Unload("OldUser");
			//MessageBox.Show("Registry cleanup complete.");
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				NetDrives.OnLine = true;
			}
			else
			{
				NetDrives.OnLine = false;
			}
		}

		private void Source_TextChanged(object sender, EventArgs e)
		{
			NetDrives.Source = Source.Text;
		}

		private void buttonBrowseSource_Click(object sender, EventArgs e)
		{
			Source.Text = browseFolder(Source.Text);
		}

		private void destination_TextChanged(object sender, EventArgs e)
		{
			NetDrives.Destination = destination.Text;
		}

		private void buttonBrowseDestination_Click(object sender, EventArgs e)
		{
			destination.Text = browseFolder(destination.Text, true);
		}

		private void buttonSubmit_Click(object sender, EventArgs e)
		{
			MessageBox.Show(NetDrives.Run());
		}

		/// <summary>
		/// Returns a string from the folder browser dialog box
		/// </summary>
		/// <param name="startPath">Sets where the dialog box navigates to start with.</param>
		/// <param name="newFolder">Makes the new folder option available if true.</param>
		/// <returns></returns>
		private string browseFolder(string startPath)
		{
			return browseFolder(startPath, false);
		}
		/// <summary>
		/// Returns a string from the folder browser dialog box
		/// </summary>
		/// <param name="startPath">Sets where the dialog box navigates to start with.</param>
		/// <param name="newFolder">Makes the new folder option available if true.</param>
		/// <returns></returns>
		private string browseFolder(string startPath, bool newFolder)
		{
			FolderBrowserDialog tempvar = new FolderBrowserDialog();
			tempvar.ShowNewFolderButton = newFolder;
			tempvar.SelectedPath = startPath;
			DialogResult result = tempvar.ShowDialog();
			if (result == DialogResult.OK)
			{
				return tempvar.SelectedPath;
			}
			else
			{
				return startPath;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//
			NetDrives.cleanup();
		}
	}
}
