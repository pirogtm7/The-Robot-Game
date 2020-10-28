using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.CommandNS;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business
{
	public class Engine
	{
		private MapCreator mapCreator;
		private CommandHistory commandHistory;
		private Robot robot;
		private RobotCreator robotCreator;
		private bool gameOver;

		public bool GameOver { get => gameOver; set => gameOver = value; }

		public Robot Initialize()
		{
			Console.Write("This is 'The Robot Game'. " +
				"Please enter your name: ");
			string name = Console.ReadLine();

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
			GetStats();
			return robot;
		}

		public void MainLoop(Robot robot)
		{
			commandHistory = new CommandHistory();

			while (!gameOver)
			{
				string choice;
				mapCreator = new MapCreator();

				Console.WriteLine("You see some cargos.");
				GetCargoInfo();
				Console.Write("Please make choice: 1, 2, 3, Undo: ");

				choice = Console.ReadLine();

				if (choice == "Undo")
				{
					ExecuteCommand(new UndoCommand(this, robot, mapCreator,
						mapCreator.Cargos[Convert.ToInt32(choice) - 1]));
				}
				else if (choice == "1" || choice == "2" || choice == "3")
				{
					ExecuteCommand(new PickUpCommand(this, robot, mapCreator,
						mapCreator.Cargos[Convert.ToInt32(choice) - 1]));
				}
				GetStats();
			}
		}

		public void ExecuteCommand(Command c)
		{
			if(c.Execute())
			{
				commandHistory.Push(c);
			}
		}

		public void Undo()
		{
			Command c = commandHistory.Pop();
			if (c != null)
			{
				c.Undo();
			}
		}

		public void GetStats()
		{
			Console.WriteLine($"Your robot stats: name - {robot.Name}, type - {robot.RType}, " +
				$"cargo capacity - {robot.CargoCapacity}, battery charge - {robot.BatteryCharge}, " +
				$"money - {robot.TotalMoney}.");
		}

		public void GetCargoInfo()
		{
			int i = 1;
			foreach (Cargo c in mapCreator.Cargos)
			{
				Console.WriteLine($"Cargo {i}, name = {c.Name}, " +
					$"value = {c.Value}, weight = {c.Weight}, " +
					$"distance = {c.Distance}");
				i ++;
			}
		}
	}
}
