namespace DemoApp.Models.InputModels
{
    public class OuterInputModel
    {
        public int Id { get; set; }

        public NamesInputModel Names { get; set; }

        public int[] Years { get; set; }
    }
}
