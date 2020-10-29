using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CommandNS
{
	public class UndoCommand : Command
	{
		public UndoCommand(Robot robot, Map map) : base(robot, map)
		{

		}

		public override bool Execute()
		{
			Command c = CommandHistory.Pop();
			c.Undo();
			//engine.Undo();
			return false;
		}
	}
}
