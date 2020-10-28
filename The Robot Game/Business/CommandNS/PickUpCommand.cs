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
		public PickUpCommand(Engine engine,
			Robot robot, MapCreator mc, 
			Cargo cargo) : base(engine, robot, mc, cargo)
		{

		}

		public override bool Execute()
		{
			MakeBackup();
			robot.PickUp(cargo, engine);
			return true;
		}
	}
}
