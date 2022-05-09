using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<GarageDataPerVehicle> m_ListOfVehicleInGarage = new List<GarageDataPerVehicle>();

        public List<GarageDataPerVehicle> ListOfVehicleInGarage
        {
            get { return m_ListOfVehicleInGarage; }
            set { m_ListOfVehicleInGarage = value; }
        }

        public List<string> DisplayLicenseNumber(int i_VehicleStatus)
        {
            List<string> licenseNunbersList = new List<string>();
            foreach (GarageDataPerVehicle garageDataPerVehicle in m_ListOfVehicleInGarage)
            {
                if (i_VehicleStatus == 0 || i_VehicleStatus == (int)garageDataPerVehicle.Status)
                {
                    licenseNunbersList.Add(garageDataPerVehicle.VehicleInGarage.LicenseNumber);
                }
            }

            return licenseNunbersList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, int i_NewStatus)
        {
            bool isExist = false;

            foreach (GarageDataPerVehicle garageDataPerVehicle in m_ListOfVehicleInGarage)
            {
                if (garageDataPerVehicle.VehicleInGarage.LicenseNumber == i_LicenseNumber)
                {
                    isExist = true;
                    garageDataPerVehicle.Status = (GarageDataPerVehicle.eVehicleStatus)i_NewStatus;
                    break;
                }
            }

            if (!isExist)
            {
                ArgumentException argumentException = new ArgumentException(string.Format("Vehicle with License number:{0} doesnt exist", i_LicenseNumber));
                throw argumentException;
            }
        }

        public void WheelInflationToMax(string i_LicenseNumber)
        {
            float howMuchToFill = 0;
            bool isExist = false;
            foreach (GarageDataPerVehicle vehicle in m_ListOfVehicleInGarage)
            {
                if (i_LicenseNumber == vehicle.VehicleInGarage.LicenseNumber)
                {
                    isExist = true;
                    foreach (Wheel wheel in vehicle.VehicleInGarage.ListOfWheel)
                    {
                        howMuchToFill = wheel.MaxAirPressuer - wheel.CurrAirPressuer;
                        wheel.WheelInflation(howMuchToFill);
                    }
                }
            }

            if (!isExist)
            {
                ArgumentException argumentException = new ArgumentException(string.Format("Vehicle with License number:{0} doesnt exist", i_LicenseNumber));
                throw argumentException;
            }
        }

        public void AddVehicle(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            bool isExist = false;
            foreach (GarageDataPerVehicle vehicle in m_ListOfVehicleInGarage)
            {
                if (vehicle.VehicleInGarage.LicenseNumber == i_Vehicle.LicenseNumber)
                {
                    isExist = true;
                    vehicle.Status = (GarageDataPerVehicle.eVehicleStatus)Enum.Parse(typeof(GarageDataPerVehicle.eVehicleStatus), "InRepair");
                    break;
                }
            }

            if (!isExist)
            {
                GarageDataPerVehicle newVehicle = new GarageDataPerVehicle(i_OwnerName, i_OwnerPhone, "InRepair", i_Vehicle);
                m_ListOfVehicleInGarage.Add(newVehicle);
            }
        }

        public void RefulingVehicle(string i_LicenseNumber, Engine.eFuelType i_WantedFuelType, float i_WantedAmountOfsomething)
        {
            bool isExist = false;
            foreach (GarageDataPerVehicle vehicle in m_ListOfVehicleInGarage)
            {
                if (vehicle.VehicleInGarage.LicenseNumber == i_LicenseNumber)
                {
                    isExist = true;
                    vehicle.VehicleInGarage.MyEngine.Refueling(vehicle.VehicleInGarage, i_WantedFuelType, i_WantedAmountOfsomething);
                    break;
                }
            }

            if (!isExist)
            {
                ArgumentException argumentException = new ArgumentException(string.Format("Vehicle with License number:{0} doesnt exist", i_LicenseNumber));
                throw argumentException;
            }
        }

        public StringBuilder DisplaysVehicleData(string i_LicenseNumber)
        {
            StringBuilder vehicleData = new StringBuilder();
            bool isExist = false;

            foreach (GarageDataPerVehicle vehicle in m_ListOfVehicleInGarage)
            {
                if (vehicle.VehicleInGarage.LicenseNumber == i_LicenseNumber)
                {
                    isExist = true;
                    vehicleData.AppendLine(string.Format("License number: {0}", i_LicenseNumber));
                    vehicleData.AppendLine(string.Format("Model name: {0}", vehicle.VehicleInGarage.ModelName));
                    vehicleData.AppendLine(string.Format("Owner name: {0}", vehicle.OwnerName));
                    vehicleData.AppendLine(string.Format("Vehicle status in garage: {0}", vehicle.Status.ToString()));
                    vehicleData.AppendLine(string.Format("Manufacturer name of wheels: {0}", vehicle.VehicleInGarage.ListOfWheel[0].ManufacturerName));
                    vehicleData.AppendLine(string.Format("Air Pressuer: {0}", vehicle.VehicleInGarage.ListOfWheel[0].CurrAirPressuer));
                    vehicleData.AppendLine(string.Format("Remain energy in percents: {0}", vehicle.VehicleInGarage.RemainEnergyPercents));
                    vehicle.VehicleInGarage.AddRestDetails(vehicle.VehicleInGarage.MyEngine, vehicleData);
                }
            }

            if (!isExist)
            {
                ArgumentException argumentException = new ArgumentException(string.Format("Vehicle with License number:{0} doesnt exist", i_LicenseNumber));
                throw argumentException;
            }

            return vehicleData;
        }

        public void SetQuestion(List<string> i_QuestionForVehicle, Vehicle i_Vehicle)
        {
            i_Vehicle.SetQuestionForWheels(i_QuestionForVehicle);
            i_Vehicle.MyEngine.SetQuestionForVehicleType(i_QuestionForVehicle);
            i_Vehicle.SetQuestionForVehicle(i_QuestionForVehicle);
        }

        public void CheckAnswer(List<string> i_AnswerForVehicle, int i_Index, ref bool o_TheRightAnswer, Vehicle i_Vehicle)
        {
            if (i_Index == 0 || i_Index == 1)
            {
                i_Vehicle.SetWheelAndCheckAnswer(i_AnswerForVehicle, i_Index, ref o_TheRightAnswer);
            }
            else if (i_Index == 2)
            {
                i_Vehicle.SetMaxAmountOfFuelOrBattery();
                i_Vehicle.MyEngine.CheckAnswerForVehicleType(i_AnswerForVehicle, i_Index, ref o_TheRightAnswer);
            }
            else
            {
                i_Vehicle.CheckAnswerForVehicle(i_AnswerForVehicle, i_Index, ref o_TheRightAnswer);
            }
        }
    }
}
