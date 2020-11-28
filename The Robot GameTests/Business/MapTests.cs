using Microsoft.VisualStudio.TestTools.UnitTesting;
using The_Robot_Game.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.MementoNS;
using The_Robot_Game.Business.CargoNS;

namespace The_Robot_Game.Business.Tests
{
	[TestClass()]
	public class MapTests
	{
		[TestMethod()]
		public void CreateMementoTest_MementoCreated_ShouldBeMapMemento()
		{
			//Arrange
			Map map = new Map();

			//Act
			IMemento result = map.CreateMemento();

			//Assert
			Assert.IsInstanceOfType(result, typeof(MapMemento));

		}

		[TestMethod()]
		public void CreateCargosTest_AddCargosToCargoList_AllInstancesShouldBeCargo()
		{
			//Arrange
			Map map = new Map();

			//Act
			map.CreateCargos();

			//Assert
			CollectionAssert.AllItemsAreInstancesOfType(map.Cargos, typeof(Cargo));
		}
	}
}