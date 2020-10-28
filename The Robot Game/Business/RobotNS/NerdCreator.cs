using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Business.RobotNS
{
	public class NerdCreator : RobotCreator
	{
		public override Robot FactoryMethod()
		{
			return new RobotNerd();
		}
	}
}
