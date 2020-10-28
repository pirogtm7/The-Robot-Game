﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.MementoNS;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CommandNS
{
	public abstract class Command
	{
		protected Engine engine;
		protected Robot robot;
		protected Map mc;
		private IMemento mapMemento, robotMemento;

		public Command(Engine engine, Robot robot,
			Map mc)
		{
			this.engine = engine;
			this.robot = robot;
			this.mc = mc;
		}

		public void MakeBackup()
		{
			mapMemento = mc.CreateMemento();
			robotMemento = robot.CreateMemento();
		}

		public void Undo()
		{
			mapMemento.Restore();
			robotMemento.Restore();
		}

		public abstract bool Execute();
	}
}
