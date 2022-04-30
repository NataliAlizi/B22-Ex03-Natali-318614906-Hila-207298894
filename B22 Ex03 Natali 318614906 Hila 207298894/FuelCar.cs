using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class FuelCar : FuelType
    {
        private Car m_Car;

        public enum eFuelCarData
        {
            NumberOfWheels = 4, MaxAirPressuer = 29, MaxAmountOfFuelInCm = 38000, Octan95
        }

        public FuelCar(Car i_Car, string i_FuelType, float i_CurrAmountOfFuel, float i_MaxAmountOfFuel, string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel) :
            base(i_FuelType, i_CurrAmountOfFuel, i_MaxAmountOfFuel, i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            m_Car = new Car();
            m_Car = i_Car;
        }

        public Car Car
        {
            get { return m_Car; }
            set { m_Car = value; }
        }

        public override bool ValidTypeOfFuelForThisVehicle(FuelType.eFuelType i_WantedFuelType)
        {
            bool answer = false;
            if (i_WantedFuelType.ToString() == FuelCar.eFuelCarData.Octan95.ToString())
            {
                answer = true;
            }

            return answer;
        }
    }
}
