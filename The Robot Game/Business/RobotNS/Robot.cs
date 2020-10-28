using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.MementoNS;

namespace The_Robot_Game.Business.RobotNS
{
	public abstract class Robot : IGameObject
	{
		private string name;
		private string rType;
		private int batteryCharge;
		private int cargoCapacity;
		private int totalMoney;
		private int finalMoney;

		public string Name { get => name; set => name = value; }
		public string RType { get => rType; set => rType = value; }
		public int BatteryCharge { get => batteryCharge; set => batteryCharge = value; }
		public int CargoCapacity { get => cargoCapacity; set => cargoCapacity = value; }
		public int TotalMoney { get => totalMoney; set => totalMoney = value; }
		public int FinalMoney { get => finalMoney; set => finalMoney = value; }

		public void Discharge(int num)
		{
			BatteryCharge -= num;
		}

		public void PickUp(Cargo c, Engine engine)
		{
			Discharge(c.Distance);
			BatteryCheck(engine);
			if(CargoCapacity >= c.Weight)
			{
				c.Unpack(this, engine);
			}
			//exeption
		}

		public void BatteryCheck(Engine engine)
		{
			if (BatteryCharge < 0)
			{
				engine.GameOver = true;
				FinalMoney = TotalMoney;
			}
		}

		public void EarnMoney(int value)
		{
			TotalMoney += value;
		}

		public IMemento CreateMemento() 
		{
			return new RobotMemento(this, BatteryCharge,
				CargoCapacity, TotalMoney);
		}

		//public void SetBC(int batteryCharge)
		//{
		//	this.BatteryCharge = batteryCharge;
		//}

		//public void SetCC(int cargoCapacity)
		//{
		//	this.CargoCapacity = cargoCapacity;
		//}

		//public void SetTM(int totalMoney)
		//{
		//	this.TotalMoney = totalMoney;
		//}
	}
}
