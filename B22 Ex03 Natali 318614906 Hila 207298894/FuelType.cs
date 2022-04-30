using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class FuelType : Vehicle
    {

        public enum eFuelType
        {
            Soler, Octan95, Octan96, Octan98
        }

        private float m_CurrAmountOfFuel;
        private float m_MaxAmountOfFuel;
        private eFuelType m_FuelType;

        public FuelType(string i_FuelType,float i_CurrAmountOfFuel, float i_MaxAmountOfFuel, string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel) : 
            base(i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            Enum.TryParse(i_FuelType, out eFuelType m_FuelType);//CHECK
            m_CurrAmountOfFuel = i_CurrAmountOfFuel;
            m_MaxAmountOfFuel = i_MaxAmountOfFuel;
        }

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
