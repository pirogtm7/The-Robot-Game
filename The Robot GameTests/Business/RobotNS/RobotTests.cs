using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Robot_Game.Business.RobotNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using The_Robot_Game.Business.Exceptions;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.MementoNS;

namespace The_Robot_Game.Business.RobotNS.Tests
{
	[TestClass()]
	public class RobotTests
	{
		private Mock<Robot> robotMock;
		private Robot robot;

		[TestInitialize]
		public void TestInitialize()
		{
			robotMock = new Mock<Robot>()
			{
				CallBase = true
			};
			robot = robotMock.Object;
		}

		[TestMethod()]
		public void DischargeTest_BatteryDischargedFor10PercentFrom100_ShouldBe90()
		{
			//Arrange
			int expected = 90;
			int hit = 10;
			robot.BatteryCharge = 100;

			//Act
			robot.Discharge(hit);
			int result = robot.BatteryCharge;

			//Assert
			Assert.AreEqual(expected, result);
		}

		[ExpectedException(typeof(CargoTooHeavyException))]
		[TestMethod()]
		public void PickUpTest_CargoHeavy_CargoTooHeavyExceptionExpected()
		{
			//Arrange
			robot.BatteryCharge = 100;
			robot.CargoCapacity = 9;

			var cargoMock = new Mock<Cargo>();
			cargoMock.Object.Weight = 10;

			//Act
			robot.PickUp(cargoMock.Object);
		}

		[ExpectedException(typeof(BatteryEmptyException))]
		[TestMethod()]
		public void BatteryCheckTest_BatteryIs0_BatteryEmptyExceptionExcpected()
		{
			//Arrange
			robot.BatteryCharge = 0;

			//Act
			robot.BatteryCheck();
		}

		[TestMethod()]
		public void EarnMoneyTest_Earns20From10_Expected30()
		{
			//Arrange
			int expected = 30;
			int money = 20;

			//Act
			robot.TotalMoney = 10;
			robot.EarnMoney(money);
			int result = robot.TotalMoney;

			//Assert
			Assert.AreEqual(expected, result);
		}

		[TestMethod()]
		public void CreateMementoTest_CreateMemento_MustBeRobotMemento()
		{
			//Act
			IMemento result = robot.CreateMemento();

			//Assert
			Assert.IsInstanceOfType(result, typeof(RobotMemento));
		}
	}
}