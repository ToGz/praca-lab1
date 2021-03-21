namespace lab2.Models.Shared
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public ushort Weight { get; set; }
        public ushort Age { get; set; }
    }
}
