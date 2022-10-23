using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementDbContext.DbContext
{
    /// <summary>
    /// 고객들을 관리하는 Context
    /// </summary>
    public class CommonDbContext : IdentityDbContext
    {
        public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
        {

        }

        public DbSet<CustomerInfomation> Customers { get; set; } = default;
        public DbSet<CustomersEquipment> UserEquipment { get; set; } = default;
        public DbSet<CustomersInGameInfo> UserInGameInfo { get; set; } = default;

        public DbSet<TotalWeapons> TotalWeapon { get; set; } = default;
        //public DbSet<TotalEquipment> TotalEquipment { get; set; } = default;
        //public DbSet<TotalAccessories> TotalAccessories { get; set; } = default;

        public DbSet<DefendEquipment> Armor { get; set; } = default;
        public DbSet<DefendEquipment> TShirt { get; set; } = default;
        public DbSet<DefendEquipment> Cape { get; set; } = default;
        public DbSet<DefendEquipment> Globe { get; set; } = default;
        public DbSet<DefendEquipment> Guard { get; set; } = default;
        public DbSet<DefendEquipment> Helmet { get; set; } = default;
        public DbSet<DefendEquipment> Boots { get; set; } = default;

        public DbSet<Accessory> Neckless { get; set; } = default;
        public DbSet<Accessory> Belt { get; set; } = default;
        public DbSet<Accessory> Ring { get; set; } = default;
        public DbSet<Accessory> EarRing { get; set; } = default;

        public DbSet<Weapon> Dagger { get; set; } = default;
        public DbSet<Weapon> OneHandBow { get; set; } = default;
        public DbSet<Weapon> OneHandSword { get; set; } = default;
        public DbSet<Weapon> OneHandStick { get; set; } = default;
        public DbSet<Weapon> TwoHandSword { get; set; } = default;
        public DbSet<Weapon> TwoHandBow { get; set; } = default;
        public DbSet<Weapon> TwoHandStick { get; set; } = default;
    }
}
