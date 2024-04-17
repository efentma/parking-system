using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Models
{
    public enum VehicleType
    {
        Car, Motorcycle, Unknown
    }

    public class Vehicle
    {
        
        public string? LicensePlate {get; set;}
        public VehicleType Type {get; set;} 
        public DateTime CheckInTime {get; set;}
        public string? Color {get; set;}
    }
}