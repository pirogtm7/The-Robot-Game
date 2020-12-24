using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.MementoNS;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CargoNS
{
	public abstract class Cargo
	{
		private string name;
		private int weight;
		private int value;
		private int distance;
		private int x;
		private int y;

		public string Name { get => name; set => name = value; }
		public int Weight { get => weight; set => weight = value; }
		public int Value { get => value; set => this.value = value; }
		//public int Distance { get => distance; set => distance = value; }
		public int X { get => x; set => x = value; }
		public int Y { get => y; set => y = value; }

		public Cargo()
		{
			Random random = new Random(Guid.NewGuid().GetHashCode());
			Weight = random.Next(1, 10);
			//Distance = random.Next(1, 10);
		}

		public abstract void Unpack(Robot r); 
	}
}
