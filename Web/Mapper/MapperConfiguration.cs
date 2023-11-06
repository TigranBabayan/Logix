using AutoMapper;
using Persistence.Entity;
using Web.Models;

namespace Web.Mapper
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<UserModel, User>().ReverseMap();
        }

    }
}
