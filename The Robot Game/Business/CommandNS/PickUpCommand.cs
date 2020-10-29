using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CommandNS
{
	public class PickUpCommand : Command
	{
		private Cargo cargo;
		public PickUpCommand(Robot robot, Map map, 
			Cargo cargo) : base(robot, map)
		{
			this.cargo = cargo;
		}

		public override bool Execute()
		{
			MakeBackup();
			CommandHistory.Push(this);

			robot.PickUp(cargo);
			return true;
		}
	}
}
