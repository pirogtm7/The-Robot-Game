using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Robot_Game.Business.RobotNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Business.RobotNS.Tests
{
	[TestClass()]
	public class NerdCreatorTests
	{
		[TestMethod()]
		public void FactoryMethodTest_ReturnsNewRobot_RobotTypeShouldBeNerd()
		{
			//Arrange
			var nerdCreator = new NerdCreator();

			//Act
			Robot robotCreated = nerdCreator.FactoryMethod();

			//Assert
			Assert.IsInstanceOfType(robotCreated, typeof(RobotNerd));
		}
	}
}