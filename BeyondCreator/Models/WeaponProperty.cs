namespace BeyondCreator.Models
{
    public class WeaponProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Weapon> Weapons { get; set; } = new();
    }
}
