using AutoMapper;
using Persistence.Entity;
using Presentation.Models;

namespace Presentation.Mapper
{
    public class MapperConfiguration :Profile
    {

        public MapperConfiguration()
        {
            CreateMap<UserModel, User>().ReverseMap();
        }
       
    }
}
