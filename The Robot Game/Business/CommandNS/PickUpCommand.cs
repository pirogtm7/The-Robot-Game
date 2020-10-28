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
		Cargo cargo;
		public PickUpCommand(Engine engine,
			Robot robot, Map mc, 
			Cargo cargo) : base(engine, robot, mc)
		{
			this.cargo = cargo;
		}

		public override bool Execute()
		{
			MakeBackup();
			CommandHistory.Push(this);

			robot.PickUp(cargo, engine);
			return true;
		}
	}
}
