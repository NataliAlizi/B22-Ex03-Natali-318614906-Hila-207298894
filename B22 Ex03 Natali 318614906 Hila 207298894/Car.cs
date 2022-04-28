using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class Car : Vehicle
    {
        private enum eColor
        {
            Red, White, Green, Blue
        }
        private int m_NumberOfDoors;

        public int NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }
    }
}
