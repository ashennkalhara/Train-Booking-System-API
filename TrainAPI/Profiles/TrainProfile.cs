using AutoMapper;
using TrainAPI.DTO;
using TrainAPI.Model;

namespace TrainAPI.Profiles
{
    public class TrainProfile : Profile
    {
        public TrainProfile()
        {
            CreateMap<Train, TrainReadDTO>();
            CreateMap<TrainCreateDTO, Train>();
        }
    }
}
