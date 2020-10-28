using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CargoNS
{
	public class DecoratorToxic : Decorator
	{
		public DecoratorToxic(Cargo cargo) : base(cargo)
		{
			Name = "Toxic";
			Value = Weight * 2;
		}

		public override void Unpack(Robot r, Engine engine)
		{
			r.Discharge(Weight);
			r.BatteryCheck(engine);
			if (r.GetType() == typeof(RobotCyborg))
			{
				r.Discharge(Weight);
				r.BatteryCheck(engine);
			}
			r.EarnMoney(Value);
		}
	}
}
