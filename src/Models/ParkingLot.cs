namespace ParkingSystem.Models
{
    public class ParkingLot
    {
        public bool IsOccupied {get; set;}
        public Vehicle? ParkedVehicle {get; set;}
    }
}