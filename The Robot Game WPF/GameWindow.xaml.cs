using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using The_Robot_Game.Business;
using The_Robot_Game.Business.CargoNS;
using The_Robot_Game.Business.CommandNS;
using The_Robot_Game.Business.Exceptions;

namespace The_Robot_Game_WPF
{
	public partial class GameWindow : Window
	{
        Engine engine = new Engine();
        string name;

		const int robotSquareSize = 30; 
        RobotSquare robotSquare;
        List<CargoEllipse> cargoElls;
        int cargosAmount = 3;

        public enum RobotDirection { Left, Right, Up, Down};
        RobotDirection robotDirection;

        private Random rnd = new Random();

        public GameWindow(string name)
		{
			InitializeComponent();
            this.name = name;
		}

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			DrawGameArea();
            StartNewGame();
		}

		private void DrawGameArea()
		{
            bool doneDrawingBackground = false;
            int nextX = 0, nextY = 0;
            int rowCounter = 0;
            bool nextIsOdd = false;

            while (doneDrawingBackground == false)
            {
                Rectangle rect = new Rectangle
                {
                    Width = robotSquareSize,
                    Height = robotSquareSize,
                    Fill = nextIsOdd ? Brushes.White : Brushes.Black
                };
                GameArea.Children.Add(rect);
                Canvas.SetTop(rect, nextY);
                Canvas.SetLeft(rect, nextX);

                nextIsOdd = !nextIsOdd;
                nextX += robotSquareSize;
                if (nextX >= GameArea.ActualWidth)
                {
                    nextX = 0;
                    nextY += robotSquareSize;
                    rowCounter++;
                    nextIsOdd = (rowCounter % 2 != 0);
                }

                if (nextY >= GameArea.ActualHeight)
                    doneDrawingBackground = true;
            }
        }
        private void DrawRobot()
        {
            robotSquare.UiElement = new Rectangle()
            {
                Width = robotSquareSize,
                Height = robotSquareSize,
                Fill = Brushes.Green
            };
            GameArea.Children.Add(robotSquare.UiElement);
            Canvas.SetTop(robotSquare.UiElement, robotSquare.Position.Y);
            Canvas.SetLeft(robotSquare.UiElement, robotSquare.Position.X);
        }

        private void MoveRobot()
        {
            GameArea.Children.Remove(robotSquare.UiElement);

            double nextX = robotSquare.Position.X;
            double nextY = robotSquare.Position.Y;
            switch (robotDirection)
            {
                case RobotDirection.Left:
                    nextX -= robotSquareSize;
                    break;
                case RobotDirection.Right:
                    nextX += robotSquareSize;
                    break;
                case RobotDirection.Up:
                    nextY -= robotSquareSize;
                    break;
                case RobotDirection.Down:
                    nextY += robotSquareSize;
                    break;
            }

            robotSquare.Position = new Point(nextX, nextY);

            try
            { 
                engine.MoveCommandExecuter();
            }
            catch (BatteryEmptyException e)
            {
                robotSquare.Robot.BatteryCharge = 0;
                UpdateGameStatus();
                MessageBox.Show(e.Message +
                    $"\nYour score: {robotSquare.Robot.TotalMoney}");
                this.Close();
            }

            robotSquare.Robot.X = (int)robotSquare.Position.X;
            robotSquare.Robot.Y = (int)robotSquare.Position.Y;
            DrawRobot();
            UpdateGameStatus();
        }

        private void StartNewGame()
        {
            var robot = engine.Initialize(name);

            robotSquare = new RobotSquare(robot)
            {
                Position = new Point(robotSquareSize * 5,
                    robotSquareSize * 5),
            };
            robotSquare.Robot.X = (int)robotSquare.Position.X;
            robotSquare.Robot.Y = (int)robotSquare.Position.Y;

            DrawRobot();

            UpdateGameStatus();

            cargoElls = new List<CargoEllipse>();

            for (int i = 1; i<= cargosAmount; i++)
            {
                CreateCargoEllipse();
                DrawCargo();
            }
        }

        private Point GetNextCargoPosition()
        {
            int maxX = Convert.ToInt32(GameArea.ActualWidth / robotSquareSize);
            int maxY = Convert.ToInt32(GameArea.ActualHeight / robotSquareSize);
            int cargoX = rnd.Next(0, maxX) * robotSquareSize;
            int cargoY = rnd.Next(0, maxY) * robotSquareSize;

            foreach(CargoEllipse cargo in cargoElls)
            {
                if ((robotSquare.Position.X == cargoX && robotSquare.Position.Y == cargoY)
                    || (cargo.Position.X == cargoX && cargo.Position.Y == cargoY))
                {
                    return GetNextCargoPosition();
                }
            }
            return new Point(cargoX, cargoY);
        }

        private void DrawCargo()
        {
            var cargoEllipse = cargoElls[cargoElls.Count - 1];
            Canvas.SetTop(cargoEllipse.UiElement, cargoEllipse.Position.Y);
            Canvas.SetLeft(cargoEllipse.UiElement, cargoEllipse.Position.X);

            Canvas.SetTop(cargoEllipse.Weight, cargoEllipse.Position.Y - 4);
            Canvas.SetLeft(cargoEllipse.Weight, cargoEllipse.Position.X + 5);
        }

        private void CreateCargoEllipse()
        {
            engine.Map.CreateCargos();
            var cargos = engine.Map.Cargos;

            CargoEllipse cargoEllipse = new CargoEllipse(cargos[cargos.Count - 1]);
            cargoEllipse.Position = GetNextCargoPosition();
            cargoEllipse.Cargo.X = (int)cargoEllipse.Position.X;
            cargoEllipse.Cargo.Y = (int)cargoEllipse.Position.Y;

            cargoEllipse.UiElement = new Ellipse()
            {
                Width = robotSquareSize,
                Height = robotSquareSize,
                Fill = cargoEllipse.Color
            };
            cargoElls.Add(cargoEllipse);
            GameArea.Children.Add(cargoEllipse.UiElement);
            GameArea.Children.Add(cargoEllipse.Weight);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    robotDirection = RobotDirection.Up;
                    MoveRobot();
                    break;
                case Key.Down:
                    robotDirection = RobotDirection.Down;
                    MoveRobot();
                    break;
                case Key.Left:
                    robotDirection = RobotDirection.Left;
                    MoveRobot();
                    break;
                case Key.Right:
                    robotDirection = RobotDirection.Right;
                    MoveRobot();
                    break;
                case Key.Enter:
                    PickUpCargo();
                    break;
                case Key.U:
                    try
                    {
                        engine.UndoCommandExecuter();

                        GameArea.Children.Remove(robotSquare.UiElement);
                        robotSquare.Position = new Point (robotSquare.Robot.X,
                            robotSquare.Robot.Y);
                        DrawRobot();

                        foreach (CargoEllipse cargoEllipse in cargoElls.ToArray())
                        {
                            GameArea.Children.Remove(cargoEllipse.UiElement);
                            GameArea.Children.Remove(cargoEllipse.Weight);
                            cargoElls.Remove(cargoEllipse);
                        }

                        foreach (Cargo cargo in engine.Map.Cargos)
                        {
                            CargoEllipse cargoEllipse = new CargoEllipse(cargo);
                            cargoEllipse.Position = new Point(cargo.X, cargo.Y);
                            cargoEllipse.UiElement = new Ellipse()
                            {
                                Width = robotSquareSize,
                                Height = robotSquareSize,
                                Fill = cargoEllipse.Color
                            };
                            cargoElls.Add(cargoEllipse);
                            GameArea.Children.Add(cargoEllipse.UiElement);
                            GameArea.Children.Add(cargoEllipse.Weight);
                            DrawCargo();
                        }

                        UpdateGameStatus();
                    }
                    catch (CantUndoException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }

        private void PickUpCargo()
        {
            foreach(CargoEllipse cargo in cargoElls.ToArray())
            {
                if (robotSquare.Position.X == Canvas.GetLeft(cargo.UiElement)
                    && robotSquare.Position.Y == Canvas.GetTop(cargo.UiElement))
                {
                    try
                    {
                        engine.PickUpCommandExecuter(cargo.Cargo);
                    }
                    catch (CargoTooHeavyException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    catch (FailedToEncodeException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    catch (ToxicHitException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    catch (BatteryEmptyException e)
                    {
                        robotSquare.Robot.BatteryCharge = 0;
                        UpdateGameStatus();
                        MessageBox.Show(e.Message +
                            $"\nYour score: {robotSquare.Robot.TotalMoney}");
                        this.Close();
                    }
                    finally
                    {
                        GameArea.Children.Remove(cargo.UiElement);
                        GameArea.Children.Remove(cargo.Weight);
                        engine.Map.Cargos.Remove(cargo.Cargo);
                        cargoElls.Remove(cargo);
                        CreateCargoEllipse();
                        DrawCargo();
                        UpdateGameStatus();
                    }
                }
            }
        }

        private void UpdateGameStatus()
        {
            GameStatsLabel.Content = $"Name: {engine.Robot.Name}\nType: {engine.Robot.RType}\n" +
                $"Cargo capacity: {engine.Robot.CargoCapacity}\nBattery charge: {engine.Robot.BatteryCharge}\n" +
                $"Money: {engine.Robot.TotalMoney}.";
        }
    }
}
