using Application.Requests.User.Commands.Queries;
using AutoMapper;
using Domain.DTOs.Users;
using Domain.Entities.Securities;

namespace E_Association.Core.Application.Mapping.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationDTO, ApplicationUser>()
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
             .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
             .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            // Add this mapping for CreateUserCommandQuery to ApplicationUser
            CreateMap<RegisterUserCommand, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        }
    }
}
