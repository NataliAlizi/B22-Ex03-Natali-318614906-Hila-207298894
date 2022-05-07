using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageMeneger
    {
        public enum eVehicleType
        {
            Car = 1, Motorcycle, Truck
        }

        public Vehicle MakeNewVehicle(int i_NumberOfTypeVehicle)
        {
            if (i_NumberOfTypeVehicle == 1)
            {
                return new Car();
            }
            else if (i_NumberOfTypeVehicle == 2)
            {
                return new MotorCycle();
            }
            else
            {
                return new Truck();
            }
        }
    }
}
