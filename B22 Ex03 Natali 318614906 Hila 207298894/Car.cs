using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class Car : Vehicle
    {
        public enum eElectricCarData
        {
            NumberOfWheels = 4, MaxAirPressuer = 29, MaxBatteryTimeInMin = 198
        }
        public enum FuelCarData
        {
            MaxAmountOfFuelInCm = 38000, Octan95
        }

        public Car(string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel, Engine i_engine, int i_NumberOfDoors, int i_Color) :
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

        public override bool ValidTypeOfFuel(Engine.eFuelType i_WantedFuelType)
        {
            bool answer = false;
            if (i_WantedFuelType.ToString() == FuelCarData.Octan95.ToString())
            {
                answer = true;
            }

            return answer;
        }

        public override void AddRestDetails(Engine i_engine, StringBuilder io_vehicleData)
        {
            if (i_engine is ElectricType)
            {
                io_vehicleData.AppendLine(String.Format("Max battery time in minute: {0}", (int)eElectricCarData.MaxBatteryTimeInMin));
                io_vehicleData.AppendLine(String.Format("Current amount of battery: {0}", i_engine.CurrAmountOfFuelOrBattery()));

            }
            else //Fuel type
            {
                io_vehicleData.AppendLine(String.Format("Fuel type: {0}", FuelCarData.Octan95.ToString()));
                io_vehicleData.AppendLine(String.Format("Current amount of fuel: {0}", i_engine.CurrAmountOfFuelOrBattery()));
                io_vehicleData.AppendLine(String.Format("Max amount of fuel in cm: {0}", FuelCarData.MaxAmountOfFuelInCm.ToString()));
            }

            io_vehicleData.AppendLine(String.Format("Number of wheels: {0}", eElectricCarData.NumberOfWheels.ToString()));
            io_vehicleData.AppendLine(String.Format("Max air pressuer: {0}", eElectricCarData.MaxAirPressuer.ToString()));
            io_vehicleData.AppendLine(String.Format("Car color: {0}", m_Color));
            io_vehicleData.AppendLine(String.Format("Number of doors: {0}", m_NumberOfDoors));
        }
    }
}
