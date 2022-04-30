using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class ElectricCar : ElectricType
    {
        private Car m_Car;

        private enum eElectricCarData
        {
            NumberOfWheels = 4, MaxAirPressuer = 29, MaxBatteryTimeInMin = 198
        }

        public ElectricCar(Car i_Car, float i_CurrBatteryTime, float i_MaxBatteryTime, string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel) :
            base(i_CurrBatteryTime, i_MaxBatteryTime, i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            m_Car = new Car();
            m_Car = i_Car;
        }

        public Car Car
        {
            get { return m_Car; }
            set { m_Car = value; }
        }
    }
}
