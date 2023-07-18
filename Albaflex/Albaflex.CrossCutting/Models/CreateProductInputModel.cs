namespace Albaflex.CrossCutting.Models
{
    public class CreateProductInputModel
    {
        public int Code { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Type { get; set; }
    }
}
