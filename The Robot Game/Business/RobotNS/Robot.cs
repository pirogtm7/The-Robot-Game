﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.Exceptions;
using The_Robot_Game.Business.MementoNS;

namespace The_Robot_Game.Business.RobotNS
{
	public abstract class Robot
	{
		private string name;
		private string rType;
		private int batteryCharge;
		private int cargoCapacity;
		private int totalMoney;
		private int x;
		private int y;

		public string Name { get => name; set => name = value; }
		public string RType { get => rType; set => rType = value; }
		public int BatteryCharge { get => batteryCharge; set => batteryCharge = value; }
		public int CargoCapacity { get => cargoCapacity; set => cargoCapacity = value; }
		public int TotalMoney { get => totalMoney; set => totalMoney = value; }
		public int X { get => x; set => x = value; }
		public int Y { get => y; set => y = value; }

		public void Discharge(int num)
		{
			BatteryCharge -= num;
		}

		public void Move()
		{
			Discharge(1);
			BatteryCheck();
		}

		public void PickUp(Cargo c)
		{
			//Discharge(c.Distance);
			//BatteryCheck();
			if (CargoCapacity >= c.Weight)
			{
				c.Unpack(this);
			}
			else
			{
				throw new CargoTooHeavyException("They say there's no wrong choice. " +
				"But you have just made one!\n" +
				"This cargo is too heavy. Keep on looking for a lighter one!");
			}
		}

		public void BatteryCheck()
		{
			if (BatteryCharge <= 0)
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
				CargoCapacity, TotalMoney, X, Y);
		}
	}
}
