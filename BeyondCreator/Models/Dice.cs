namespace BeyondCreator.Models
{
    public class Dice
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //Дайс привязывается к WeaponType один ко многим
        public ICollection<WeaponProperty> WeaponProperties { get; } = new List<WeaponProperty>();

        //Один дайс может быть привязан ко множеству разных видов оружий
        //public List<Weapon>? Weapons { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
