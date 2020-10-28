using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game
{
	class Program
	{
		static void Main()
		{
			Engine engine = new Engine();
			Robot robot = engine.Initialize();
			engine.MainLoop(robot);
		}
	}
}
