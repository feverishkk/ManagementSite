using AutoMapper;
using Management.Application.ViewModel.Accessories;
using Management.Application.ViewModel.Account;
using Management.Application.ViewModel.CommonDb.Weapons;
using Management.Application.ViewModel.Customers;
using Management.Application.ViewModel.Equipment;
using Management.Application.ViewModel.Managers;
using Management.Domain.Models;
using CommonDatabase.Models.Weapons;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Equipment;
using Management.Application.ViewModel.CommonDb.Customers;
using CommonDatabase.Models.TotalItems;
using Management.Application.ViewModel.CommonDb.TotalItems;

namespace Management.Application.ViewModel.MappInitialiser
{
    public class MappInitialiser : Profile
    {
        public MappInitialiser()
        {
            // Register
            CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
            CreateMap<ApplicationUser, LoginViewModel>().ReverseMap();
            CreateMap<ApplicationUser, ChangePasswordViewModel>().ReverseMap();
            CreateMap<ApplicationUser, ResetPasswordViewModel>().ReverseMap();
            CreateMap<ApplicationUser, ForgotPasswordViewModel>().ReverseMap();

            // Role
            CreateMap<ApplicationUser, UpdateManagerRoleViewModel>().ReverseMap();

            // Managers
            CreateMap<ApplicationUser, UpdateManagerInfoViewModel>().ReverseMap();
            CreateMap<ApplicationUser, ManagersViewModel>().ReverseMap();

            // Customer's Info
            CreateMap<CustomerInfomation, CustomersViewModel>().ReverseMap();
            CreateMap<CustomerEquipment, CustomerEquipmentViewModel>().ReverseMap();
            CreateMap<CustomersInGameInfo, CustomersInGameInfoViewModel>().ReverseMap();

            // Total
            CreateMap<CustomerTotalWeapons, TotalWeaponsViewModel>().ReverseMap();
            CreateMap<TotalEquipment, TotalEquipmentViewModel>().ReverseMap();
            CreateMap<TotalAccessories, TotalAccessoriesViewModel>().ReverseMap();

            // Accessories
            CreateMap<Accessory, BeltViewModel>().ReverseMap();
            CreateMap<Accessory, EarRingViewModel>().ReverseMap();
            CreateMap<Accessory, NecklessViewModel>().ReverseMap();
            CreateMap<Accessory, RingViewModel>().ReverseMap();

            // Equipment
            CreateMap<DefendEquipment, ArmorViewModel>().ReverseMap();
            CreateMap<DefendEquipment, BootsViewModel>().ReverseMap();
            CreateMap<DefendEquipment, CapeViewModel>().ReverseMap();
            CreateMap<DefendEquipment, GlobeViewModel>().ReverseMap();
            CreateMap<DefendEquipment, GuardViewModel>().ReverseMap();
            CreateMap<DefendEquipment, HelmetViewModel>().ReverseMap();
            CreateMap<DefendEquipment, TShirtViewModel>().ReverseMap();

            // Weapon
            CreateMap<Weapon, DaggerViewModel>().ReverseMap();
            CreateMap<Weapon, OneHandBowViewModel>().ReverseMap();
            CreateMap<Weapon, OneHandStickViewModel>().ReverseMap();
            CreateMap<Weapon, OneHandSwordViewModel>().ReverseMap();
            CreateMap<Weapon, TwoHandBowViewModel>().ReverseMap();
            CreateMap<Weapon, TwoHandStickViewModel>().ReverseMap();
            CreateMap<Weapon, TwoHandSwordViewModel>().ReverseMap();

        }
    }
}
