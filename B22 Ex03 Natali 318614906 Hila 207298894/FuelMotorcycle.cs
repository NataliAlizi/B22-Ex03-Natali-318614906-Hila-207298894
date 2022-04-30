using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class FuelMotorcycle:FuelType
    {
        MotorCycle m_MotorCycle;

        private enum eFuelMotorCycleData
        {
            NumberOfWheels = 2, MaxAirPressuer = 31, MaxAmountOfFuelInCm = 6200, FuelTypeTruck = FuelType.eFuelType.Octan98
        }

        public FuelMotorcycle(MotorCycle i_MotorCycle, string i_FuelType, float i_CurrAmountOfFuel, float i_MaxAmountOfFuel, string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel) : 
            base(i_FuelType, i_CurrAmountOfFuel, i_MaxAmountOfFuel, i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
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
