using System.ComponentModel;

namespace BeyondCreator.Models
{
    public class Weapon
    {
        //Типичное оружие в игре — сущность со своим уроном, материалом, своей прочностью, твёрдостью и типом, обладающим системой свойств. 
        //Хранит ссылку на WeaponType связи один ко многим (зависимое) и модифицируется уровнем, дополнительными свойствами
        //Ключ по id
        [Key]
        public int Id { get; set; }
        //Задается пользователем, по умолчанию - weapon
        [Display(Name = "Название")]
        public string Name { get; set; } = "Weapon";
        //Связь 1 к 1 с WeaponType. Type: Мечи, Топоры, Молоты/Булавы, Серпы/Косы, Копья, Кинжалы/Ножи, Плети, Луки, Арбалеты, Огнестрельное, Метательное, Безоружный Бой, Импровизируемое, Архаичное. 
        //От типа оружия передается: Тип урона, Свойства
        //Связь от одного типа может наследоваться множество оружий
        public int WeaponTypeID { get; set; }
        public WeaponType WeaponType { get; set; }

        //Связь отдельно с WeaponProperty как дополнительные свойства
        [Display(Name = "Дополнительные свойства")]
        public ICollection<WeaponProperty> WeaponProperties { get; set; } = new List<WeaponProperty>();


        //Связь с материалом оружия, связь типа один ко многим, является зависимым. От него зависят свойства  прочности и  enum AvailabilityLevel в WeaponType
        public int WeaponMaterialId {  get; set; }
        public WeaponMaterial WeaponMaterial { get; set; } = null!;
        [Display(Name = "Уровень предмета")]
        //Полностью зависит от материала предмета и свойство меняется у материала (=value)
        public int WeaponLvl { get => WeaponMaterial.MaterialLvl; set => WeaponMaterial.MaterialLvl= value; }

        //Твердость и прочность, по умолчанию 3/ 

        //Нужно будет доработать логику автоматического set от materiallvl
        public int Hardness { get; set; } = 3;
        public int Durability { get ; set; } = 3;

        //Отношение к персонажу (Depended to Character) Один ко многим, где является зависимым
        public int CharacterID {  get; set; } //Необходимый внешний ключ
        [Display(Name = "Владелец")]
        [DefaultValue("Ничей")]
        [Required]
        public Character Character { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Weapon(string _name, WeaponType _weaponType, WeaponMaterial _material, Character _character)
        {
            Name = _name; WeaponTypeID = _weaponType.Id; WeaponType = _weaponType;WeaponProperties= new List<WeaponProperty>();WeaponMaterialId = _material.Id; WeaponMaterial = _material;
            WeaponLvl = _material.MaterialLvl; Hardness =3; Durability = 3; CharacterID = _character.Id;Character = _character; Date = DateTime.Now;
        }
    }
}
