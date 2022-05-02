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

        public FuelType(string i_FuelType, float i_CurrAmountOfFuel, float i_MaxAmountOfFuel, string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel) :
            base(i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
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

        public void Refueling(FuelType.eFuelType i_WantedFuelType, float i_WantedAmountOfFuel)
        {
            if (this.m_CurrAmountOfFuel + i_WantedAmountOfFuel <= this.m_MaxAmountOfFuel)
            {
                if (this.ValidTypeOfFuelForThisVehicle(i_WantedFuelType))
                {
                    this.m_CurrAmountOfFuel += i_WantedAmountOfFuel;
                }
                else
                {
                    ArgumentException argumentException = new ArgumentException(string.Format("{0} is not your vehicle type fuel", i_WantedFuelType.ToString()));
                    throw argumentException;
                }
            }
            else
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(string.Format("Your max fuel capacity is {0}, and your current fuel capacity is {1}, so you cant refueling {2} amount.", m_MaxAmountOfFuel, m_CurrAmountOfFuel, i_WantedAmountOfFuel), m_MaxAmountOfFuel, 0);
                throw valueOutOfRangeException;
            }
        }

        public virtual bool ValidTypeOfFuelForThisVehicle(FuelType.eFuelType i_WantedFuelType)//לבדוק איך משנים
        {
            return true;
        }
    }
}
