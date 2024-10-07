using AutoMapper;
using System.Runtime.InteropServices;
using TMS1.Model.Dtos;
using TMS1.Model.Entity;

public class AutoMapper1 : Profile
{
    public AutoMapper1()
    {
        CreateMap<Users, UserDto>()
            .ReverseMap();

        CreateMap<Mission, MissionDto>();
            //.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username)); //

        CreateMap<MissionDto, Mission>()
            .ForMember(dest => dest.MissionId, opt => opt.MapFrom(src => src.MissionId))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.User, opt => opt.Ignore()); //

        CreateMap<Roles, RolesDto>();
        CreateMap<RegisterDto, UserDto>();
        CreateMap<RegisterDto, Users>();
        CreateMap<LoginDto, UserDto>();
        CreateMap<UserDto, Users>();

    }
}
