using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Robot_Game.Business.MementoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using The_Robot_Game.Business.CargoNS;

namespace The_Robot_Game.Business.MementoNS.Tests
{
	[TestClass()]
	public class MapMementoTests
	{
		[TestMethod()]
		public void FillCargosTest_AddCargoToMap_MementoShouldContainTheSameCargo()
		{
			// Arrange
			var cargoMock = new Mock<Cargo>();
			Map map = new Map();
			map.Cargos.Add(cargoMock.Object);

			// Act
			MapMemento mm = new MapMemento(map);

			//Assert
			CollectionAssert.AreEqual(map.Cargos, mm.Cargos);
		}
	}
}