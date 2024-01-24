using BeyondCreator.Models;

namespace BeyondCreator.Data
{
    public class DBInitializer
    {


        public static void Initialize(BeyondCreatorContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            if (context.Dices.Any())
            {
                return;
            }
            //Создадим контекст базы данных
            var dices = new Dice[]
            {
                    new () { Name="D4"},
                    new (){Name = "D6"},
                    new (){ Name="D8"},
                    new() {Name="D10"},
                    new() {Name="D12"},
                    new() {Name="D20"}
            };

            context.Dices.AddRange(dices);

            context.SaveChanges();

        }

    }
}
