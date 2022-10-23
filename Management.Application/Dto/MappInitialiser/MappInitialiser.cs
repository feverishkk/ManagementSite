using AutoMapper;
using Management.Application.Dto.Accessories;
using Management.Application.Dto.Account;
using Management.Application.Dto.CommonDb.Weapons;
using Management.Application.Dto.Customers;
using Management.Application.Dto.Equipment;
using Management.Application.Dto.Managers;
using Management.Domain.Models;
using CommonDatabase.Models.Weapons;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using Management.Application.Dto.CommonDb.Customers;
using CommonDatabase.Models.TotalItems;
using Management.Application.Dto.CommonDb.TotalItems;

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

            // Customer's Info
            CreateMap<CustomerInfomation, CustomersDto>().ReverseMap();
            CreateMap<CustomerEquipment, CustomerEquipmentDto>().ReverseMap();
            CreateMap<CustomersInGameInfo, CustomersInGameInfoDto>().ReverseMap();

            // Total
            CreateMap<TotalWeapons, TotalWeaponsDto>().ReverseMap();
            CreateMap<TotalEquipment, TotalEquipmentDto>().ReverseMap();
            CreateMap<TotalAccessories, TotalAccessoriesDto>().ReverseMap();

            // Accessories
            CreateMap<Accessory, BeltDto>().ReverseMap();
            CreateMap<Accessory, EarRingDto>().ReverseMap();
            CreateMap<Accessory, NecklessDto>().ReverseMap();
            CreateMap<Accessory, RingDto>().ReverseMap();

            // Equipment
            CreateMap<DefendEquipment, ArmorDto>().ReverseMap();
            CreateMap<DefendEquipment, BootsDto>().ReverseMap();
            CreateMap<DefendEquipment, CapeDto>().ReverseMap();
            CreateMap<DefendEquipment, GlobeDto>().ReverseMap();
            CreateMap<DefendEquipment, GuardDto>().ReverseMap();
            CreateMap<DefendEquipment, HelmetDto>().ReverseMap();
            CreateMap<DefendEquipment, TShirtDto>().ReverseMap();

            // Weapon
            CreateMap<Weapon, DaggerDto>().ReverseMap();
            CreateMap<Weapon, OneHandBowDto>().ReverseMap();
            CreateMap<Weapon, OneHandStickDto>().ReverseMap();
            CreateMap<Weapon, OneHandSwordDto>().ReverseMap();
            CreateMap<Weapon, TwoHandBowDto>().ReverseMap();
            CreateMap<Weapon, TwoHandStickDto>().ReverseMap();
            CreateMap<Weapon, TwoHandSwordDto>().ReverseMap();

        }
    }
}
