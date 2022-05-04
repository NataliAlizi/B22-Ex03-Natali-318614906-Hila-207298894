using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class Garage
    {
        private List<GarageDataPerVehicle> m_ListOfVehicleInGarage = new List<GarageDataPerVehicle>();

        public List<GarageDataPerVehicle> ListOfVehicleInGarage
        {
            get { return m_ListOfVehicleInGarage; }
            set { m_ListOfVehicleInGarage = value; }
        }

        public List<string> DisplayLicenseNumber(string i_VehicleStatus, bool i_AllVehicle)
        {
            List<string> licenseNunbersList = new List<string>();
            foreach (GarageDataPerVehicle garageDataPerVehicle in m_ListOfVehicleInGarage)
            {
                if (i_AllVehicle || i_VehicleStatus == garageDataPerVehicle.Status.ToString()) ///check if there is another way to parse and check exeption!!!
                {
                    licenseNunbersList.Add(garageDataPerVehicle.VehicleInGarage.LicenseNumber);
                }
            }

            return licenseNunbersList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, string i_NewStatus)
        {
            foreach (GarageDataPerVehicle garageDataPerVehicle in m_ListOfVehicleInGarage)
            {

                if (garageDataPerVehicle.VehicleInGarage.LicenseNumber == i_LicenseNumber)
                {
                    garageDataPerVehicle.Status = (GarageDataPerVehicle.eVehicleStatus)Enum.Parse(typeof(GarageDataPerVehicle.eVehicleStatus), i_NewStatus); //check exeption of parse!!!
                    break;
                }
            }
        }
       
        public void WheelInflationToMax(string i_LicenseNumber)
        {
            float howMuchToFill = 0;
            foreach(GarageDataPerVehicle vehicle in m_ListOfVehicleInGarage)
            {
                if(i_LicenseNumber == vehicle.VehicleInGarage.LicenseNumber)
                {
                    foreach(Wheel wheel in vehicle.VehicleInGarage.ListOfWheel)
                    {
                        howMuchToFill = wheel.MaxAirPressuer - wheel.CurrAirPressuer;
                        wheel.WheelInflation(howMuchToFill);
                    }
                }
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
                    vehicle.Status = (GarageDataPerVehicle.eVehicleStatus)Enum.Parse(typeof(GarageDataPerVehicle.eVehicleStatus), "InRepair"); //check exeption of parse!!!
                    break;
                }
            }
            if (!isExist)
            {
                GarageDataPerVehicle newVehicle = new GarageDataPerVehicle(i_OwnerName, i_OwnerPhone, "InRepair", i_Vehicle);
                m_ListOfVehicleInGarage.Add(newVehicle);
            }
        }
    }
}
