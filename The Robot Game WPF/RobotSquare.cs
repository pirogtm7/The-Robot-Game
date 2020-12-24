using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game_WPF
{
	public class RobotSquare
	{
		public UIElement UiElement { get; set; }
		public Point Position { get; set; }
		public Robot Robot { get; set; }

		public RobotSquare()
		{

		}

		public RobotSquare(Robot robot)
		{
			Robot = robot;
		}
	}
}
