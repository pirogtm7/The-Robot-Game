using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.Exceptions;
using The_Robot_Game.Business.MementoNS;
using The_Robot_Game.Exceptions;

namespace The_Robot_Game.Business.RobotNS
{
	public abstract class Robot
	{
		private string name;
		private string rType;
		private int batteryCharge;
		private int cargoCapacity;
		private int totalMoney;

		public string Name { get => name; set => name = value; }
		public string RType { get => rType; set => rType = value; }
		public int BatteryCharge { get => batteryCharge; set => batteryCharge = value; }
		public int CargoCapacity { get => cargoCapacity; set => cargoCapacity = value; }
		public int TotalMoney { get => totalMoney; set => totalMoney = value; }

		public void Discharge(int num)
		{
			BatteryCharge -= num;
		}

		public void PickUp(Cargo c)
		{
			Discharge(c.Distance);
			BatteryCheck();
			if(CargoCapacity >= c.Weight)
			{
				c.Unpack(this);
			}
			else
			{
				throw new CargoTooHeavyException("They say there's no wrong choice. " +
				"But you have just made one!\n" +
				"This cargo is too heavy. You have just waisted your power!");
			}
		}

		public void BatteryCheck()
		{
			if (BatteryCharge < 0)
			{
				throw new BatteryEmptyException("The battery is empty! Game over.");
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
	}
}
