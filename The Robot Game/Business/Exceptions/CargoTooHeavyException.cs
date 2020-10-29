using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Business.Exceptions
{
	public class CargoTooHeavyException : Exception
	{
		public CargoTooHeavyException(string message) : base(message)
		{

		}
	}
}
