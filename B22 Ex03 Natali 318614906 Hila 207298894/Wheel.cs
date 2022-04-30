using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B22_Ex03_Natali_318614906_Hila_207298894
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrAirPressuer;
        private float m_MaxAirPressuer;       

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public float CurrAirPressuer
        {
            get { return m_CurrAirPressuer; }
            set { m_CurrAirPressuer = value; }
        }

        public float MaxAirPressuer
        {
            get { return m_MaxAirPressuer; }
            set { m_MaxAirPressuer = value; }
        }
        /*פעולת ניפוח מקבלת כמה אוויר להוסיף לגלגל ומשנה את מצב לחץ האוויר אם הוא לא חורג מהמקסימום*/
        public void WheelInflation(float i_HowMuchAirPressuerToAdd)
        {
            if(m_CurrAirPressuer+i_HowMuchAirPressuerToAdd<=m_MaxAirPressuer)
            {
                m_CurrAirPressuer += i_HowMuchAirPressuerToAdd;
            }
            else
            {
                //whatToDo????
            }
        }
    }
}
