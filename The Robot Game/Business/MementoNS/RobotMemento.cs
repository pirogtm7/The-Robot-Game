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
			totalMoney, x, y;

		public RobotMemento(Robot robot, int batteryCharge,
			int cargoCapacity, int totalMoney, int x, int y)
		{
			this.robot = robot;
			this.batteryCharge = batteryCharge;
			this.cargoCapacity = cargoCapacity;
			this.totalMoney = totalMoney;
			this.x = x;
			this.y = y;
		}

		public void Restore()
		{
			robot.BatteryCharge = batteryCharge;
			robot.CargoCapacity = cargoCapacity;
			robot.TotalMoney = totalMoney;
			robot.X = x;
			robot.Y = y;
		}
	}
}
