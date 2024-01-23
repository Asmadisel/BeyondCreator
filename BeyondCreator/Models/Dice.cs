namespace BeyondCreator.Models
{
    public class Dice
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        //Дайс привязывается к WeaponType один ко многим
        public ICollection<WeaponType> WeaponTypes { get; } = new List<WeaponType>();

        //Один дайс может быть привязан ко множеству разных видов оружий
        //public List<Weapon>? Weapons { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; } = DateTime.Now;
    }
}
