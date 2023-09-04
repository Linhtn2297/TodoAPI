using AutoMapper;

namespace ToDoAPI.Commons
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /// Mapping TodoDTO to Todo and reverse
            CreateMap<TodoDTO, Todo>().ReverseMap();
        }
    }
}
