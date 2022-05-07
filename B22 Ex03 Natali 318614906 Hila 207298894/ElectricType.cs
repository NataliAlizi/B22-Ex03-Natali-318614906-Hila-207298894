using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricType : Engine
    {
        private float m_CurrBatteryTime;
        private float m_MaxBatteryTime;

        public ElectricType() { }
        //public ElectricType(float i_CurrBatteryTime, float i_MaxBatteryTime)
        //{
        //    m_MaxBatteryTime = i_MaxBatteryTime;
        //    m_CurrBatteryTime = i_CurrBatteryTime;
        //}

        public override void Refueling(Vehicle i_Vehicle, Engine.eFuelType i_WantedFuelType, float i_WantedAmountOfsomething)
        {
            if (this.m_CurrBatteryTime + i_WantedAmountOfsomething <= this.m_MaxBatteryTime)
            {
                this.m_CurrBatteryTime += i_WantedAmountOfsomething;
            }
            else
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(string.Format("Your max Battery capacity is {0}, and your current Battery capacity is {1}, so you cant refueling {2} amount.", m_MaxBatteryTime, m_CurrBatteryTime, i_WantedAmountOfsomething), m_MaxBatteryTime, 0);
                throw valueOutOfRangeException;
            }
        }

        public override float CurrAmountOfFuelOrBattery()
        {
            return m_CurrBatteryTime;
        }

        public override float MaxAmountOfFuelOrBattery()
        {
            return m_MaxBatteryTime;
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

        public override void SetQuestionForVehicleType(List<string> i_QuestionForVehicle)
        {
            i_QuestionForVehicle.Add("Whats your current Battery time left ? (in min) :");
        }

        public override void CheckAnswerForVehicleType(List<string> i_AnswerForVehicle, int i_Index, ref bool o_TheRightAnswer)
        {
            o_TheRightAnswer = false;
            if (this.MaxBatteryTime >= float.Parse(i_AnswerForVehicle[2]))
            {
                o_TheRightAnswer = true;
                m_CurrBatteryTime = float.Parse(i_AnswerForVehicle[2]);
            }
            else
            {
                i_AnswerForVehicle.RemoveAt(i_AnswerForVehicle.Count - 1);
            }
        }

        public override void SetMaxFuelOrBattery(float i_MaxOfBattery)
        {
            m_MaxBatteryTime = i_MaxOfBattery;
        }
    }
}
