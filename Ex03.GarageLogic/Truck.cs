﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_DriveRefrigeratedContents;
        private float m_CargoCapacity;

        public enum eTruckData
        {
            NumberOfWheels = 16, MaxAirPressuer = 24, MaxAmountOfFuelInCm = 120000, Soler
        }

        public Truck()
        {
        }

        public bool DriveRefrigeratedContents
        {
            get { return m_DriveRefrigeratedContents; }
            set { m_DriveRefrigeratedContents = value; }
        }

        public float CargoCapacity
        {
            get { return m_CargoCapacity; }
            set { m_CargoCapacity = value; }
        }

        public override bool ValidTypeOfFuel(Engine.eFuelType i_WantedFuelType)
        {
            bool answer = false;
            if (i_WantedFuelType.ToString() == Truck.eTruckData.Soler.ToString())
            {
                answer = true;
            }

            return answer;
        }

        public override void AddRestDetails(Engine i_engine, StringBuilder io_vehicleData)
        {
            io_vehicleData.AppendLine(string.Format("Fuel type: {0}", eTruckData.Soler.ToString()));
            io_vehicleData.AppendLine(string.Format("Current amount of fuel: {0}", i_engine.CurrAmountOfFuelOrBattery()));
            io_vehicleData.AppendLine(string.Format("Number of wheels: {0}", (int)eTruckData.NumberOfWheels));
            io_vehicleData.AppendLine(string.Format("Max air pressuer: {0}", (int)eTruckData.MaxAirPressuer));
            io_vehicleData.AppendLine(string.Format("Max amount of fuel : {0}", (int)eTruckData.MaxAmountOfFuelInCm / 1000));
            io_vehicleData.AppendLine(string.Format("Drive refrigerated contents: {0}", m_DriveRefrigeratedContents));
            io_vehicleData.AppendLine(string.Format("Cargo capacity: {0}", m_CargoCapacity));
        }

        public override void SetQuestionForVehicle(List<string> i_QuestionForVehicle)
        {
            i_QuestionForVehicle.Add("Do your Truck Drive Refrigerated Contents 1)Yes 2)No");
            i_QuestionForVehicle.Add("Type your Cargo Capacity :");
        }

        public override void SetAnswerForVehicle(List<string> i_AnswerForVehicle)
        {
            if (i_AnswerForVehicle[3] == "1")
            {
                this.DriveRefrigeratedContents = true;
            }
            else
            {
                this.DriveRefrigeratedContents = false;
            }

            this.CargoCapacity = float.Parse(i_AnswerForVehicle[4]);
        }

        public override void SetWheelAndCheckAnswer(List<string> io_AnswerForVehicle, int i_Index, ref bool io_TheRightAnswer)
        {
            io_TheRightAnswer = false;
            int sizeNumberOfWheels = (int)eTruckData.NumberOfWheels;
            int currAir = 0;
            if (i_Index == 0)
            {
                io_TheRightAnswer = true;
            }
            else if (i_Index == 1)
            {
                io_TheRightAnswer = int.TryParse(io_AnswerForVehicle[1], out currAir);
                if (currAir <= (int)eTruckData.MaxAirPressuer && io_TheRightAnswer)
                {
                    io_TheRightAnswer = true;
                    Wheel wheel = new Wheel(io_AnswerForVehicle[0], float.Parse(io_AnswerForVehicle[1]), (int)eTruckData.MaxAirPressuer);
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

        public override void CheckAnswerForVehicle(List<string> i_AnswerForVehicle, int i_Index, ref bool o_TheRightAnswer)
        {
            o_TheRightAnswer = false;
            bool validEngineCapacity = false;
            float cargoCapacity;
            if (i_Index == 3)
            {
                if (i_AnswerForVehicle[3] == "1" || i_AnswerForVehicle[3] == "2")
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
                validEngineCapacity = float.TryParse(i_AnswerForVehicle[4], out cargoCapacity);
                if (validEngineCapacity)
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
            float max = (int)eTruckData.MaxAmountOfFuelInCm;
            max /= 1000;
            this.MyEngine.SetMaxFuelOrBattery(max);
        }
    }
}
