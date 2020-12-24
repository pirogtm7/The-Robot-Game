using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Business.RobotNS
{
	public class RobotWorker : Robot
	{
		public RobotWorker()
		{
			RType = "Worker"; 
			CargoCapacity = 9;
			BatteryCharge = 100;
		}
	}
}
