using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelType : Engine
    {

        private float m_CurrAmountOfFuel;
        private float m_MaxAmountOfFuel;

        public FuelType() { }

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

        public override void SetMaxFuelOrBattery(float i_MaxAmountOfFuel)
        {
            m_MaxAmountOfFuel = i_MaxAmountOfFuel;
        }

        public bool ValidTypeOfFuelForThisVehicle(Engine.eFuelType i_WantedFuelType, Vehicle i_Vehicle)
        {
            return i_Vehicle.ValidTypeOfFuel(i_WantedFuelType);
        }

        public override float CurrAmountOfFuelOrBattery()
        {
            return m_CurrAmountOfFuel;
        }

        public override float MaxAmountOfFuelOrBattery()
        {
            return m_MaxAmountOfFuel;
        }

        public override void SetQuestionForVehicleType(List<string> i_QuestionForVehicle)
        {
            i_QuestionForVehicle.Add("Whats your current fuel remain ? :");
        }

        public override void CheckAnswerForVehicleType(List<string> io_AnswerForVehicle, int i_Index, ref bool o_TheRightAnswer)
        {
            o_TheRightAnswer = false;
            if (this.MaxAmountOfFuel >= float.Parse(io_AnswerForVehicle[2]))
            {
                o_TheRightAnswer = true;
                m_CurrAmountOfFuel = float.Parse(io_AnswerForVehicle[2]);
            }
            else
            {
                io_AnswerForVehicle.RemoveAt(io_AnswerForVehicle.Count - 1);
            }
        }
    }
}
