using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;

namespace The_Robot_Game.Business.MementoNS
{
	public class MapMemento : IMemento
	{
		private Map map;
		private List<Cargo> cargos = new List<Cargo>();

		public List<Cargo> Cargos { get => cargos; set => cargos = value; }

		public MapMemento(Map map)
		{
			this.map = map;
			FillCargos();
		}


		public void FillCargos()
		{
			foreach (Cargo c in map.Cargos)
			{
				cargos.Add(c);
			}
		}

		public void Restore()
		{
			map.Cargos = cargos;
		}
	}
}
