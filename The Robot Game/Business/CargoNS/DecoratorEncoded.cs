using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CargoNS
{
	public class DecoratorEncoded : Decorator
	{
		public DecoratorEncoded(Cargo cargo) : base(cargo)
		{
			Name = "Encoded";
			Value = Weight * 5;
		}

		public override void Unpack(Robot r, Engine engine)
		{
			r.Discharge(Weight);
			r.BatteryCheck(engine);
			Random random = new Random();
			int chance = random.Next(1, 11);
			if (r.GetType() == typeof(RobotWorker))
			{
				if (chance == 1)
				{
					r.EarnMoney(Value);
				}
			}
			else if (r.GetType() == typeof(RobotCyborg))
			{
				if (chance <= 6)
				{
					r.EarnMoney(Value);
				}
			}
			else if (r.GetType() == typeof(RobotNerd))
			{
				r.EarnMoney(Value);
			}
			//сообщение о неудаче раскодировки
		}
	}
}
