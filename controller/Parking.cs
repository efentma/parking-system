using System;
using ParkingSystem.Models;
using ParkingSystem.Managers;
using ParkingSystemProgram;

namespace ParkingSystem.Parking
{
   public class Parking
    {
        public void ParkingApp()
        {
            var parkingManager = new ParkingManager(20);

            Console.WriteLine("Welcome to the parking system");
            Console.WriteLine("Enter 'exit' to quit at any time.");

            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Check-In Vehicle");
                Console.WriteLine("2. Check-Out Vehicle");
                Console.WriteLine("3. Generate Report");
                Console.WriteLine("4. Exit");
                Console.Write("Please select an option (1-4): ");

                string option = Console.ReadLine() ?? " ";
                if (option == "exit" || option == "4")
                    break;

                switch (option)
                {
                    case "1":
                        CheckInVehicle(parkingManager);
                        break;
                    case "2":
                        CheckOutVehicle(parkingManager);
                        break;
                    case "3":
                        GenerateReportVehicle(parkingManager);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option (1-4).");
                        break;
                }
            }

            Console.WriteLine("Thank you for using Parking System. Goodbye!");
        }

        static void CheckInVehicle(ParkingManager parkingManager)
        {
            Console.WriteLine("\nCheck-In Vehicle:");
            Console.Write("License Plate: ");
            string licensePlate = Console.ReadLine() ?? " ";

            Console.Write("Type (Car/Motorcycle): ");
            string typeInput = Console.ReadLine() ?? " ";
            if (!Enum.TryParse<VehicleType>(typeInput, true, out VehicleType vehicleType))
            {
                Console.WriteLine("Invalid vehicle type. Please enter 'Car' or 'Motorcycle'.");
                return;
            }

            Console.Write("Color: ");
            string color = Console.ReadLine() ?? " ";

            var vehicle = new Vehicle
            {
                LicensePlate = licensePlate,
                Type = vehicleType,
                Color = color
            };

            parkingManager.CheckIn(vehicle);
            Console.WriteLine("Vehicle checked in successfully.");
        }

        static void CheckOutVehicle(ParkingManager parkingManager)
        {
            Console.WriteLine("\nCheck-Out Vehicle:");
            Console.Write("License Plate: ");
            string licensePlate = Console.ReadLine() ?? " ";

            parkingManager.CheckOut(licensePlate);
            Console.WriteLine("Vehicle checked out successfully.");
        }

        static void GenerateReportVehicle(ParkingManager parkingManager)
        {
            parkingManager.GenerateReport();

        }
    }
}


