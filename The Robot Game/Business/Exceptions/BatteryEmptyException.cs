using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Exceptions
{
	public class BatteryEmptyException : Exception
	{
		public BatteryEmptyException(string message) : base(message)
		{

		}
	}
}
