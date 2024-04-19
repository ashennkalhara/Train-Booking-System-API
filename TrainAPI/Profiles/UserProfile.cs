using AutoMapper;
using TrainAPI.DTO;
using TrainAPI.Model;

namespace TrainAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
        }
    }
}
