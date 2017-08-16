using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void SetSourceToNothing()
		{
			NetworkDrives.NetworkDrives netDrive = new NetworkDrives.NetworkDrives();

			netDrive.Source = "";

			Assert.IsTrue(netDrive.ErrorLevel > 0);
		}
		[TestMethod]
		public void SetSourceToUnLive()
		{
			NetworkDrives.NetworkDrives netDrive = new NetworkDrives.NetworkDrives();

			netDrive.Source = @"\\LT490605\C$\Users\someone";

			Assert.IsTrue(netDrive.ErrorLevel > 0);
		}
		[TestMethod]
		public void SetSourceTolocal()
		{
			NetworkDrives.NetworkDrives netDrive = new NetworkDrives.NetworkDrives();

			netDrive.Source = @"C:\Users\Jwulf";

			Assert.AreEqual(netDrive.ErrorLevel, 0);
		}
		[TestMethod]
		public void SetSourceToNetwork()
		{
			NetworkDrives.NetworkDrives netDrive = new NetworkDrives.NetworkDrives();

			netDrive.Source = @"\\LT327338\C$\Users\Jwulf";

			Assert.AreEqual(netDrive.ErrorLevel, 0);
		}

		[TestMethod]
		public void SetDestinationToNothing()
		{
			NetworkDrives.NetworkDrives netDrive = new NetworkDrives.NetworkDrives();

			netDrive.Destination = "";

			Assert.IsTrue(netDrive.ErrorLevel > 0);
		}
		[TestMethod]
		public void SetDestinationToUnLive()
		{
			NetworkDrives.NetworkDrives netDrive = new NetworkDrives.NetworkDrives();

			netDrive.Destination = @"\\LT490605\C$\Users\someone\desktop";

			Assert.IsTrue(netDrive.ErrorLevel > 0);
		}
		[TestMethod]
		public void SetDestinationTolocal()
		{
			NetworkDrives.NetworkDrives netDrive = new NetworkDrives.NetworkDrives();

			netDrive.Destination = @"C:\Users\Jwulf\Desktop";

			Assert.AreEqual(netDrive.ErrorLevel, 0);
		}
		[TestMethod]
		public void SetDestinationToNetwork()
		{
			NetworkDrives.NetworkDrives netDrive = new NetworkDrives.NetworkDrives();

			netDrive.Destination = @"\\LT327338\C$\Users\Jwulf\Desktop";

			Assert.AreEqual(netDrive.ErrorLevel, 0);
		}
	}
}
