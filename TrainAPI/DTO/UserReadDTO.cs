using System.ComponentModel.DataAnnotations;

namespace TrainAPI.DTO
{
    public class UserReadDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string NIC { get; set; }
    }
}
