using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Robot_Game.Business.CargoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.RobotNS;
using Moq;
using The_Robot_Game.Business.Exceptions;

namespace The_Robot_Game.Business.CargoNS.Tests
{
	[TestClass()]
	public class DecoratorToxicTests
	{
		[ExpectedException(typeof(ToxicHitException))]
		[TestMethod()]
		public void UnpackTest_CyborgAlwaysGetsHit10_CyborgBatteryChargeMustBe70()
		{
			// Arrange
			RobotCyborg rc = new RobotCyborg();
			rc.BatteryCharge = 80;
			var cargoMock = new Mock<Cargo>();
			int expected = 70;

			// Act
			DecoratorToxic dt = new DecoratorToxic(cargoMock.Object);
			dt.Weight = 10;
			dt.Unpack(rc);
			int result = rc.BatteryCharge;

			// Assert
			Assert.AreEqual(expected, result);
		}
	}
}