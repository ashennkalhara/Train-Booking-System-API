namespace TrainAPI.DTO
{
    public class BookingCreateDTO
    {
        public int TrainId { get; set; }

        public string NIC { get; set; }

        public string StartStation { get; set; }

        public string DestinationStation { get; set; }

        public int SeatCapacity { get; set; }

        public String DepartureTime { get; set; }

        public String ArrivalTime { get; set; }

        public String Date { get; set; }
    }
}
