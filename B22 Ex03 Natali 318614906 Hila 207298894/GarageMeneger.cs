using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageMeneger
    {
        public enum eVehicleType
        {
            Car = 1, Motorcycle, Truck
        }


        public Vehicle MakeNewVehicle(int i_NumberOfTypeVehicle)
        {
            if (i_NumberOfTypeVehicle == 1)
            {
                return new Car();
            }
            else if (i_NumberOfTypeVehicle == 2)
            {
                return new MotorCycle();
            }
            else
            {
                return new Truck();
            }
        }

        //public void SetQuestion(List<string> i_QuestionForVehicle, Vehicle i_Vehicle)
        //{
        //    i_Vehicle.SetQuestionForVehicle(i_QuestionForVehicle);///יוצר את השאלות המיוחדות על כל רכב ורכב
        //    i_Vehicle.MyEngine.SetQuestionForVehicleType(i_QuestionForVehicle);///יוצר את השאלות על הדלק\בטריה
        //}

        //public void CheckAnswer(List<string> i_AnswerForVehicle, int i_Index, ref bool o_TheRightAnswer, Vehicle i_Vehicle)
        //{
        //    i_Vehicle.CheckAnswerForVehicle(i_AnswerForVehicle, i_Index, ref o_TheRightAnswer);
        //    i_Vehicle.MyEngine.CheckAnswerForVehicleType(i_AnswerForVehicle, i_Index, ref o_TheRightAnswer);
        //}
    }
}
