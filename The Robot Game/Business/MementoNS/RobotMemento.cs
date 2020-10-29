using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.MementoNS
{
	public class RobotMemento : IMemento
	{
		private Robot robot;
		private int batteryCharge, cargoCapacity,
			totalMoney;

		public RobotMemento(Robot robot, int batteryCharge,
			int cargoCapacity, int totalMoney)
		{
			this.robot = robot;
			this.batteryCharge = batteryCharge;
			this.cargoCapacity = cargoCapacity;
			this.totalMoney = totalMoney;
		}

		public void Restore()
		{
			robot.BatteryCharge = batteryCharge;
			robot.CargoCapacity = cargoCapacity;
			robot.TotalMoney = totalMoney;
		}
	}
}
