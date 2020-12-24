//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Mail;
//using System.Text;
//using System.Threading.Tasks;
//using The_Robot_Game.Business;
//using The_Robot_Game.Business.CargoNS;
//using The_Robot_Game.Business.Exceptions;
//using The_Robot_Game.Business.RobotNS;

//namespace The_Robot_Game.Presentation
//{
//	public class ConsoleHandler
//	{
//		private Engine engine = new Engine();

//		public Robot IntializeHandler()
//		{
//			Console.Write("This is 'The Robot Game'. " +
//				"Please enter your name: ");
//			string name = Console.ReadLine();
//			return engine.Initialize(name);
//		}

//		public void MainLoopHandler(Robot robot)
//		{
//			while (!engine.GameOver)
//			{
//				try
//				{
//					Console.Clear();
//					GetStats();
//					Console.WriteLine("You see some cargos.");
//					GetCargoInfo();
//					Console.Write("Please make choice: 1, 2, 3, Undo: ");

//					string choice = Console.ReadLine();
//					if (choice == "Undo" || choice == "1" || choice == "2" || choice == "3")
//					{
//						string message = engine.CommandExecuter(robot, choice);
//						if (message != null)
//						{
//							ErrorMessage(message);
//						}
//					}
//					else
//					{
//						throw new WrongInputException("Please enter a valid value!");
//					}
//				}
//				catch (WrongInputException e)
//				{
//					ErrorMessage(e.Message);
//				}
//				catch (BatteryEmptyException e)
//				{
//					engine.GameOver = true;
//					ErrorMessage(e.Message);
//				}
//			}
//			Console.Clear();
//			Console.WriteLine($"Your score: {robot.TotalMoney}");
//			Console.ReadKey();
//		}

//		public void GetStats()
//		{
//			Console.WriteLine($"Your robot stats: name - {engine.Robot.Name}, type - {engine.Robot.RType}, " +
//				$"cargo capacity - {engine.Robot.CargoCapacity}, battery charge - {engine.Robot.BatteryCharge}, " +
//				$"money - {engine.Robot.TotalMoney}.");
//		}

//		public void GetCargoInfo()
//		{
//			int i = 1;
//			foreach (Cargo c in engine.Map.Cargos)
//			{
//				Console.WriteLine($"Cargo {i}, name = {c.Name}, " +
//					$"value = {c.Value}, weight = {c.Weight}, ");
//				i++;
//			}
//		}
		
//		public void ErrorMessage(string message)
//		{
//			Console.WriteLine(message);
//			Console.ReadKey();
//		}
//	}
//}
