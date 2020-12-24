using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.CommandNS;
using The_Robot_Game.Business.Exceptions;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business
{
	public class Engine
	{
		private Map map = new Map();
		private Robot robot;
		private RobotCreator robotCreator;
		private bool gameOver;


		public Robot Robot { get => robot; set => robot = value; }
		public Map Map { get => map; set => map = value; }
		public bool GameOver { get => gameOver; set => gameOver = value; }

		public Robot Initialize(string name)
		{
			Random random = new Random();
			int chance = random.Next(1, 11);
			if (chance <= 5)
			{
				robotCreator = new WorkerCreator();
			}
			else if (chance > 5 && chance <= 8)
			{
				robotCreator = new CyborgCreator();
			}
			else
			{
				robotCreator = new NerdCreator();
			}
			robot = robotCreator.FactoryMethod();
			robot.Name = name;
			return robot;
		}

		public void UndoCommandExecuter()
		{
			new UndoCommand(robot, map).Execute();
		}

		public void MoveCommandExecuter()
		{
			new MoveCommand(robot, map).Execute();
		}

		public void PickUpCommandExecuter(Cargo cargo)
		{
			new PickUpCommand(robot, map,
					cargo).Execute();
		}

		//public string CommandExecuter(Robot robot, string choice)
		//{
		//	if (choice == "Undo")
		//	{
		//		try
		//		{
		//			new UndoCommand(robot, map).Execute();
		//			return null;
		//		}
		//		catch (CantUndoException e)
		//		{
		//			return e.Message;
		//		}
		//	}
		//	else
		//	{
		//		try
		//		{
		//			new PickUpCommand(robot, map,
		//			map.Cargos[Convert.ToInt32(choice) - 1]).Execute();
		//			return null;
		//		}
		//		catch (CargoTooHeavyException e)
		//		{
		//			return e.Message;

		//		}
		//		catch (FailedToEncodeException e)
		//		{
		//			return e.Message;

		//		}
		//		catch (ToxicHitException e)
		//		{
		//			return e.Message;
		//		}
		//		finally
		//		{
		//			map.CreateCargos();
		//		}
		//	}
		//}
	}
}
