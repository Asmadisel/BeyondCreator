namespace BeyondCreator.Models
{
    public class Armor
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public int Description { get; set; }
        [Display(Name = "Тип предмета")]
        public string ArmorType { get; set; }
       [Display(Name = "Броня")]
        [Required]
        [Range(0,30)]
       public int ArmorBonus { get; set; }
            [Display(Name = "Уровень материала")]
        [Range(0,5)]
        public int ArmorMaterialLvl { get; set; }
           
    }
}
