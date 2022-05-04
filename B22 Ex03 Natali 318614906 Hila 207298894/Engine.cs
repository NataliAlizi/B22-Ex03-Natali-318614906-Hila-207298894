using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    abstract public class Engine
    {
        public enum eFuelType
        {
            none, Soler, Octan95, Octan96, Octan98
        }

        public abstract void Refueling(Vehicle i_Vehicle, Engine.eFuelType i_WantedFuelType, float i_WantedAmountOfsomething);
        public abstract float CurrAmountOfFuelOrBattery();
    }
}
