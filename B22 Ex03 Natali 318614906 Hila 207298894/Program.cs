﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class Program
    {
        static public void Main()
        {
            //Car car = new Car();
            //MotorCycle motor = new MotorCycle();
            List<Wheel> w = new List<Wheel>();
            for (int k = 0; k < 4; k++)
                w.Add(new Wheel("cc", 2.4f, 29));
            List<Wheel> w1 = new List<Wheel>();
            for (int k = 0; k < 16; k++)
                w1.Add(new Wheel("cc", 2.4f, 24));

            Engine engine1 = new ElectricType(100, 150);
            Vehicle vehicle1 = new Car("Kia", "123456", 100, w, engine1, 5, 3);
            Engine engine = new FuelType("Soler", 100, 150);
            Vehicle vehicle = new Truck("nshavo", "123456", 10, w1, engine, true, 100);
            vehicle1.MyEngine.Refueling(vehicle1, 0, 20);
            vehicle.MyEngine.Refueling(vehicle, (Engine.eFuelType)1, 10);



        }

    }

}
