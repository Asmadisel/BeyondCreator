namespace BeyondCreator.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageTitle {  get; set; }
        public byte[] ImageData { get; set; }

        //Добавляется 1 к 1 к оружию, материалу, персонажу и т.п. 
        //Добавление к персонажу
        public Character? Character { get; set; }
    }
}
