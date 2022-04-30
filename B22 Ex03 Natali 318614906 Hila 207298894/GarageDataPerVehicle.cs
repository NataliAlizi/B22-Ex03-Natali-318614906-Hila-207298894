using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class GarageDataPerVehicle
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;

        private enum eVehicleStatus
        {
            InRepair, Fixed, Paid
        }

        private Vehicle m_VehicleInGarage;
    }
}
