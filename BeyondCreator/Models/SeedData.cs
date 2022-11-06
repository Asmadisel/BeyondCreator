using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BeyondCreator.Data;
using System;
using System.Linq;
using System.Xml.Linq;

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
                //Если база данных пустая, то создаём новое оружие
                
                //Если база данных пустая, то создаём новую профу
                if(context.Character.Any())
                {
                    return;
                }
                context.Character.AddRange(
                    new Character
                    {
                        Name = "Tildus",
                        Race = "Rander",
                        PlayersName = "Test",
                        Strenght = 5,
                        Dexterity =5,
                        Perseption =5,
                        Charisma =5,
                        Intellegence =5,
                        Vitality =5,
                        Will =5,
                        Lvl =0,
                        Experience =0,
                        Weapon1 = "Меч",
                        Profession1 = "Adventurer",
                        HeadArmour = 0,
                        BodyArmour = 0,
                        ArmsArmour =0,
                        LegsArmour =0,
                        BonusArmour =0,
                        Resistance =0,
                        
                    }
                   
                    ) ;
              
                context.SaveChanges();
            }
        }
    }
}
