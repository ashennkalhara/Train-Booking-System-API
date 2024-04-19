using System.ComponentModel.DataAnnotations;

namespace TrainAPI.Model
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int TrainId { get; set; }

        [Required]
        public string NIC { get; set; }

        [Required]
        public string StartStation { get; set; }

        [Required]
        public string DestinationStation { get; set; }

        [Required]
        public int SeatCapacity { get; set; }

        [Required]
        public String DepartureTime { get; set; }

        [Required]
        public String ArrivalTime { get; set; }

        [Required]
        public String Date { get; set; }

    }
}
