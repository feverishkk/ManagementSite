using AutoMapper;
using Management.Application.Dto.Account;
using Management.Application.Dto.Customers;
using Management.Application.Dto.Managers;
using Management.Domain.Models;

namespace Management.Application.Dto.MappInitialiser
{
    public class MappInitialiser : Profile
    {
        public MappInitialiser()
        {
            // Register
            CreateMap<ApplicationUser, RegisterDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginDto>().ReverseMap();
            CreateMap<ApplicationUser, ChangePasswordDto>().ReverseMap();
            CreateMap<ApplicationUser, ResetPasswordDto>().ReverseMap();
            CreateMap<ApplicationUser, ForgotPasswordDto>().ReverseMap();

            // Role
            CreateMap<ApplicationUser, UpdateManagerRoleDto>().ReverseMap();

            // Managers
            CreateMap<ApplicationUser, UpdateManagerInfoDto>().ReverseMap();
            CreateMap<ApplicationUser, ManagersDto>().ReverseMap();

            // Customers
            CreateMap<CommonDatabase.Models.Customers, CustomersDto>().ReverseMap();
        }
    }
}
