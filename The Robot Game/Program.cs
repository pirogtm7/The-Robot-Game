using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business;
using The_Robot_Game.Business.RobotNS;
using The_Robot_Game.Presentation;

namespace The_Robot_Game
{
	class Program
	{
		static void Main()
		{
			ConsoleHandler ch = new ConsoleHandler();
			ch.MainLoopHandler(ch.IntializeHandler());
		}
	}
}
