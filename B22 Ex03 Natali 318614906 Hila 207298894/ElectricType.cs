using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class ElectricType : Vehicle
    {
        private float m_CurrBatteryTime;
        private float m_MaxBatteryTime;

        public ElectricType(float i_CurrBatteryTime, float i_MaxBatteryTime, string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel) :
            base(i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            m_MaxBatteryTime = i_MaxBatteryTime;
            m_CurrBatteryTime = i_CurrBatteryTime;
        }

        public void BatteryCharging(float i_WantedAmountOfBattery)
        {
            if (this.m_CurrBatteryTime + i_WantedAmountOfBattery <= this.m_MaxBatteryTime)
            {
                this.m_CurrBatteryTime += i_WantedAmountOfBattery;
            }
            else
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(string.Format("Your max Battery capacity is {0}, and your current Battery capacity is {1}, so you cant refueling {2} amount.",m_MaxBatteryTime, m_CurrBatteryTime, i_WantedAmountOfBattery), m_MaxBatteryTime, 0);
                throw valueOutOfRangeException;
            }
        }

        public float CurrBatteryTime
        {
            get { return m_CurrBatteryTime; }
            set { m_CurrBatteryTime = value; }
        }

        public float MaxBatteryTime
        {
            get { return m_MaxBatteryTime; }
            set { m_MaxBatteryTime = value; }
        }
    }
}
