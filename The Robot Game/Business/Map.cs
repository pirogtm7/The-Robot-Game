using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.MementoNS;

namespace The_Robot_Game.Business
{
	public class Map
	{
		private List<Cargo> cargos = new List<Cargo>();

		public List<Cargo> Cargos { get { return cargos; } set { cargos = value; }  }

		public Map()
		{
			CreateCargos();
		}

		public IMemento CreateMemento()
		{
			return new MapMemento(this);
		}

		public void CreateCargos()
		{
			Cargos.Clear();
			for (int i = 0; i < 3; i++)
			{
				Cargo cargo = new CommonCargo();

				Random random = new Random(Guid.NewGuid().GetHashCode());
				int chance = random.Next(1, 11);

				if (chance <= 2)
				{
					cargo = new DecoratorToxic(cargo);
				}
				else if (chance > 2 && chance <= 4)
				{
					cargo = new DecoratorEncoded(cargo);
				}
				Cargos.Add(cargo);
			}
		}
	}
}
