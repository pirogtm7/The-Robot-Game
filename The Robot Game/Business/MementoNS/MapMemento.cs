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
		private Map _mc;
		private List<Cargo> cargos = new List<Cargo>();


		public MapMemento(Map mc)
		{
			_mc = mc;
			FillCargos(mc);
		}

		public void FillCargos(Map mc)
		{
			foreach (Cargo c in mc.Cargos)
			{
				cargos.Add(c);
			}
		}

		public void Restore()
		{
			_mc.Cargos = cargos;
			//foreach (Cargo c in cargos)
			//{
			//	_mc.Cargos.Add(c);
			//}
		}
	}
}
