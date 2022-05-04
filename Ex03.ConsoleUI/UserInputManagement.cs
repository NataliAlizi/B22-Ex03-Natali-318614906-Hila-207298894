using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UserInputManagement
    {
        private static void getNewVehicleAndHisData()
        {
            int vehicleTypeInInt = 0, fuelOrElectricInInt = 0;
            string ownerName = string.Empty, ownerPhone = string.Empty, modelName = string.Empty, licenseNumber = string.Empty,
                wheelManufacturerName = string.Empty;
            float leftEnergy = 0, currAirPressuer= 0;

            Console.WriteLine(string.Format("Hello, welcome to our garage"));

            vehicleTypeInInt = getAndCheckValidVehicleType();
            if (vehicleTypeInInt == 1 || vehicleTypeInInt == 2) //Car or motorcycle
            {
                fuelOrElectricInInt = getAndCheckFuelOrElectricType();
            }
            getOwnerDetails(ownerName, ownerPhone);
            getModelNameAndLicenseNumber(modelName, licenseNumber);
            //leftEnergy = getLeftEnergy(vehicleTypeInInt, fuelOrElectricInInt);
            currAirPressuer = getCurrAirPressuerAndWheelManufacturerName(wheelManufacturerName);
        }

        private static int getAndCheckValidVehicleType()
        {
            bool validInput = false;
            int choiceNumber = 0;
            string vehicleType;
           
            do
            {
                Console.WriteLine(string.Format("Please enter your vehicle type:{0}1.Car{0}2.Motorcycle{0}3.Truck", Environment.NewLine));
                vehicleType = Console.ReadLine();
                try
                {
                    validInput = int.TryParse(vehicleType, out choiceNumber);
                    if (choiceNumber == 1 || choiceNumber == 2 || choiceNumber == 3)
                    {
                        validInput = true;
                    }
               
                }
                catch (FormatException ex)
                {
                    throw ex;
                }
            }
            while (!validInput);

            return choiceNumber;
        }

        private static int getAndCheckFuelOrElectricType()
        {
            bool validInput = false;
            int choiceNumber = 0;
            string vehicleType;

            do
            {
                Console.WriteLine(string.Format("Press 1 for fuel type, 2 for electric type"));
                vehicleType = Console.ReadLine();
                try
                {
                    validInput = int.TryParse(vehicleType, out choiceNumber);
                    if (choiceNumber == 1 || choiceNumber == 2)
                    {
                        validInput = true;
                    }
                }
                catch (FormatException ex)
                {
                    throw ex;
                }
            }
            while (!validInput);

            return choiceNumber;
        }

        private static void getOwnerDetails(string o_OwnerName, string o_OwnerPhoneNumber)
        {
            bool validNumber = false;
            Console.WriteLine(string.Format("Please enter your name"));
            o_OwnerName = Console.ReadLine();
            do
            {
                Console.WriteLine(string.Format("Please enter your phone number"));
                o_OwnerPhoneNumber = Console.ReadLine();
                if (o_OwnerPhoneNumber.Length == 10 && validPhoneNumber(o_OwnerPhoneNumber))
                {
                    validNumber = true;
                }
            }
            while (!validNumber);
        }

        private static bool validPhoneNumber(string i_PhoneNumber)
        {
            bool answer = true;
            for (int i = 0; i < i_PhoneNumber.Length; i++)
            {
                if ((i == 0 && i_PhoneNumber[i] != '0') || (i == 1 && i_PhoneNumber[i] != '5') ||
                    (i == 2 && (i_PhoneNumber[i] != 0 || i_PhoneNumber[i] != 2 || i_PhoneNumber[i] != 3 || i_PhoneNumber[i] != 4 || i_PhoneNumber[i] != 5))
                    || (i_PhoneNumber[i] < '0' || i_PhoneNumber[i] > '9'))
                {
                    answer = false;
                }
            }
            return answer;
        }

        private static void getModelNameAndLicenseNumber(string o_ModelName, string o_LicenseNumber)
        {

            bool validLicenseNumber = true;
            Console.WriteLine(string.Format("Please enter your vehicle model name"));
            o_ModelName = Console.ReadLine();

            do
            {
                Console.WriteLine(string.Format("Please enter your vehicle license number"));
                o_LicenseNumber = Console.ReadLine();
                if (o_LicenseNumber.Length == 7 || o_LicenseNumber.Length == 8)
                {
                    foreach (char number in o_LicenseNumber)
                    {
                        if (number < '0' || number > '9')
                        {
                            validLicenseNumber = false;
                            break;
                        }
                    }
                }
                else
                {
                    validLicenseNumber = false;
                }
            }
            while (validLicenseNumber == false);
        }

        private static float getCurrAirPressuerAndWheelManufacturerName(string o_WheelManufacturerName)
        {
            float currAirPressuer = 0f;
            bool validAirPressuer = false;
            Console.WriteLine(string.Format("Please enter your wheel manufacturer name"));
            o_WheelManufacturerName = Console.ReadLine();

            do
            {

            }
            while()
            return currAirPressuer;
        }

    //    private static float getLeftEnergy(int i_VehicleType, int i_FuelOrElectric)  /// 1=car, 2=motorcycle, 3=truck / 1=fuel, 2=electric
    //    {
    //        string userInput = string.Empty;
    //        float leftEnergy = 0;
    //        bool validNumber = false;

        //        do
        //        {
        //            if (i_FuelOrElectric == 1)
        //            {
        //                Console.WriteLine(string.Format("Please enter the current amount of fuel"));
        //            }
        //            else
        //            {
        //                Console.WriteLine(string.Format("Please enter the current amount of battery"));
        //            }
        //            userInput = Console.ReadLine();
        //            if(validInputOfLeftEnergyPerVehicle(i_VehicleType, i_FuelOrElectric))
        //            {

        //            }

        //        }
        //        while (!validNumber);

        //        return leftEnergy;
        //    }
        //}
    }
