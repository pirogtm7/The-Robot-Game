using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Business.RobotNS
{
	public class RobotNerd : Robot
	{
		public RobotNerd()
		{
			RType = "Nerd";
			CargoCapacity = 8;
			BatteryCharge = 90;
		}
	}
}
