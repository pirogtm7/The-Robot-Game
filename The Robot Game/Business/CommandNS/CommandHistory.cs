using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.Exceptions;

namespace The_Robot_Game.Business.CommandNS
{
	public static class CommandHistory
	{
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
			throw new CantUndoException("Woah-woah-woah, don't hurry! " +
				"You are at the beginning of the game!\n" +
				"Pick up one cargo before you undo your move.");
		}
	}
}
