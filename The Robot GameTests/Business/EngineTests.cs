using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Robot_Game.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.RobotNS;
using The_Robot_Game.Business.Exceptions;
using Moq;
using The_Robot_Game.Business.CommandNS;

namespace The_Robot_Game.Business.Tests
{
	[TestClass()]
	public class EngineTests
	{
		private Engine engine;

		[TestInitialize]
		public void TestInitialize()
		{
			engine = new Engine();
		}

		[TestMethod()]
		public void InitializeTest_RobotCreated_RobotTypeExpected()
		{
			//Act
			var result = engine.Initialize("Stub");

			//Assert
			Assert.IsInstanceOfType(result, typeof(Robot));
		}

		[TestMethod()]
		public void CommandExecuterTest_TheChoiceIsUndo_StringMessageOfExceptionShouldBeReturnedAsCommandHistoryIsEmpty()
		{
			//Arrange
			var robotMock = new Mock<Robot>();

			//Act
			//var mssg = engine.CommandExecuter(robotMock.Object, "Undo");

			//Assert
			//StringAssert.StartsWith(mssg, "Woah-woah-woah, don't hurry!");
		}

		[ExpectedException(typeof(System.FormatException))]
		[TestMethod()]
		public void CommandExecuterTest_InvalidChoiceEntered_FormatExceptionExpected()
		{
			//Arrange
			var robotMock = new Mock<Robot>();
			robotMock.Object.BatteryCharge = 100;

			//Act
			//engine.CommandExecuter(robotMock.Object, "hklhh");
		}
	}
}