using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class MotorCycle
    {
        private enum eLicenseType
        {
            A, A1, B1, BB
        }

        private int m_EngineCapacity;

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }
    }
}
