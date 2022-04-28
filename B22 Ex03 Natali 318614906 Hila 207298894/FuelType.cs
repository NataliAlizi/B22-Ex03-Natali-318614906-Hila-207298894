using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class FuelType
    {
        private enum eFuelType
        {
            Soler, Octan95, Octan96, Octan98
        }

        private float m_CurrAmountOfFuel;
        private float m_MaxAmountOfFuel;

        private float CurrAmountOfFuel
        {
            get { return m_CurrAmountOfFuel; }
            set { m_CurrAmountOfFuel = value; }
        }

        private float MaxAmountOfFuel
        {
            get { return m_MaxAmountOfFuel; }
            set { m_MaxAmountOfFuel = value; }
        }

        public void Refueling()
        {

        }

    }
}
