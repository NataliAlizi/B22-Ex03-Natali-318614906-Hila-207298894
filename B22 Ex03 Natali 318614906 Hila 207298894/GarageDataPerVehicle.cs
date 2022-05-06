using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageDataPerVehicle
    {
        private string m_OwnerName=string.Empty;
        private string m_OwnerPhoneNumber=string.Empty;

        public enum eVehicleStatus
        {
            InRepair, Fixed, Paid
        }
        private eVehicleStatus m_Status;

        private Vehicle m_VehicleInGarage;

        public eVehicleStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }


        public GarageDataPerVehicle(string i_OwnerName, string i_OwnerPhoneNumber,string i_Status, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleInGarage = i_Vehicle;
            m_Status= (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus),i_Status); ///check exeption!!! (Format exeption)
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public Vehicle VehicleInGarage
        {
            get { return m_VehicleInGarage; }
            set { m_VehicleInGarage = value; }
        }
    }
}
