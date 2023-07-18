using Albaflex.CrossCutting.Enums;
using Albaflex.CrossCutting.Models;

namespace Albaflex.Data.Entities
{
    public class Product: BaseEntity
    {
        public int Code { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public ProductType Type { get; set; }

        public Product(int code, string description, double price, ProductType type)
        {
            Code = code;
            Description = description;
            Price = price;
            Type = type;
        }

        public static Product FromCreateProductInputModel(CreateProductInputModel inputModel)
        {
            if (!Enum.TryParse<ProductType>(inputModel.Type, out var productTypeConverted))
                throw new ArgumentException($"The parameter {nameof(inputModel.Type)}: {inputModel.Type} is invalid.");
            return new Product(inputModel.Code, inputModel.Description ?? "SEM DESCRICAO", inputModel.Price, productTypeConverted);
        }
    }
}
