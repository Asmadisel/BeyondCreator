using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeyondCreator.Models
{
    public class WeaponType
    {
        [Key]
        public int Id;
        //Parent    - таблица от Оружия. В себе хранит кубик урона (связь с таблицей Dices), название Типа, Тип Урона (enum ), Свойство оружия (WeaponProperty), уровень доступности (enum), базовая цена, сложность крафта
        public int WeaponId { get; set; }
        //Ссылка на оружие. Производных типов может быть сколько угодно.
        [Display(Name = "Оружия")]
        public ICollection<Weapon> Weapons { get; } = new List<Weapon>();
        //Связь 1 ко многим с типом оружия. Является зависимой от модели Dice
        public int DiceId {  get; set; }
        //[DefaultValue(Dice.Id(0)]
        [Display(Name = "Куб урона")]
        [Column("Attack_dice")]
        public Dice Dice { get; set; } = null!;

        //Название Типа
        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }
        //Тип Урона
        [Column("Attack_type")]
        [Display(Name = "Тип урона")]
        [Required]
        public AttackType AttackType { get; set; }

        //Свойства оружия - связь многие ко многим, является зависимым от WeaponProperty. Хранит в себе бесконечное количество свойств. 
        [Display(Name = "Свойства оружия")]
        public ICollection<WeaponProperty> WeaponProperties { get; set; } = new List<WeaponProperty>();
        //Уровень доступности
        [Display(Name = "Доступность")]
        [Required]
        public AvailabilityLevel AvailabilityLevel { get; set; }

        //Базовая цена - инициализируется в конструкторе. Это значение умножается в конструкторе Weapon в зависимости от уровня качества предмета на x2,x4,x8,x16,x32
        [Required]
        [Display(Name = "Базовая Цена")]
        public int BasePrice {  get; set; }
        //Базовая сложность обычно равна 18.
        [Required]
        [Display(Name = "Базовая сложность создания")]
        public int BaseCraftDifficulty { get; set; } = 18;

        //Дистанция досягаемости оружия из enum для проверки
        [Display(Name = "Тип дистанции")]
        public AttackDistance AttackDistance { get; set; }

        //Устанавливается дистанция атаки/ Возможно неверно написан get
        [Display(Name = "Дистанция атаки")]
        public int AttackDist { set { if (AttackDistance == AttackDistance.Melee) { AttackDist=0; } else { AttackDist=value; } } get => AttackDist; }


       //Инициализируем конструктор
        public WeaponType(Weapon _weapon, Dice _dice, string _name, AttackType atkType, WeaponProperty weapProperty, AvailabilityLevel _availabilityLevel, int _basePrice) { 
        WeaponId= _weapon.Id; Weapons.Add(_weapon);DiceId=_dice.Id; Dice = _dice; Name= _name; AttackType= atkType; WeaponProperties.Add(weapProperty);AvailabilityLevel= _availabilityLevel; BasePrice = _basePrice;
            BaseCraftDifficulty = 18;
        }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }

    public enum AttackType
    {
        Slicing,
        Percussion,
        Stabbing,
        Blasting,
        Elemental,
        Energical,
        Natural,
        //Чистый
        Purical,
        Divine
    }
    public enum AvailabilityLevel
    {
        General =0,
        Afford, 
        Common,
        Uncommon,
        Rare,
        Unique,
        Legendary

    }
    public enum AttackDistance
    {
        Melee =0,
        MeleeDist,
        Range
    }
}
