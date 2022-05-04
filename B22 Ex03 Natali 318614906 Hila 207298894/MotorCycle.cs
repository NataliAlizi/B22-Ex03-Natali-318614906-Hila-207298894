using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class MotorCycle:Vehicle
    {
        public MotorCycle(int i_LicenseType,int i_EngineCapacity,string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel, Engine i_engine) :
            base(i_engine, i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            m_LicenseType = (eLicenseType)i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }
        private enum eElectricMotorcycleData
        {
            NumberOfWheels = 2, MaxAirPressuer = 31, MaxBatteryTimeInMin = 150
        }
        public enum eFuelMotorCycleData
        {
            numberofwheels = 2, maxairpressuer = 31, maxamountoffuelincm = 6200, Octan98
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
    }
}
