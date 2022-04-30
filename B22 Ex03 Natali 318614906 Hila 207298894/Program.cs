using System;
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
            Car car = new Car();
            List<Wheel> w = new List<Wheel>();
            for (int k = 0; k < 4; k++)
                w.Add(new Wheel("cc", 2.4f, 29));
            List<Wheel> w1 = new List<Wheel>();
            for (int k = 0; k < 16; k++)
                w1.Add(new Wheel("cc", 2.4f, 24));

            Vehicle fc = new FuelCar(car, "octan95", 50, 70, "kia", "123456", 0.2f, w);
            Vehicle fsc = new Truck(true,30,"octan95", 50, 70, "kia", "123456", 0.2f, w1);
            Garage garage=new Garage();
            garage.AddVehicle("natali","22135",fc);
            garage.AddVehicle("hila","4564",fsc);
        }

    }

}
