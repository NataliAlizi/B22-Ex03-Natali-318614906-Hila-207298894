using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class MotorCycle:Vehicle
    {
        private enum eElectricMotorcycleData
        {
            NumberOfWheels = 2, MaxAirPressuer = 31, MaxBatteryTimeInMin = 150
        }

        public enum eFuelMotorCycleData
        {
           MaxAmountOfFuelInCm = 620, Octan98
        }

        public MotorCycle() { }

        public MotorCycle(int i_LicenseType,int i_EngineCapacity,string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel, Engine i_engine) :
            base(i_engine, i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            m_LicenseType = (eLicenseType)i_LicenseType;
            m_EngineCapacity = i_EngineCapacity;
        }

        public enum eLicenseType
        {
            A, A1, B1, BB
        }
        private eLicenseType m_LicenseType;

        private int m_EngineCapacity;
        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        public override bool ValidTypeOfFuel(Engine.eFuelType i_WantedFuelType)
        {
            bool answer = false;
            if (i_WantedFuelType.ToString() == MotorCycle.eFuelMotorCycleData.Octan98.ToString())
            {
                answer = true;
            }

            return answer;
        }

        public override void AddRestDetails(Engine i_engine, StringBuilder io_vehicleData)
        {
            if(i_engine is ElectricType)
            {
                io_vehicleData.AppendLine(String.Format("Max battery time in minute: {0}", (int)eElectricMotorcycleData.MaxBatteryTimeInMin));
                io_vehicleData.AppendLine(String.Format("Current amount of battery: {0}", i_engine.CurrAmountOfFuelOrBattery()));

            }
            else //Fuel type
            {
                io_vehicleData.AppendLine(String.Format("Fuel type: {0}", eFuelMotorCycleData.Octan98.ToString()));
                io_vehicleData.AppendLine(String.Format("Current amount of fuel: {0}", i_engine.CurrAmountOfFuelOrBattery()));
                io_vehicleData.AppendLine(String.Format("Max amount of fuel in cm: {0}", (int)eFuelMotorCycleData.MaxAmountOfFuelInCm));
            }

            io_vehicleData.AppendLine(String.Format("Number of wheels: {0}", (int)eElectricMotorcycleData.NumberOfWheels));
            io_vehicleData.AppendLine(String.Format("Max air pressuer: {0}", (int)eElectricMotorcycleData.MaxAirPressuer));
            io_vehicleData.AppendLine(String.Format("License type: {0}", m_LicenseType.ToString()));
            io_vehicleData.AppendLine(String.Format("Engine capacity: {0}", m_EngineCapacity));

        }

        public override void SetQuestionForVehicle(List<string> i_QuestionForVehicle)
        {
            i_QuestionForVehicle.Add("Whats your licens type? 0)A 1)A1 2)B2 3)BB");
            i_QuestionForVehicle.Add("Type your Engine volume in cc :");
        }

        public override void SetAnswerForVehicle(List<string> i_AnswerForVehicle)
        {
            this.LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_AnswerForVehicle[3]);
            this.EngineCapacity = int.Parse(i_AnswerForVehicle[4]);
        }

        public override void CheckAnswerForVehicle(List<string> i_AnswerForVehicle, int i_Index, ref bool o_TheRightAnswer)
        {
            o_TheRightAnswer = false;
            bool validEngineCapacity = false;
            int engineCapacity;
            if (i_Index == 3)
            {
                if (i_AnswerForVehicle[3] == "0" || i_AnswerForVehicle[3] == "1" ||
                    i_AnswerForVehicle[3] == "2" || i_AnswerForVehicle[3] == "3")
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
                validEngineCapacity = int.TryParse(i_AnswerForVehicle[4], out engineCapacity);
                if(validEngineCapacity)
                {
                    o_TheRightAnswer = true;
                }
                else
                {
                    i_AnswerForVehicle.RemoveAt(i_AnswerForVehicle.Count - 1);
                }
            }
        }

        public override void SetWheelAndCheckAnswer(List<string> io_AnswerForVehicle, int i_Index, ref bool io_TheRightAnswer)
        {
            io_TheRightAnswer = false;
            int sizeNumberOfWheels = (int)eElectricMotorcycleData.NumberOfWheels;
            int currAir = 0;
            if (i_Index == 0)
            {
                io_TheRightAnswer = true;
            }
            else if (i_Index == 1)
            {
                io_TheRightAnswer = int.TryParse(io_AnswerForVehicle[1], out currAir);
                if (currAir <= (int)eElectricMotorcycleData.MaxAirPressuer && io_TheRightAnswer)
                {
                    io_TheRightAnswer = true;
                    Wheel wheel = new Wheel(io_AnswerForVehicle[0], float.Parse(io_AnswerForVehicle[1]), (int)eElectricMotorcycleData.MaxAirPressuer);
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

        public override void SetMaxAmountOfFuelOrBattery()
        {
            float returnAnswer = 0;
            if (this.MyEngine is FuelType)
            {
                returnAnswer = (int)eFuelMotorCycleData.MaxAmountOfFuelInCm;
            }
            else
            {
                returnAnswer = (int)eElectricMotorcycleData.MaxBatteryTimeInMin;
            }
            this.MyEngine.SetMaxFuelOrBattery(returnAnswer);
        }
    }
}
