using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Business.CommandNS
{
	public class CommandHistory
	{
		private List<Command> history = new List<Command>();

		public void Push(Command c)
		{
			history.Add(c);
		}

		public Command Pop()
		{
			return history[history.Count - 1];
		}
	}
}
