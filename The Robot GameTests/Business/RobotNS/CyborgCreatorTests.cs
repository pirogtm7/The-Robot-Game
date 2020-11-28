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
	public class CyborgCreatorTests
	{
		[TestMethod()]
		public void FactoryMethodTest_ReturnsNewRobot_RobotTypeShouldBeCyborg()
		{
			//Arrange
			var cyborgCreator = new CyborgCreator();

			//Act
			Robot robotCreated = cyborgCreator.FactoryMethod();

			//Assert
			Assert.IsInstanceOfType(robotCreated, typeof(RobotCyborg));
		}
	}
}