using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.Exceptions;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CargoNS
{
	public class DecoratorToxic : Decorator
	{
		public DecoratorToxic(Cargo cargo) : base(cargo)
		{
			Name = "Toxic";
			Value = Weight * 5;
		}

		public override void Unpack(Robot r)
		{
			r.Discharge(Weight);
			r.BatteryCheck();
			if (r.GetType() == typeof(RobotCyborg))
			{
				r.Discharge(Weight);
				r.BatteryCheck();
				r.EarnMoney(Value);
				throw new ToxicHitException("Ouch! Your robot was hit by a toxic cargo!");
			}
			r.EarnMoney(Value);
		}
	}
}
