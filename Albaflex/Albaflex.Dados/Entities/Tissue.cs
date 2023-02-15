namespace Albaflex.Data.Entities
{
    public class Tissue: Product
    {
        public Tissue(int code, string name, double value)
        {
            Code = code;
            Name = name;
            Value = value;
        }
    }
}
