using System;
using System.ComponentModel.DataAnnotations;

namespace TrainAPI.Model
{
    public class Train
    {
        [Key]
        public int TrainId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string StartStation { get; set; }

        [Required]
        public string DestinationStation { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public String DepartureTime { get; set; }

        [Required]
        public String ArrivalTime { get; set; }

        [Required]
        public String Date {  get; set; }
    }
}

