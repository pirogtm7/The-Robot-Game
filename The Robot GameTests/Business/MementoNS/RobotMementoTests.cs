using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Robot_Game.Business.MementoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.MementoNS.Tests
{
	[TestClass()]
	public class RobotMementoTests
	{
		[TestMethod()]
		public void RestoreTest_CreateRobotAndChangeItThenRestore_RobotMustBeRestored()
		{
			// Arrange
			var robotMock1 = new Mock<Robot>();
			var robot1 = robotMock1.Object;
			robot1.BatteryCharge = 60;
			robot1.CargoCapacity = 7;
			robot1.TotalMoney = 80;

			var robotMock2 = new Mock<Robot>();
			var robot2 = robotMock2.Object;
			robot2.BatteryCharge = 60;
			robot2.CargoCapacity = 7;
			robot2.TotalMoney = 80;

			// Act
			var rm = robot1.CreateMemento();
			robot1.TotalMoney = 85;
			rm.Restore();

			// Assert
			Assert.AreEqual(robot2.TotalMoney, robot1.TotalMoney);
		}
	}
}