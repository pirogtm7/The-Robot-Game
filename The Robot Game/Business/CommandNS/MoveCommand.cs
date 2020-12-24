using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CommandNS
{
	public class MoveCommand : Command
	{
		public MoveCommand(Robot robot, Map map) : base(robot, map)
		{
		}

		public override void Execute()
		{
			MakeBackup();
			CommandHistory.Push(this);

			robot.Move();
		}

	}
}
