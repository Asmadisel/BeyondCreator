using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeyondCreator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BeyondCreator.Data
{
    public class BeyondCreatorContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public BeyondCreatorContext(DbContextOptions<BeyondCreatorContext> options)
            : base(options)
        {
        }
      
        public DbSet<BeyondCreator.Models.Character> Character { get; set; } = default!;

        public DbSet<BeyondCreator.Models.Weapon> Weapon { get; set; } = default!;
        public DbSet<BeyondCreator.Models.WeaponMaterial> WeaponMaterials { get; } = null!;
        public DbSet<BeyondCreator.Models.WeaponProperty> WeaponProperties { get; } = null!;
        public DbSet<BeyondCreator.Models.Thing> Things { get; } = null!;
        public DbSet<BeyondCreator.Models.Armor> Armors { get; } = null!;
        
        public DbSet<BeyondCreator.Models.Dice> Dices { get; } = null!;
        public DbSet<BeyondCreator.Models.Spell> Spells { get; } = null!;
        public DbSet<BeyondCreator.Models.Ritual> Rituals { get; } = null!;
    }
}   