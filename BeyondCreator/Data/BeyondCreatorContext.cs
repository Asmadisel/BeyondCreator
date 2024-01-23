using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeyondCreator.Models;
using Image = BeyondCreator.Models.Image;

namespace BeyondCreator.Data
{
    public class BeyondCreatorContext : DbContext
    {
        public BeyondCreatorContext(DbContextOptions<BeyondCreatorContext> options)
            : base(options)
        {
        }
        //Блок удаляющий данные при созданни. Необходимо просто закомменить EnsureDeleted
        //public BeyondCreatorContext() {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
        //}
      
        public DbSet<BeyondCreator.Models.Character> Characters { get; set; } = default!;

        public DbSet<BeyondCreator.Models.Weapon> Weapon { get; set; } = default!;
        //Все наборы данных связанных с материалом оружия 
        public DbSet<BeyondCreator.Models.WeaponMaterial> WeaponMaterials { get; } = null!;
        public DbSet<BeyondCreator.Models.WeaponProperty> WeaponProperties { get; } = null!;
        public DbSet<BeyondCreator.Models.WeaponType> WeaponTypes { get; set; } = null!;
        //Картинки
        public DbSet<BeyondCreator.Models.Image> Images { get; set; }
        public DbSet<BeyondCreator.Models.Thing> Things { get; } = null!;
        public DbSet<BeyondCreator.Models.Armor> Armors { get; } = null!;
        
        public DbSet<BeyondCreator.Models.Dice> Dices { get; } = null!;
        public DbSet<BeyondCreator.Models.Spell> Spells { get; } = null!;
        public DbSet<BeyondCreator.Models.Ritual> Rituals { get; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        
            modelBuilder.Entity<Character>().ToTable(nameof(Character));
            modelBuilder.Entity<Weapon>().ToTable(nameof(Weapon));
            modelBuilder.Entity<WeaponMaterial>().ToTable(nameof(WeaponMaterial));
            modelBuilder.Entity<WeaponProperty>().ToTable(nameof(WeaponProperty));
            modelBuilder.Entity<WeaponType>().ToTable(nameof(WeaponType));
            modelBuilder.Entity<Image>().ToTable(nameof(Image));
            modelBuilder.Entity<Thing>().ToTable(nameof(Thing));
            modelBuilder.Entity<Armor>().ToTable(nameof(Armor));
            modelBuilder.Entity<Dice>().ToTable(nameof(Dice));
            modelBuilder.Entity<Spell>().ToTable(nameof(Spell));
            modelBuilder.Entity<Ritual>().ToTable(nameof(Ritual));
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    Dice d4 = new Dice { Id=1, Name="D4", Weapons=null};
        //    Dice d6 = new Dice { Id=2, Name="D6", Weapons=null };
        //    Dice d8 = new Dice { Id=3, Name="D8" };
        //    //Добавляем кубики
        //    modelBuilder.Entity<Dice>().HasData(d4,d6,d8);

        //    //Материалы
        //    WeaponMaterial steel = new WeaponMaterial { Id=1, Name="Сталь", MaterialLvl = 1 };
        //    modelBuilder.Entity<WeaponMaterial>().HasData(steel);

        //    Weapon Glied = new Weapon { Id = 1, Name="Gleidneer", Type = "Axe", DiceId=2, Dice= d6, DiceCount=2, WeaponMaterialId=1, WeaponMaterial = steel, damageBonus=1, Durability = 3, Firmness=3};
        //    modelBuilder.Entity<Weapon>().HasData(
        //         Glied
        //        );
        //    modelBuilder.Entity<Character>().HasData(
        //        new Character {Id=1, Name = "Test1", Race = "Elf", PlayersName = "AleksOS", Strenght= 5, Dexterity = 8, Perseption = 12, Charisma = 11, Intellegence = 12, Vitality = 12, Lvl = 2, Experience = 200, Weapon1 = Glied.Name, Profession1 = "Учёный"  }
        //        );
        //}

    }
}   