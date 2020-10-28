using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Robot_Game.Business.CommandNS
{
	public static class CommandHistory
	{
		//firs in last out, optimization
		private static Stack<Command> history = new Stack<Command>();

		public static void Push(Command c)
		{
			history.Push(c);
		}

		public static Command Pop()
		{
			if (history.Count() > 0)
			{
				return history.Pop();
			}
			return null;
			//TODO: throw exception
		}
	}
}
