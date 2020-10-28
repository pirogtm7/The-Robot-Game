using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.MementoNS;

namespace The_Robot_Game.Business
{
	public interface IGameObject
	{
		IMemento CreateMemento();
	}
}
