namespace BeyondCreator.Models
{
    public class Dice
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //Один дайс может быть привязан ко множеству разных видов оружий
        public List<Weapon>? Weapons { get; set; }
    }
}
