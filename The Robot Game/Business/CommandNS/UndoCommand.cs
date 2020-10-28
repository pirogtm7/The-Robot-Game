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
		public UndoCommand(Engine engine,
			Robot robot, Map mc) : base(engine, robot, mc)
		{

		}

		public override bool Execute()
		{
			Command c = CommandHistory.Pop();
			if (c != null)
			{
				c.Undo();
			}
			//engine.Undo();
			return false;
		}
	}
}
