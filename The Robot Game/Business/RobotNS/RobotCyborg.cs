using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Business.RobotNS
{
	public class RobotCyborg : Robot
	{
		public RobotCyborg()
		{
			RType = "Cyborg";
			CargoCapacity = 9;
			BatteryCharge = 90;
		}
	}
}
