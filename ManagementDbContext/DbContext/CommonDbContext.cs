using CommonDatabase.Models.Accessories;
using CommonDatabase.Models.Customers;
using CommonDatabase.Models.Equipment;
using CommonDatabase.Models.TotalItems;
using CommonDatabase.Models.Weapons;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<CustomerEquipment> CustomerEquipment { get; set; } = default;
        public DbSet<CustomersInGameInfo> CustomerInGameInfo { get; set; } = default;
        public DbSet<Acc> Acc { get; set; } = default;

        public DbSet<CustomerTotalWeapons> TotalWeapon { get; set; } = default;
        public DbSet<TotalEquipment> TotalEquipment { get; set; } = default;
        public DbSet<TotalAccessories> TotalAccessories { get; set; } = default;

        public DbSet<DefendEquipment> Armor { get; set; } = default;
        public DbSet<DefendEquipment> TShirt { get; set; } = default;
        public DbSet<DefendEquipment> Cape { get; set; } = default;
        public DbSet<DefendEquipment> Globe { get; set; } = default;
        public DbSet<DefendEquipment> Guard { get; set; } = default;
        public DbSet<DefendEquipment> Helmet { get; set; } = default;
        public DbSet<DefendEquipment> Boots { get; set; } = default;

        public DbSet<Neckless> Neckless { get; set; } = default;
        public DbSet<Belt> Belt { get; set; } = default;
        public DbSet<Ring1> Ring1 { get; set; } = default;
        public DbSet<Ring2> Ring2 { get; set; } = default;
        public DbSet<EarRing> EarRing { get; set; } = default;

        public DbSet<Weapon> Dagger { get; set; } = default;
        public DbSet<Weapon> OneHandBow { get; set; } = default;
        public DbSet<Weapon> OneHandSword { get; set; } = default;
        public DbSet<Weapon> OneHandStick { get; set; } = default;
        public DbSet<Weapon> TwoHandSword { get; set; } = default;
        public DbSet<Weapon> TwoHandBow { get; set; } = default;
        public DbSet<Weapon> TwoHandStick { get; set; } = default;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Acc>().HasNoKey();
            base.OnModelCreating(builder);
        }
    }
}
