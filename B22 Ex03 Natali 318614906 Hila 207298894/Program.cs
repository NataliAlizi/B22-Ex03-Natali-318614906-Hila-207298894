using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class Program
    {
        static public void  Main()
        {
            List<Wheel> wheels = new List<Wheel>();
            for(int k=0;k<2;k++)
            {
                wheels.Add(new Wheel("kjfn", 3, 31));
            }

            // Truck truck = new Truck(true, 50, "Soler", 20, 120, "tt", "123456", 6.5f, wheels);
            //truck.Refueling(FuelType.eFuelType.Soler, 50);
            // truck.Refueling(FuelType.eFuelType.Octan95, 50);
            //Car newCar = new Car();
            //FuelCar car = new FuelCar(newCar, "Octan95", 0, 38, "tt", "4567", 60, wheels);
            //car.Refueling(FuelType.eFuelType.Octan95, 120);

            MotorCycle motor = new MotorCycle();
            FuelMotorcycle newMotor = new FuelMotorcycle(motor, "Octan98", 0, 6.2f, "tt", "1234", 60, wheels);
            // newMotor.Refueling(FuelType.eFuelType.Octan98, 5);
            newMotor.ListOfWheel[0].WheelInflation(20);
            newMotor.ListOfWheel[0].WheelInflation(20);

        }

    }

}
