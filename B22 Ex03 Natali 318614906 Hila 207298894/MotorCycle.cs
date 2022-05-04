using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class MotorCycle:Vehicle
    {
        private enum eElectricMotorcycleData
        {
            NumberOfWheels = 2, MaxAirPressuer = 31, MaxBatteryTimeInMin = 150
        }

        public enum eFuelMotorCycleData
        {
           maxAmountOfFuelInCm = 6200, Octan98
        }

        public MotorCycle(int i_LicenseType,int i_EngineCapacity,string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel, Engine i_engine) :
            base(i_engine, i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            m_LicenseType = (eLicenseType)i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public enum eLicenseType
        {
            A, A1, B1, BB
        }
        private eLicenseType m_LicenseType;

        private int m_EngineCapacity;
        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        public override bool ValidTypeOfFuel(Engine.eFuelType i_WantedFuelType)
        {
            bool answer = false;
            if (i_WantedFuelType.ToString() == MotorCycle.eFuelMotorCycleData.Octan98.ToString())
            {
                answer = true;
            }

            return answer;
        }

        public override void AddRestDetails(Engine i_engine, StringBuilder io_vehicleData)
        {
            if(i_engine is ElectricType)
            {
                io_vehicleData.AppendLine(String.Format("Max battery time in minute: {0}", (int)eElectricMotorcycleData.MaxBatteryTimeInMin));
                io_vehicleData.AppendLine(String.Format("Current amount of battery: {0}", i_engine.CurrAmountOfFuelOrBattery()));

            }
            else //Fuel type
            {
                io_vehicleData.AppendLine(String.Format("Fuel type: {0}", eFuelMotorCycleData.Octan98.ToString()));
                io_vehicleData.AppendLine(String.Format("Current amount of fuel: {0}", i_engine.CurrAmountOfFuelOrBattery()));
                io_vehicleData.AppendLine(String.Format("Max amount of fuel in cm: {0}", eFuelMotorCycleData.maxAmountOfFuelInCm.ToString()));
            }

            io_vehicleData.AppendLine(String.Format("Number of wheels: {0}", eElectricMotorcycleData.NumberOfWheels.ToString()));
            io_vehicleData.AppendLine(String.Format("Max air pressuer: {0}", eElectricMotorcycleData.MaxAirPressuer.ToString()));
            io_vehicleData.AppendLine(String.Format("License type: {0}", m_LicenseType.ToString()));
            io_vehicleData.AppendLine(String.Format("Engine capacity: {0}", m_EngineCapacity));

        }
    }
}
