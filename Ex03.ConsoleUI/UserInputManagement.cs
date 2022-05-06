using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UserInputManagement
    {

        private Ex03.GarageLogic.Garage m_Garage = new Ex03.GarageLogic.Garage();
        private Ex03.GarageLogic.GarageMeneger m_GarageMeneger = new Ex03.GarageLogic.GarageMeneger();

        public void GetEngine(ref int io_TypeOfEngine, Ex03.GarageLogic.Vehicle io_Vehicle)
        {
            if (io_Vehicle is Ex03.GarageLogic.Truck)
            {
                io_TypeOfEngine = 1;
            }
            else
            {
                io_TypeOfEngine = getAndCheckFuelOrElectricType();
            }
            if (io_TypeOfEngine == 1)
            {
                io_Vehicle.MyEngine = new Ex03.GarageLogic.FuelType();
            }
            else
            {
                io_Vehicle.MyEngine = new Ex03.GarageLogic.ElectricType();
            }

        }

        public Ex03.GarageLogic.Vehicle GetNewVehicle(ref int io_TypeOfVehicle)
        {
            io_TypeOfVehicle = getAndCheckValidVehicleType();
            return m_GarageMeneger.MakeNewVehicle(io_TypeOfVehicle);
        }

        public void GetNewVehicleAndHisData()
        {
            int vehicleTypeInInt = 0, fuelOrElectricInInt = 0;
            string ownerName = string.Empty, ownerPhone = string.Empty, modelName = string.Empty, licenseNumber = string.Empty,
                wheelManufacturerName = string.Empty;
            List<string> questionForVehicle = new List<string>();

            Console.WriteLine(string.Format("Hello, welcome to our garage"));

            Ex03.GarageLogic.Vehicle vehicle = GetNewVehicle(ref vehicleTypeInInt);
            GetEngine(ref fuelOrElectricInInt, vehicle);

            getOwnerDetails(ref ownerName, ref ownerPhone);
            getModelNameAndLicenseNumber(ref modelName, ref licenseNumber);

            m_Garage.SetQuestion(questionForVehicle, vehicle);
            AskQuestionAndCheckAnswer(questionForVehicle, vehicle);
            setData(vehicle, licenseNumber, modelName);

        }

        private void setData(Ex03.GarageLogic.Vehicle io_vehicle, string i_LlicenseNumber, string i_ModelName)
        {
            io_vehicle.LicenseNumber = i_LlicenseNumber;
            io_vehicle.ModelName = i_ModelName;

        }

        private void AskQuestionAndCheckAnswer(List<string> i_QuestionForVehicle, Ex03.GarageLogic.Vehicle io_Vehicle)
        {
            int index = 0;
            string answer = string.Empty;
            bool answerOkForThisQuestion = false;
            List<string> answerList = new List<string>();
            foreach (string question in i_QuestionForVehicle)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine(question);
                    answer = Console.ReadLine();
                    answerList.Add(answer);
                    m_Garage.CheckAnswer(answerList, index, ref answerOkForThisQuestion, io_Vehicle);
                    if (answerOkForThisQuestion)
                    {
                        index++;
                    }
                }
                while (!answerOkForThisQuestion);

            }
            io_Vehicle.SetAnswerForVehicle(answerList);
        }

        private int getAndCheckValidVehicleType()
        {
            bool validInput = false, validParse = false;
            int choiceNumber = 0, index = 0;
            string vehicleType;
            StringBuilder typeOfVehicle = new StringBuilder("Please enter your vehicle type  ");
            foreach (Ex03.GarageLogic.GarageMeneger.eVehicleType vehicleTypes in Enum.GetValues(typeof(Ex03.GarageLogic.GarageMeneger.eVehicleType)))
            {
                typeOfVehicle.Append(++index + ") " + vehicleTypes + " ");
            }
            do
            {
                Console.Clear();//לבדוק אם יש משהו שזה לא של הקונסול
                Console.WriteLine(typeOfVehicle);
                vehicleType = Console.ReadLine();
                validParse = int.TryParse(vehicleType, out choiceNumber);//לעדכן את הילה שזה לא נכון מה שהיא עשתה פה+אין צורך באקספשניין כי זה מה שהטרי פרס בודק
                if (choiceNumber >= 1 && choiceNumber <= (Enum.GetNames(typeof(Ex03.GarageLogic.GarageMeneger.eVehicleType)).Length))
                {
                    validInput = true;
                }
            }
            while (!validInput || !validParse);

            return choiceNumber;
        }

        private int getAndCheckFuelOrElectricType()
        {
            bool validInput = false, validParse = false;
            int choiceNumber = 0;
            string vehicleType;
            do
            {
                Console.WriteLine(string.Format("Press 1 for fuel type, 2 for electric type"));
                vehicleType = Console.ReadLine();

                validParse = int.TryParse(vehicleType, out choiceNumber);
                if ((choiceNumber == 1 || choiceNumber == 2) && validParse)
                {
                    validInput = true;
                }

            }
            while (!validInput || !validParse);

            return choiceNumber;
        }

        private void getOwnerDetails(ref string o_OwnerName, ref string o_OwnerPhoneNumber)
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

        private bool validPhoneNumber(string i_PhoneNumber)
        {
            bool answer = true;
            for (int i = 0; i < i_PhoneNumber.Length; i++)
            {
                if ((i == 0 && i_PhoneNumber[i] != '0') || (i == 1 && i_PhoneNumber[i] != '5') ||
                    (i == 2 && (i_PhoneNumber[i] != 0 && i_PhoneNumber[i] != 2 && i_PhoneNumber[i] != 3 && i_PhoneNumber[i] != 4 && i_PhoneNumber[i] != 5))
                    && (i_PhoneNumber[i] < '0' || i_PhoneNumber[i] > '9'))
                {
                    answer = false;
                }
            }
            return answer;
        }

        private void getModelNameAndLicenseNumber(ref string o_ModelName, ref string o_LicenseNumber)
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

        //private static float getCurrAirPressuerAndWheelManufacturerName(string o_WheelManufacturerName)
        //{
        //    float currAirPressuer = 0f;
        //    bool validAirPressuer = false;
        //    Console.WriteLine(string.Format("Please enter your wheel manufacturer name"));
        //    o_WheelManufacturerName = Console.ReadLine();

        //    do
        //    {

        //    }
        //    while()
        //    return currAirPressuer;
        //}

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
}
