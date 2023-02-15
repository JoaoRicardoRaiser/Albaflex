namespace Albaflex.Data.Entities
{
    public abstract class Product: BaseEntity
    {
        public int Code { get; set; }
        public string? Name { get; set; }
        public double Value { get; set; }

    }
}
