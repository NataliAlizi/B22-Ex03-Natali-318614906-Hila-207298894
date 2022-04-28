using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class Truck : Vehicle
    {
        private bool m_DriveRefrigeratedContents;
        private float m_CargoCapacity;

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
    }
}
