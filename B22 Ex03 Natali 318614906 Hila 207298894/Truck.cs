﻿using System;
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

        public enum eTruckData
        {
            NumberOfWheels = 16, MaxAirPressuer = 24, MaxAmountOfFuelInCm = 120000, Soler
        }


        //private string m_ModelName;
        //private string m_LicenseNumber;
        //private float m_RemainEnergyPercents;
        //private List<Wheel> m_ListOfWheel;
        //Engine m_engine;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_RemainEnergyPercents, List<Wheel> i_ListOfWheel, Engine i_engine,bool i_DriveRefrigeratedContents, float i_CargoCapacity) :
            base(i_engine, i_ModelName, i_LicenseNumber, i_RemainEnergyPercents, i_ListOfWheel)
        {
            m_DriveRefrigeratedContents = i_DriveRefrigeratedContents;
            m_CargoCapacity = i_CargoCapacity;
        }

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

        //public override bool ValidTypeOfFuelForThisVehicle(Engine.eFuelType i_WantedFuelType)
        //{
        //    bool answer = false;
        //    if (i_WantedFuelType.ToString() == Truck.eTruckData.Soler.ToString())
        //    {
        //        answer = true;
        //    }

        //    return answer;
        //}

        public override bool ValidTypeOfFuel(Engine.eFuelType i_WantedFuelType)
        {
            bool answer = false;
            if (i_WantedFuelType.ToString() == Truck.eTruckData.Soler.ToString())
            {
                answer = true;
            }

            return answer;
        }
    }
}
