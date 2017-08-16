using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetworkDrives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDrives.Tests
{
	[TestClass()]
	public class NetworkDrivesTests
	{
		[TestMethod()]
		public void checkAccessSource()
		{
			NetworkDrives netDrive = new NetworkDrives();
			netDrive.OnLine = true;
			string checkme = @"C:\Users\Jwulf";
			Assert.IsTrue(netDrive.checkAccess(checkme, true));
		}
		[TestMethod()]
		public void checkAccessDestination()
		{
			NetworkDrives netDrive = new NetworkDrives();
			netDrive.OnLine = true;
			string checkme = @"C:\Users\Jwulf\Desktop";
			Assert.IsTrue(netDrive.checkAccess(checkme));
		}
		[TestMethod()]
		public void checkAccessSourceOffline()
		{
			NetworkDrives netDrive = new NetworkDrives();
			netDrive.OnLine = false;
			string checkme = @"C:\Users\Jwulf";
			Assert.IsTrue(netDrive.checkAccess(checkme, true));
		}
		[TestMethod()]
		public void checkAccessDestinationOffline()
		{
			NetworkDrives netDrive = new NetworkDrives();
			netDrive.OnLine = false;
			string checkme = @"C:\Users\Jwulf\Desktop";
			Assert.IsTrue(netDrive.checkAccess(checkme));
		}



		[TestMethod()]
		public void BadcheckAccessSource()
		{
			NetworkDrives netDrive = new NetworkDrives();
			netDrive.OnLine = true;
			string checkme = @"this is not a path";
			Assert.IsFalse(netDrive.checkAccess(checkme, true));
		}
		[TestMethod()]
		public void BadcheckAccessDestination()
		{
			NetworkDrives netDrive = new NetworkDrives();
			netDrive.OnLine = true;
			string checkme = @"C:\Users\Jwulf\nowhere";
			Assert.IsFalse(netDrive.checkAccess(checkme));
		}
		[TestMethod()]
		public void BadcheckAccessSourceOffline()
		{
			NetworkDrives netDrive = new NetworkDrives();
			netDrive.OnLine = false;
			string checkme = @"C:\Users\noprofile";
			Assert.IsFalse(netDrive.checkAccess(checkme, true));
		}
		[TestMethod()]
		public void BadcheckAccessDestinationOffline()
		{
			NetworkDrives netDrive = new NetworkDrives();
			netDrive.OnLine = false;
			string checkme = @"C:\wookiee";
			Assert.IsFalse(netDrive.checkAccess(checkme));
		}
	}
}