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
	public class WorkerCreatorTests
	{
		[TestMethod()]
		public void FactoryMethodTest_ReturnsNewRobot_RobotTypeShouldBeWorker()
		{
			//Arrange
			var workerCreator = new WorkerCreator();

			//Act
			Robot robotCreated = workerCreator.FactoryMethod();

			//Assert
			Assert.IsInstanceOfType(robotCreated, typeof(RobotWorker));
		}
	}
}