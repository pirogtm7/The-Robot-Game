using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Business.Exceptions
{
	public class CantUndoException : Exception
	{
		public CantUndoException(string message) : base(message)
		{

		}
	}
}
