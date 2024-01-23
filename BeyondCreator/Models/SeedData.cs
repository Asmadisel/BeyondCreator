using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BeyondCreator.Data;
using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.IdentityModel.Tokens;
using iTextSharp.tool.xml.html.head;

namespace BeyondCreator.Models
{
    public static class SeedData
    {
        public static void Initilize(IServiceProvider serviceProvider)
        {
            using (var context = new BeyondCreatorContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BeyondCreatorContext>>()))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                
                //Если пустая таблица дайсов, то создаём набор кубиков
                //if (context.Dices.IsNullOrEmpty())
                //{
                   
                //    context.Dices.AddRange(new Dice { Id=1, Name="D4"}, 
                //        new Dice { Id=2, Name="D6"},
                //        new Dice { Id=3, Name= "D8"});
                //}
                ////Если пустая таблица материалов, добавляем базовый
                //WeaponMaterial steel = new WeaponMaterial { Id=1, Name="Сталь", MaterialLvl = 1 };
                //if (context.WeaponMaterials.IsNullOrEmpty())
                //{

                //   context.WeaponMaterials.Add(steel);
                //}
                ////Если база данных пустая, то создаём новое оружие
                //if (context.Weapon.IsNullOrEmpty())
                //{
                 //Weapon Glied = new Weapon { Id = 1, Name="Gleidneer", Type = "Axe", DiceId=2, Dice= d6, DiceCount=2, WeaponMaterialId=1, WeaponMaterial = steel, damageBonus=1, Durability = 3, Firmness=3 };
                //    context.Weapon.Add(Glied);
                //}
                //Если база данных пустая, то создаём новую профу
                if (context.Character.Any())
                {
                    return;
                }
                context.Character.AddRange(
                    new Character
                    {
                        
                        
                    }
                   
                    ) ;
              
                context.SaveChanges();
            }
        }
    }
}
