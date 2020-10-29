using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Business.Exceptions
{
	public class ToxicHitException : Exception
	{
		public ToxicHitException(string message) : base(message)
		{

		}
	}
}
