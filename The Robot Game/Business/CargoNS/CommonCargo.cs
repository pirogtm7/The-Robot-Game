using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CargoNS
{
	public class CommonCargo : Cargo
	{
		public CommonCargo()
		{
			Name = "Common";
			Value = Weight * 3;
		}

		public override void Unpack(Robot r) 
		{
			r.Discharge(Weight);
			r.BatteryCheck();
			r.EarnMoney(Value);
		}
	}
}
