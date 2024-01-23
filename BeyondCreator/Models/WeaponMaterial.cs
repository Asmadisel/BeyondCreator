namespace BeyondCreator.Models
{
    //У каждого оружия есть материал, который определяет у оружия его бонус урона и прочность. Поскольку, любое оружие имеет прочность и тврёдость 3/3, то бонус считается сразу в базе.
    public class WeaponMaterial
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string? Name { get; set; }
        [Display(Name = "Уровень материала")]
        [Range(0,5)]
        public int MaterialLvl { get; set; }

        //Связан с таблицей оружия
        public ICollection<Weapon> Weapons { get; } =new List<Weapon>();


        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
