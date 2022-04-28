using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class ElectricType
    {
        private float m_CurrBatteryTime;
        private float m_MaxBatteryTime;

        public void BatteryCharging()
        {

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
