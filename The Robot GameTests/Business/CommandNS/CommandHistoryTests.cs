using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Robot_Game.Business.CommandNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.Exceptions;
using Moq;

namespace The_Robot_Game.Business.CommandNS.Tests
{
	[TestClass()]
	public class CommandHistoryTests
	{

		[ExpectedException(typeof(CantUndoException))]
		[TestMethod()]
		public void PopTest_TryToPopElementFromEmptyStack_CantUndoExceptionExpected()
		{
			// Act
			CommandHistory.Pop();
		}

		[TestMethod()]
		public void PopTest_TryToPopElementFromNotEmptyStack_CommandObjectShouldBeReturned()
		{
			// Arrange
			var commandMock = new Mock<Command>();
			CommandHistory.Push(commandMock.Object);

			// Act
			var result = CommandHistory.Pop();

			// Assert
			Assert.AreEqual(result, commandMock.Object);
		}
	}
}