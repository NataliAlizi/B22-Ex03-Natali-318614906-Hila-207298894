using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class Garage
    {
        private List<GarageDataPerVehicle> m_ListOfVehicleInGarage=new List<GarageDataPerVehicle>();

        public List<GarageDataPerVehicle> ListOfVehicleInGarage
        {
            get { return m_ListOfVehicleInGarage; }
            set { m_ListOfVehicleInGarage = value; }
        }
        public void AddVehicle(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            bool isExist = false;
            foreach(GarageDataPerVehicle vehicle in m_ListOfVehicleInGarage)
            {
                if(vehicle.VehicleInGarage.LicenseNumber == i_Vehicle.LicenseNumber)
                {
                    isExist = true;
                    vehicle.Status= (GarageDataPerVehicle.eVehicleStatus)Enum.Parse(typeof(GarageDataPerVehicle.eVehicleStatus), "InRepair");
                    break;//check
                }
            }
           if(!isExist)
            {
                GarageDataPerVehicle newVehicle = new GarageDataPerVehicle(i_OwnerName, i_OwnerPhone, "InRepair", i_Vehicle);
                m_ListOfVehicleInGarage.Add(newVehicle);
            }
        }
    }
}
