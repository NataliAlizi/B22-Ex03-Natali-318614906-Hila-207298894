using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class ElectricMotorcycle : ElectricType
    {
        private MotorCycle m_MotorCycle;

        private enum eElectricMotorcycleData
        {
            NumberOfWheels = 2, MaxAirPressuer = 31, MaxBatteryTimeInMin = 150
        }

        public ElectricMotorcycle(MotorCycle i_MotorCycle, float i_CurrBatteryTime, float i_MaxBatteryTime, string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel) :
            base(i_CurrBatteryTime, i_MaxBatteryTime, i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            m_MotorCycle = new MotorCycle();
            m_MotorCycle = i_MotorCycle;
        }

        public MotorCycle MotorCycle
        {
            get { return m_MotorCycle; }
            set { m_MotorCycle = value; }
        }
    }
}
