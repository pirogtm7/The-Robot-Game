using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Robot_Game.Business.RobotNS;

namespace The_Robot_Game.Business.CargoNS
{
	public abstract class Decorator : Cargo
	{
		protected Cargo wrapee;

		public Decorator(Cargo cargo)
		{
			this.wrapee = cargo;
		}

        public override void Unpack(Robot r, Engine engine)
        {
            wrapee.Unpack(r, engine);
        }
    }
}
