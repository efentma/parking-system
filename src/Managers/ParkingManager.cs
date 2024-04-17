using System;
using System.Linq;
using ParkingSystem.Models;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.Managers
{
    public class ParkingManager
    {
        private List<ParkingLot> parkingLots;
        public ParkingManager(int totalLots)
        {
            parkingLots = Enumerable.Range(1, totalLots)
            .Select(_ => new ParkingLot { IsOccupied = false, ParkedVehicle = null })
            .ToList();
        }
        public void CheckIn(Vehicle vehicle)
        {
            var availableLot = parkingLots.FirstOrDefault(lot => !lot.IsOccupied);
            if (availableLot != null)
            {
                availableLot.IsOccupied = true;
                availableLot.ParkedVehicle = vehicle;
                vehicle.CheckInTime = DateTime.Now;
                Console.WriteLine($"Vehicle with license plate {vehicle.LicensePlate} check in");
            }
            else
            {
                Console.WriteLine("No available parking lot");
            }
        }

        public void CheckOut(string licensePlate)
        {
            var parkedLot = parkingLots.FirstOrDefault(lot => lot.IsOccupied && lot.ParkedVehicle?.LicensePlate == licensePlate);
            if (parkedLot != null)
            {
                parkedLot.IsOccupied = false;
                Console.WriteLine($"Vehicle with license plate {licensePlate} check out");
            }
            else
            {
                Console.WriteLine("Vehicle not found in the parking lot");
            }
        }

        public void GenerateReport()
         {
             int totalOccupiedLots = parkingLots.Count(lot => lot.IsOccupied);
             int totalAvailableLots = parkingLots.Count - totalOccupiedLots;
             var parkedVehicles = parkingLots.Where(lot => lot.IsOccupied).Select(lot => lot.ParkedVehicle);

             Console.WriteLine($"Total occupied lots : {totalOccupiedLots}");
             Console.WriteLine($"Total available lots : {totalAvailableLots}");

            // Menghitung tipe kendaraan
             var vehicleTypeCount = parkedVehicles?
             .Where(v => v != null)
             .GroupBy(v => v?.Type)
             .ToDictionary(g => g.Key ?? VehicleType.Unknown, g => g.Count());

             if (vehicleTypeCount != null)
             {
                 foreach (var kvp in vehicleTypeCount)
                 {
                     Console.WriteLine($"Number of {kvp.Key} vehicles: {kvp.Value}");
                 }

             }

            // Menghitung warna kendaraan
             var vehicleColorCount = parkedVehicles?
             .Where(v => v != null)
             .GroupBy(v => v?.Color)
             .ToDictionary(g => g.Key ?? "Unknown", g => g.Count());

             if (vehicleColorCount != null)
             {
                 foreach (var kvp in vehicleColorCount)
                 {
                     Console.WriteLine($"Number of {kvp.Key} vehicles: {kvp.Value}");
                 }
             }
         } 
    }
}