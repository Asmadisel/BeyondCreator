global using System.ComponentModel.DataAnnotations;

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

        //Оружие. Ограничено 3 элементами из РСУБД
        [Display(Name = "Оружие")]
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

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
        public int HeadArmour { get; set; }
        [Display(Name = "Доспех торса")]
        public int BodyArmour { get; set; }
        [Display(Name = "Доспех рук")]
        public int ArmsArmour { get; set; }
        [Display(Name = "Доспех ног")]
        public int LegsArmour { get; set; }
        [Display(Name = "Дополнительный доспех от плаща")]
        public int BonusArmour { get; set; }
        [Display(Name = "Сопротивление")]
        public int Resistance { get; set; }

        //Дата создания персонажа
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //Добавляем возможность добавления арта персонажа
        

    }
}
        
    
