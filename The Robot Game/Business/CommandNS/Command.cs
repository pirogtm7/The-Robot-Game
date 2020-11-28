using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.MementoNS;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CommandNS
{
	public abstract class Command
	{
		protected Robot robot;
		protected Map map;
		private IMemento mapMemento, robotMemento;

		public Command()
		{

		}

		public Command(Robot robot,
			Map map)
		{
			this.robot = robot;
			this.map = map;
		}

		public void MakeBackup()
		{
			mapMemento = map.CreateMemento();
			robotMemento = robot.CreateMemento();
		}

		public void Undo()
		{
			mapMemento.Restore();
			robotMemento.Restore();
		}

		public abstract void Execute();
	}
}
