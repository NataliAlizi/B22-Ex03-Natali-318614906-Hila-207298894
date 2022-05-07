using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public enum eFuelType
        {
            none, Soler, Octan95, Octan96, Octan98
        }

        public abstract void SetMaxFuelOrBattery(float i_Max);

        public abstract void Refueling(Vehicle i_Vehicle, Engine.eFuelType i_WantedFuelType, float i_WantedAmountOfsomething);

        public abstract float CurrAmountOfFuelOrBattery();

        public abstract float MaxAmountOfFuelOrBattery();

        public abstract void SetQuestionForVehicleType(List<string> i_QuestionForVehicle);

        public abstract void CheckAnswerForVehicleType(List<string> i_AnswerForVehicle, int i_Index, ref bool o_TheRightAnswer);
    }
}
