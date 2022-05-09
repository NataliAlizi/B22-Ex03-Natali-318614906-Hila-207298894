using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserManagement
    {
        private Garage m_Garage = new Garage();
        private GarageMeneger m_GarageMeneger = new GarageMeneger();

        public void PrintGarageMenu()
        {
            int userChoice;
            bool validParse = false, validChoice = false, end = false;
            while (!end)
            {
                do
                {
                    StringBuilder menu = new StringBuilder();
                    menu.AppendLine("Hello, Welcome to our garage. Please select the desired service:");
                    menu.AppendLine("1.Put a new car in the garage. ");
                    menu.AppendLine("2.Display list of license numbers of the vehicles in the garage(with option to filter by a specific status).");
                    menu.AppendLine("3.Change vehicle condition in the garage.");
                    menu.AppendLine("4.Inflate air in the vehicle wheels to the maximum.");
                    menu.AppendLine("5.Refuel a fuel-powered vehicle or charge an electric vehicle");
                    menu.AppendLine("6.Display complete vehicle data.");
                    menu.AppendLine("7.Exit garage program.");
                    Console.WriteLine(menu);
                    validParse = int.TryParse(Console.ReadLine(), out userChoice);
                    Console.Clear();

                    if (validParse && userChoice < 8 && userChoice > 0)
                    {
                        validChoice = true;
                    }
                }
                while (!validParse || !validChoice);

                if (userChoice != 7)
                {
                    handlingUserSelection(userChoice, ref end);
                }
                else
                {
                    end = true;
                }
            }
        }

        private void handlingUserSelection(int i_UserChoice, ref bool io_End)
        {
            try
            {
                Console.Clear();
                switch (i_UserChoice)
                {
                    case 1:
                        string ownerName = string.Empty, ownerPhone = string.Empty;
                        getOwnerDetails(ref ownerName, ref ownerPhone);
                        m_Garage.AddVehicle(ownerName, ownerPhone, GetNewVehicleAndHisData());
                        break;
                    case 2:
                        checkIfTheUserWantsFilteringInVehicleStatusAndPrint();
                        break;
                    case 3:
                        checkNewStatusAndChange();
                        break;
                    case 4:
                        m_Garage.WheelInflationToMax(getLicenseNumber());
                        break;
                    case 5:
                        refulingVehicle();
                        break;
                    case 6:
                        displayDada();
                        break;

                    default:
                        break;
                }

                checkIfUserWantContinue(i_UserChoice, ref io_End);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void checkIfUserWantContinue(int i_UserChoice, ref bool io_End)
        {
            string answer = string.Empty;
            bool validInput = false, validParse = false;
            int userChoice;
            do
            {
                Console.WriteLine(string.Format("Press 1 to return to the main menu, 0 to exit"));
                answer = Console.ReadLine();
                validParse = int.TryParse(answer, out userChoice);
                if (validParse && userChoice == 1)
                {
                    validInput = true;
                }
                else if (validParse && userChoice == 0)
                {
                    validInput = true;
                    io_End = true;
                }
            }
            while (!validInput || !validParse);
            Console.Clear();
        }

        private void refulingVehicle()
        {
            string licenseNumber = getLicenseNumber();
            int fuelType = getWantedFuelType();
            float amountToFuelOrCharge = getHowMuchToRefuel();
            m_Garage.RefulingVehicle(licenseNumber, (GarageLogic.Engine.eFuelType)fuelType, amountToFuelOrCharge);
        }

        private float getHowMuchToRefuel()
        {
            float amountToFuelOrCharge = 0;
            bool validParse = false;
            do
            {
                Console.Clear();
                Console.WriteLine(string.Format("Please enter amount of fuel for fuel type car or how much to charge for electric car:"));
                validParse = float.TryParse(Console.ReadLine(), out amountToFuelOrCharge);
            }
            while (!validParse);

            return amountToFuelOrCharge;
        }

        private int getWantedFuelType()
        {
            int fuelType = 0;
            bool validParse = false, validType = false;
            do
            {
                Console.Clear();
                StringBuilder options = new StringBuilder();
                options.AppendLine("Please choose fuel type to reful, if you have an electruc car choose 0:");
                options.AppendLine("0.None");
                options.AppendLine("1.Soler");
                options.AppendLine("2.Octan95");
                options.AppendLine("3.Octan96");
                options.AppendLine("4.Octan98");
                Console.WriteLine(options);
                validParse = int.TryParse(Console.ReadLine(), out fuelType);
                if (validParse && fuelType < 5 && fuelType >= 0)
                {
                    validType = true;
                }
            }
            while (!validParse || !validType);

            return fuelType;
        }

        private void displayDada()
        {
            StringBuilder vehicleDatas = m_Garage.DisplaysVehicleData(getLicenseNumber());
            Console.WriteLine(vehicleDatas);
        }

        private void checkNewStatusAndChange()
        {
            int userChoice;
            bool validChoice = false, validParse = false;
            do
            {
                Console.Clear();
                StringBuilder options = new StringBuilder();
                options.AppendLine("Please select the new status of the vehicle:");
                options.AppendLine("1.In repair");
                options.AppendLine("2.Fixed");
                options.AppendLine("3.Paid");
                Console.WriteLine(options);
                validParse = int.TryParse(Console.ReadLine(), out userChoice);
                if (validParse && userChoice < 5 && userChoice > 0)
                {
                    validChoice = true;
                }
            }
            while (!validChoice || !validParse);

            m_Garage.ChangeVehicleStatus(getLicenseNumber(), userChoice);
        }

        private string getLicenseNumber()
        {
            string licenseNumber = string.Empty;
            bool validLicenseNumber = true;

            do
            {
                validLicenseNumber = true;
                Console.Clear();
                Console.WriteLine(string.Format("Please enter your vehicle license number:"));
                licenseNumber = Console.ReadLine();
                if (licenseNumber.Length == 7 || licenseNumber.Length == 8)
                {
                    foreach (char number in licenseNumber)
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

            return licenseNumber;
        }

        private void checkIfTheUserWantsFilteringInVehicleStatusAndPrint()
        {
            int userChoice;
            bool validChoice = false, validParse = false;
            do
            {
                Console.Clear();
                StringBuilder options = new StringBuilder();
                options.AppendLine("Please select the vehicle types you would like to view:");
                options.AppendLine("0.Everyone");
                options.AppendLine("1.In repair");
                options.AppendLine("2.Fixed");
                options.AppendLine("3.Paid");
                Console.WriteLine(options);
                validParse = int.TryParse(Console.ReadLine(), out userChoice);
                if (validParse && userChoice < 4 && userChoice >= 0)
                {
                    validChoice = true;
                }
            }
            while (!validChoice || !validParse);

            List<string> licenseNumbers = m_Garage.DisplayLicenseNumber(userChoice);

            foreach (string licenseNumber in licenseNumbers)
            {
                Console.WriteLine(licenseNumber);
            }
        }

        public void GetEngine(ref int io_TypeOfEngine, Vehicle io_Vehicle)
        {
            if (io_Vehicle is Truck)
            {
                io_TypeOfEngine = 1;
            }
            else
            {
                io_TypeOfEngine = getAndCheckFuelOrElectricType();
            }

            if (io_TypeOfEngine == 1)
            {
                io_Vehicle.MyEngine = new FuelType();
            }
            else
            {
                io_Vehicle.MyEngine = new ElectricType();
            }
        }

        public Vehicle GetNewVehicle(ref int io_TypeOfVehicle)
        {
            io_TypeOfVehicle = getAndCheckValidVehicleType();
            return m_GarageMeneger.MakeNewVehicle(io_TypeOfVehicle);
        }

        public Vehicle GetNewVehicleAndHisData()
        {
            int vehicleTypeInInt = 0, fuelOrElectricInInt = 0;
            string modelName = string.Empty, licenseNumber = string.Empty, wheelManufacturerName = string.Empty;
            List<string> questionForVehicle = new List<string>();
            Vehicle vehicle = GetNewVehicle(ref vehicleTypeInInt);
            GetEngine(ref fuelOrElectricInInt, vehicle);
            getModelNameAndLicenseNumber(ref modelName, ref licenseNumber);
            m_Garage.SetQuestion(questionForVehicle, vehicle);
            askQuestionAndCheckAnswer(questionForVehicle, vehicle);
            setData(vehicle, licenseNumber, modelName);

            return vehicle;
        }

        private void setData(Vehicle io_vehicle, string i_LlicenseNumber, string i_ModelName)
        {
            io_vehicle.LicenseNumber = i_LlicenseNumber;
            io_vehicle.ModelName = i_ModelName;
            io_vehicle.RemainEnergyPercents = io_vehicle.MyEngine.CurrAmountOfFuelOrBattery() / io_vehicle.MyEngine.MaxAmountOfFuelOrBattery() * 100;
        }

        private void askQuestionAndCheckAnswer(List<string> i_QuestionForVehicle, Vehicle io_Vehicle)
        {
            int index = 0;
            string answer = string.Empty;
            bool answerOkForThisQuestion = false;
            List<string> answerList = new List<string>();
            foreach (string question in i_QuestionForVehicle)
            {
                answerOkForThisQuestion = false;
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
            foreach (GarageMeneger.eVehicleType vehicleTypes in Enum.GetValues(typeof(GarageMeneger.eVehicleType)))
            {
                typeOfVehicle.Append(++index + ") " + vehicleTypes + " ");
            }

            do
            {
                Console.Clear();
                Console.WriteLine(typeOfVehicle);
                vehicleType = Console.ReadLine();
                validParse = int.TryParse(vehicleType, out choiceNumber);
                if (choiceNumber > 0 && choiceNumber < 4)
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
                    ((i == 2 && (i_PhoneNumber[i] != 0 && i_PhoneNumber[i] != 2 && i_PhoneNumber[i] != 3 && i_PhoneNumber[i] != 4 && i_PhoneNumber[i] != 5))
                    && (i_PhoneNumber[i] < '0' || i_PhoneNumber[i] > '9')))
                {
                    answer = false;
                }
            }

            return answer;
        }

        private void getModelNameAndLicenseNumber(ref string o_ModelName, ref string o_LicenseNumber)
        {
            Console.Clear();
            Console.WriteLine(string.Format("Please enter your vehicle model name"));
            o_ModelName = Console.ReadLine();
            bool validLicenseNumber = true;

            do
            {
                validLicenseNumber = true;
                Console.Clear();
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
    }
}