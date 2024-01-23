namespace BeyondCreator.Models
{
    public class WeaponProperty
    {
        //Связано многое ко многим с таблицами WeaponType и Weapon. 
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Описание")]
        public string? Description { get; set; }
        //Может быть как надстройка на отдельном оружии как связь многих ко многим

        public ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
        //Может быть как надстройка на Типе оружия как связь многих ко многим
        [Display(Name = "Связанное оружие")]
        public ICollection<WeaponType> WeaponTypes { get; set; } = new List<WeaponType>();
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
