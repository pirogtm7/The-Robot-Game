using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Robot_Game.Business.CargoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CargoNS.Tests
{
	[TestClass()]
	public class DecoratorEncodedTests
	{

		[TestMethod()]
		public void UnpackTest_20MoneyAlwaysGainedByNerd_NerdMustHave20Money()
		{
			// Arrange
			RobotNerd rn = new RobotNerd();
			var cargoMock = new Mock<Cargo>();
			int expected = 20;

			// Act
			DecoratorEncoded de = new DecoratorEncoded(cargoMock.Object);
			de.Value = 20;
			de.Unpack(rn);
			int result = rn.TotalMoney;

			// Assert
			Assert.AreEqual(expected, result);
		}
	}
}