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

        public enum eTruckData
        {
            NumberOfWheels = 16, MaxAirPressuer = 24, MaxAmountOfFuelInCm = 120000, Soler
        }


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

        public override bool ValidTypeOfFuel(Engine.eFuelType i_WantedFuelType)
        {
            bool answer = false;
            if (i_WantedFuelType.ToString() == Truck.eTruckData.Soler.ToString())
            {
                answer = true;
            }

            return answer;
        }

        public override void AddRestDetails(Engine i_engine, StringBuilder io_vehicleData)
        {
            io_vehicleData.AppendLine(String.Format("Fuel type: {0}", eTruckData.Soler.ToString()));
            io_vehicleData.AppendLine(String.Format("Current amount of fuel: {0}", i_engine.CurrAmountOfFuelOrBattery()));
            io_vehicleData.AppendLine(String.Format("Number of wheels: {0}", eTruckData.NumberOfWheels.ToString()));
            io_vehicleData.AppendLine(String.Format("Max air pressuer: {0}", eTruckData.MaxAirPressuer.ToString()));
            io_vehicleData.AppendLine(String.Format("Max amount of fuel in cm: {0}", eTruckData.MaxAmountOfFuelInCm.ToString()));
            io_vehicleData.AppendLine(String.Format("Drive refrigerated contents: {0}", m_DriveRefrigeratedContents.ToString()));
            io_vehicleData.AppendLine(String.Format("Cargo capacity: {0}", m_CargoCapacity));
        }
    }
}
