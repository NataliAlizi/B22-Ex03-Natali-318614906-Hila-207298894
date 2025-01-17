﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrAirPressuer;
        private float m_MaxAirPressuer;

        public Wheel(string i_ManufacturerName, float i_CurrAirPressuer, float i_MaxAirPressuer)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrAirPressuer = i_CurrAirPressuer;
            m_MaxAirPressuer = i_MaxAirPressuer;
        }

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

        public void WheelInflation(float i_HowMuchAirPressuerToAdd)
        {
            if (m_CurrAirPressuer + i_HowMuchAirPressuerToAdd <= m_MaxAirPressuer)
            {
                m_CurrAirPressuer += i_HowMuchAirPressuerToAdd;
            }
            else
            {
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException(string.Format("You are trying to full more then you can"), m_MaxAirPressuer, 0);
                throw valueOutOfRangeException;
            }
        }
    }
}
