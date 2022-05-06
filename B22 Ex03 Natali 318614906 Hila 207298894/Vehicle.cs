using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    abstract public class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_RemainEnergyPercents;
        private List<Wheel> m_ListOfWheel;
        Engine m_engine;

        public Vehicle() { }

        public Vehicle(Engine i_engine, string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_RemainEnergyPercents = i_RemainEnergyPercents;
            m_ListOfWheel = new List<Wheel>(i_ListOfWheel.Count);
            m_ListOfWheel = i_ListOfWheel;
            m_engine = i_engine;
        }

        public Engine MyEngine
        {
            get { return m_engine; }
            set { m_engine = value; }
        }
        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public List<Wheel> ListOfWheel
        {
            get { return m_ListOfWheel; }
            set { m_ListOfWheel = value; }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public float RemainEnergyPercents
        {
            get { return m_RemainEnergyPercents; }
            set { m_RemainEnergyPercents = value; }
        }

        public abstract bool ValidTypeOfFuel(Engine.eFuelType i_WantedFuelType);

        public abstract void AddRestDetails(Engine i_engine, StringBuilder io_vehicleData);

        public abstract void SetQuestionForVehicle(List<string> i_QuestionForVehicle);

        public abstract void CheckAnswerForVehicle(List<string> i_AnswerForVehicle, int i_Index, ref bool o_TheRightAnswer);

        public abstract void SetWheelAndCheckAnswer(List<string> i_AnswerForVehicle, int i_Index, ref bool o_TheRightAnswer);

        public abstract void SetMaxAmountOfFuelOrBattery();

        public abstract void SetAnswerForVehicle(List<string> i_AnswerForVehicle);

        public void SetQuestionForWheels(List<string> i_QuestionForVehicle)
        {
            i_QuestionForVehicle.Add("Whats your Wheel Manufacturer Name ?");
            i_QuestionForVehicle.Add("Whats your current Air Pressuer ?");
        }
    }
}
