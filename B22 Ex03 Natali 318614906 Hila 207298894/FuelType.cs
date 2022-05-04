using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class FuelType : Engine
    {

        private float m_CurrAmountOfFuel;
        private float m_MaxAmountOfFuel;

        public FuelType(string i_FuelType, float i_CurrAmountOfFuel, float i_MaxAmountOfFuel)
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

        public override void Refueling(Vehicle i_Vehicle, Engine.eFuelType i_WantedFuelType, float i_WantedAmountOfsomething)
        {
            if (this.m_CurrAmountOfFuel + i_WantedAmountOfsomething <= this.m_MaxAmountOfFuel)
            {
                if (ValidTypeOfFuelForThisVehicle(i_WantedFuelType, i_Vehicle))
                {
                    this.m_CurrAmountOfFuel += i_WantedAmountOfsomething;
                }
                else
                {
                    ArgumentException argumentException = new ArgumentException(string.Format("{0} is not your vehicle type fuel", i_WantedFuelType.ToString()));
                    throw argumentException;
                }
            }
            else
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(string.Format("Your max fuel capacity is {0}, and your current fuel capacity is {1}, so you cant refueling {2} amount.", m_MaxAmountOfFuel, m_CurrAmountOfFuel, i_WantedAmountOfsomething), m_MaxAmountOfFuel, 0);
                throw valueOutOfRangeException;
            }
        }

        public bool ValidTypeOfFuelForThisVehicle(Engine.eFuelType i_WantedFuelType,Vehicle i_Vehicle)
        {
            return i_Vehicle.ValidTypeOfFuel(i_WantedFuelType);
        }

    }
}
