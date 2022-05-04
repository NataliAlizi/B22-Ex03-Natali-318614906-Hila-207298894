using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class Car:Vehicle
    {

        public enum eElectricCarData
        {
            NumberOfWheels = 4, MaxAirPressuer = 29, MaxBatteryTimeInMin = 198
        }
        public enum FuelCarData
        {
            NumberOfWheels = 4, MaxAirPressuer = 29, MaxAmountOfFuelInCm = 38000, Octan95
        }

        public Car(string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel, Engine i_engine,int i_NumberOfDoors,int i_Color) :
            base(i_engine, i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            m_Color = (eColor)i_Color;
            m_NumberOfDoors = (eNumberOfDoors)i_NumberOfDoors;
        }

        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;
        public enum eColor
        {
            Red, White, Green, Blue
        }

        public enum eNumberOfDoors
        {
            Two = 2, Three, Four, Five
        }

        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        //public override bool ValidTypeOfFuelForThisVehicle(Engine.eFuelType i_WantedFuelType)
        //{
        //    bool answer = false;
        //    if (i_WantedFuelType.ToString() == FuelCarData.Octan95.ToString())
        //    {
        //        answer = true;
        //    }

        //    return answer;
        //}
        public override bool ValidTypeOfFuel(Engine.eFuelType i_WantedFuelType)
        {
            bool answer = false;
            if (i_WantedFuelType.ToString() == FuelCarData.Octan95.ToString())
            {
                answer = true;
            }

            return answer;
        }

    }
}
