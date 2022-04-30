using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(string i_msg, float i_MaxValue, float i_MinValue)
            : base(i_msg)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public float MaxValue
        {
            get { return m_MaxValue; }
            set { m_MaxValue = value; }
        }

        public float MinValue
        {
            get { return m_MinValue; }
            set { m_MinValue = value; }
        }
    }
}
