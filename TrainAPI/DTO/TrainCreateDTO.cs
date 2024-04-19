using System.ComponentModel.DataAnnotations;

namespace TrainAPI.DTO
{
    public class TrainCreateDTO
    {
        public string Name { get; set; }

        public string StartStation { get; set; }

        public string DestinationStation { get; set; }

        public int Capacity { get; set; }

        public String DepartureTime { get; set; }

        public String ArrivalTime { get; set; }

        public String Date { get; set; }
    }
}
