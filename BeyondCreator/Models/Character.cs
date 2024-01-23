global using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;

namespace BeyondCreator.Models
{
    public class Character
    {
        public int Id { get; set; }
        [Display(Name = "Имя персонажа")]
        public string? Name { get; set; } = null;
        [Display(Name = "Раса персонажа")]
        public string Race { get; set; } = string.Empty;
        [Display(Name = "Имя игрока")]
        public string? PlayersName { get; set; } = null;
        [Display(Name = "Сила")]
        public int Strenght { get; set; } = 5;
        [Display(Name = "Ловкость")]
        public int Dexterity { get; set; } = 5;
        [Display(Name = "Внимательность")]
        public int Perseption { get; set; } = 5;
        [Display(Name = "Харизма")]
        public int Charisma { get; set; } = 5;
        [Display(Name = "Интеллект")]
        public int Intellegence { get; set; } = 5;
        [Display(Name = "Выносливость")]
        public int Vitality { get; set; } = 5;
        [Display(Name = "Воля")]
        public int Will { get; set; } = 5;
        [Display(Name = "Уровень")]
        public int Lvl { get; set; } = 0;
        [Display(Name = "Опыт")]
        public int Experience { get; set; } = 0;

        //Оружие. Ограничено 3 элементами из РСУБД. Является отношением 1:M (1 герой может иметь множество оружия), коллекция может быть пустой. У оружия есть поле "Хозяин" и "Создатель"

        [Display(Name = "Оружие")]
        public ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
        //Старая модель с 3 отдельными уникальными значениями оружия
        //[Display(Name = "Оружие")]
        //public string? Weapon1 { get; set; } = null;
        //[display(name = "оружие 2")]
        //public string? weapon2 { get; set; } = null;
        //[display(name = "оружие 3")]
        //public string? weapon3 { get; set; } = null;
        
        //Базовая атака героя, равна по базе 1, если нет оружия, иначе - кубик+уровень материала
        public string BaseAttack { get {
                //Если нет значений
                if(!Weapons.Any() )
                {
                    return "1+Strenght";
                }
                else
                {
                    var weap = Weapons.FirstOrDefault();
                    return $"{weap.WeaponType.Dice.ToString}+{weap.WeaponLvl}+Strenght";
                }
            } }



        //Преимущества и недостатки. На данный момент ограничены 3 элементами каждый
        [Display(Name = "Преимущество №1")]
        public string? Advantage1 { get; set; }
        [Display(Name = "Преимущество №2")]
        public string? Advantage2 { get; set; }
        [Display(Name = "Преимущество №3")]
        public string? Advantage3 { get; set; }
        [Display(Name = "Недостаток №1")]
        public string? Disadvantage1 { get; set; }
        [Display(Name = "Недостаток №2")]
        public string? Disadvantage2 { get; set; }
        [Display(Name = "Недостаток №3")]
        public string? Disadvantage3 { get; set; }

        //Блок профессий
        [Display(Name = "Старотовая профессия")]
        public string Profession1 { get; set; } = "Adventurer";
        [Display(Name = "Вторичная профессия №1")]
        public string? Profession2 { get; set; }
        [Display(Name = "Вторичная профессия №2")]
        public string? Profession3 { get; set; }

        //Блок защиты
        [Display(Name = "Доспех головы")]
        public int HeadArmour { get; set; } = 0;
        [Display(Name = "Доспех торса")]
        public int BodyArmour { get; set; } = 0;
        [Display(Name = "Доспех рук")]
        public int ArmsArmour { get; set; } = 0;
        [Display(Name = "Доспех ног")]
        public int LegsArmour { get; set; } = 0;
        [Display(Name = "Дополнительный доспех от плаща")]
        public int BonusArmour { get; set; } = 0;
        [Display(Name = "Сопротивление")]
        public int Resistance { get; set; } = 0;

        //Дата создания персонажа
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //Добавляем возможность добавления арта персонажа
        public int? ImageId { get; set; }
        public Image? Image { get; set; }

    }
}
        
    
