using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using The_Robot_Game.Business.CargoNS;

namespace The_Robot_Game_WPF
{
	public class CargoEllipse
	{
		public UIElement UiElement { get; set; }
		public Point Position { get; set; }
		public SolidColorBrush Color { get; set; }
		public Label Weight { get; set; }
		public Cargo Cargo { get; set; }

		public CargoEllipse()
		{
			Color = Brushes.Orange;
			Weight = new Label
			{
				Content = "0",
				FontSize = 20
			};
		}

		public CargoEllipse(Cargo cargo)
		{
			Cargo = cargo;

			if (cargo.Name == "Common")
			{
				Color = Brushes.LightSlateGray;
			}
			if (cargo.Name == "Toxic")
			{
				Color = Brushes.Lime;
			}
			if (cargo.Name == "Encoded")
			{
				Color = Brushes.Blue;
			}

			Weight = new Label
			{
				Content = cargo.Weight.ToString(),
				FontSize = 20
			};
		}
	}
}
