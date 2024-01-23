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
        public static void Initilize(BeyondCreatorContext context)
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
                if (context.Characters.Any())
                {
                    return;
                }
                //Создадим контекст базы данных
                //var dices = new Dice[]
                //{
                //    new Dice {Name="D4"},
                //    new Dice{Name = "D6"},
                //    new Dice{Name="D8"},
                //    new Dice{Name="D10"},
                //    new Dice{Name="D12"},
                //    new Dice{Name="D20"}
                //};
                
                    context.Dices.Add(new Dice { Name="D4", WeaponProperties });
                
                var wep = new WeaponMaterial[]
                {
                    new WeaponMaterial{Name="Бронза", MaterialLvl=0, Date= DateTime.Now},
                    new WeaponMaterial{Name="Железо", MaterialLvl=1, Date= DateTime.Now},
                    new WeaponMaterial{Name="Сталь", MaterialLvl =2, Date= DateTime.Now},
                    new WeaponMaterial{Name="Алхир", MaterialLvl=3, Date= DateTime.Now},
                    new WeaponMaterial{Name="Звёздная сталь", MaterialLvl=4, Date= DateTime.Now},
                    new WeaponMaterial{Name="Ангелик", MaterialLvl=5, Date= DateTime.Now},
                };
                foreach(var weapon in wep)
                {
                    context.WeaponMaterials.Add(weapon);
                }
                var prop = new WeaponProperty[]
                {
                    new WeaponProperty{Name="Лёгкое", Description="Подготовка к бою легкого оружия не занимает действия. Его легче спрятать (+4 к проверки на скрытность). Штраф на прицельные атаки этим оружием на 50% меньше. Нельзя удерживать двумя руками. Персонаж способен совершить этим оружием одну бесплатную атаку по возможности, всякий раз как противник входит или покидает его зону досягаемости. ", Date = DateTime.Now},
                    new WeaponProperty{Name="Двуручное", Description="Подготовка к бою двуручного оружия занимает основное действие. Когда удерживается двумя руками, то повышает свой урона на 3 единицы. Если использовать оружие в одной руке, то персонаж получает штраф на все тесты, связанные с использованием этого оружия, в размере -2. ", Date= DateTime.Now} ,

                };
                foreach(var pr in prop)
                {
                    context.WeaponProperties.Add(pr);
                }

                var type = new WeaponType[]
                {
                    new WeaponType{Name="Короткий Меч", DiceId=2, Dice = context.Dices.Find(2),AttackType = AttackType.Slicing, AvailabilityLevel = AvailabilityLevel.Common, BasePrice = 50, AttackDistance= AttackDistance.Melee, AttackDist = 0, BaseCraftDifficulty = 18, Date=DateTime.Now }
                };
                foreach(var w in type)
                {
                    context.WeaponTypes.Add(w);
                }

                var ch = new Character[]
                {
                    new Character{Name = "Amlrih", Race="Human", PlayersName = "Asmadisel", Strenght=5, Dexterity=5,Perseption=5,Charisma=8,Intellegence=6,Vitality=5,Will=3, Lvl=1, Experience=80, Weapons=new List<Weapon>(){context.Weapon.Find(1)  }, Profession1 = "Scholar", Date = DateTime.Now }
                };
                foreach(var c in ch)
                {
                    context.Characters.Add(c);
                }
              
                context.SaveChanges();
            }
        }
    }

