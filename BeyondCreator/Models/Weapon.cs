namespace BeyondCreator.Models
{
    public class Weapon
    {
        //Типичное оружие в игре — сущность со своим уроном, материалом, своей прочностью, твёрдостью 
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; } = "Weapon";
        //На данный момент тип оружия вписывается. Нужна будет таблица с выбором типов. 
        [Display(Name = "Тип")]
        public string Type { get; set; } = "Sword";
        //Один-ко-многим к выбору куба урона из таблицы "кубы"

        [Display(Name = "Куб урона")]
        public int DiceId { get; set; }
        
        public Dice? Dice { get; set; }

        //Количество кубиков урона. Позже необходимо сделать привязку к размеру существа
        [Display(Name = "Количество кубов")]
        [Range(1, 5)]
        public int DiceCount { get; set; } = 1;

        //Материал — связь один к одному. 
        [Display(Name = "Материал оружия")]
        public int WeaponMaterialId { get; set; }
        
        public WeaponMaterial? WeaponMaterial { get; set; }
        //По идее, в приложении выводить параметры прочности и твёрдости можно через представления, как Material.Durability и Material.Firmness
        //Указать во время создания объекта значение бонуса нельзя — оно всегда равно уровню материала
        [Display(Name = "Бонус урона")]
        public int damageBonus { get; set; }

        //Прочность материала увеличивается как факториал 
        [Display(Name = "Прочность")]
        public int Durability { get; set; }

        [Display(Name = "Твердость")]
        public int Firmness { get; set; }
        //Список со свойствами оружия связь типа многие ко многим
        public List<WeaponProperty>? WeaponProperties { get; set; } = new();  

        //Отношение к персонажу
        public List<Character> Characters { get; set; } = new();
    }
}
