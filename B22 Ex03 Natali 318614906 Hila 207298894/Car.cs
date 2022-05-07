using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eElectricCarData
        {
            NumberOfWheels = 4, MaxAirPressuer = 29, MaxBatteryTimeInMin = 198
        }

        public enum eFuelCarData
        {
            MaxAmountOfFuelInCm = 3800, Octan95
        }

        public Car() { }

        public Car(string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel, Engine i_engine, int i_NumberOfDoors, int i_Color) :
            base(i_engine, i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            m_Color = (eColor)i_Color;
            m_NumberOfDoors = (eNumberOfDoors)i_NumberOfDoors;
        }

        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;
        public enum eColor
        {
            Red, White, Green, Blue
        }

        public enum eNumberOfDoors
        {
            Two = 2, Three, Four, Five
        }

        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public override bool ValidTypeOfFuel(Engine.eFuelType i_WantedFuelType)
        {
            bool answer = false;
            if (i_WantedFuelType.ToString() == eFuelCarData.Octan95.ToString())
            {
                answer = true;
            }

            return answer;
        }

        public override void AddRestDetails(Engine i_engine, StringBuilder io_vehicleData)
        {
            if (i_engine is ElectricType)
            {
                io_vehicleData.AppendLine(String.Format("Max battery time in minute: {0}", (int)eElectricCarData.MaxBatteryTimeInMin));
                io_vehicleData.AppendLine(String.Format("Current amount of battery: {0}", i_engine.CurrAmountOfFuelOrBattery()));

            }
            else //Fuel type
            {
                io_vehicleData.AppendLine(String.Format("Fuel type: {0}", eFuelCarData.Octan95.ToString()));
                io_vehicleData.AppendLine(String.Format("Current amount of fuel: {0}", i_engine.CurrAmountOfFuelOrBattery()));
                io_vehicleData.AppendLine(String.Format("Max amount of fuel in cm: {0}", (int)eFuelCarData.MaxAmountOfFuelInCm));
            }

            io_vehicleData.AppendLine(String.Format("Number of wheels: {0}", (int)eElectricCarData.NumberOfWheels));
            io_vehicleData.AppendLine(String.Format("Max air pressuer: {0}", (int)eElectricCarData.MaxAirPressuer));
            io_vehicleData.AppendLine(String.Format("Car color: {0}", m_Color));
            io_vehicleData.AppendLine(String.Format("Number of doors: {0}", m_NumberOfDoors));
        }

        public override void SetWheelAndCheckAnswer(List<string> io_AnswerForVehicle, int i_Index, ref bool io_TheRightAnswer)
        {
            io_TheRightAnswer = false;
            int sizeNumberOfWheels = (int)eElectricCarData.NumberOfWheels;
            int currAir = 0;
            if (i_Index == 0)
            {
                io_TheRightAnswer = true;
            }
            else if (i_Index == 1)
            {
                io_TheRightAnswer = int.TryParse(io_AnswerForVehicle[1], out currAir);
                if (currAir <= (int)eElectricCarData.MaxAirPressuer && io_TheRightAnswer)
                {
                    io_TheRightAnswer = true;
                    Wheel wheel = new Wheel(io_AnswerForVehicle[0], float.Parse(io_AnswerForVehicle[1]), (int)eElectricCarData.MaxAirPressuer);
                    this.ListOfWheel = new List<Wheel>();
                    for (int i = 0; i < sizeNumberOfWheels; i++)
                    {
                        this.ListOfWheel.Add(wheel);
                    }
                }
                else
                {
                    io_TheRightAnswer = false;
                    io_AnswerForVehicle.RemoveAt(io_AnswerForVehicle.Count - 1);
                }
            }
        }

        public override void SetQuestionForVehicle(List<string> i_QuestionForVehicle)
        {
            i_QuestionForVehicle.Add("Whats your car color ?  0)Red 1)White 2)Green 3)Blue");
            i_QuestionForVehicle.Add("How much doors do you have?  2)Two 3)Three 4)Four 5)Five");
        }

        public override void SetAnswerForVehicle(List<string> i_AnswerForVehicle)
        {
            this.Color = (eColor)Enum.Parse(typeof(eColor), i_AnswerForVehicle[3]);///לבדוק מה לעשות. הערך בטוח נכון 
            this.NumberOfDoors=(eNumberOfDoors)Enum.Parse(typeof(eNumberOfDoors), i_AnswerForVehicle[4]);
        }

        public override void CheckAnswerForVehicle(List<string> i_AnswerForVehicle, int i_Index, ref bool o_TheRightAnswer)
        {
            o_TheRightAnswer = false;
            if (i_Index == 3)
            {
                if (i_AnswerForVehicle[3] == "1" || i_AnswerForVehicle[3] == "2" ||
                    i_AnswerForVehicle[3] == "0" || i_AnswerForVehicle[3] == "3")
                {
                    o_TheRightAnswer = true;
                }
                else
                {
                    i_AnswerForVehicle.RemoveAt(i_AnswerForVehicle.Count - 1);
                }
            }
            else if (i_Index == 4)
            {
                if (i_AnswerForVehicle[4] == "2" || i_AnswerForVehicle[4] == "3" ||
                    i_AnswerForVehicle[4] == "4" || i_AnswerForVehicle[4] == "5")
                {
                    o_TheRightAnswer = true;
                }
                else
                {
                    i_AnswerForVehicle.RemoveAt(i_AnswerForVehicle.Count - 1);
                }
            }
        }
       
        public override void SetMaxAmountOfFuelOrBattery()
        {
            float returnAnswer = 0;
            if(this.MyEngine is FuelType)
            {
                returnAnswer = (int)eFuelCarData.MaxAmountOfFuelInCm;
            }
            else
            {
                returnAnswer = (int)eElectricCarData.MaxBatteryTimeInMin;
            }
            this.MyEngine.SetMaxFuelOrBattery(returnAnswer);
        }
    }
}
