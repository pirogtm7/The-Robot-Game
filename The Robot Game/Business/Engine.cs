using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.CommandNS;
using The_Robot_Game.Business.Exceptions;
using The_Robot_Game.Business.RobotNS;
using The_Robot_Game.Exceptions;

namespace The_Robot_Game.Business
{

	public class Engine
	{
		private Map map;
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
			return robot;
		}

		public void MainLoop(Robot robot)
		{
			map = new Map();

			while (!gameOver)
			{
				try
				{
					string choice;

					Console.Clear();
					GetStats();
					Console.WriteLine("You see some cargos.");
					GetCargoInfo();
					Console.Write("Please make choice: 1, 2, 3, Undo: ");

					choice = Console.ReadLine();

					if (choice == "Undo")
					{
						try
						{
							new UndoCommand(robot, map).Execute();
						}
						catch (CantUndoException e)
						{
							ErrorMessage(e);
						}
					}
					else if (choice == "1" || choice == "2" || choice == "3")
					{
						try
						{
							new PickUpCommand(robot, map,
							map.Cargos[Convert.ToInt32(choice) - 1]).Execute();
						}
						catch (CargoTooHeavyException e)
						{
							ErrorMessage(e);

						}
						catch (FailedToEncodeException e)
						{
							ErrorMessage(e);

						}
						catch (ToxicHitException e)
						{
							ErrorMessage(e);
						}
						finally
						{
							map.CreateCargos();
						}
					}
					else
					{
						throw new WrongInputException("Please enter a valid value!");
					}
				}
				catch(WrongInputException e)
				{
					ErrorMessage(e);
				}
				catch (BatteryEmptyException e)
				{
					gameOver = true;
					ErrorMessage(e);
				}
			}
			Console.Clear();
			Console.WriteLine($"Your score: {robot.TotalMoney}");
			Console.ReadKey();
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
			foreach (Cargo c in map.Cargos)
			{
				Console.WriteLine($"Cargo {i}, name = {c.Name}, " +
					$"value = {c.Value}, weight = {c.Weight}, " +
					$"distance = {c.Distance}");
				i ++;
			}
		}

		public void ErrorMessage(Exception e)
		{
			Console.WriteLine(e.Message);
			Console.ReadKey();
		}
	}
}
