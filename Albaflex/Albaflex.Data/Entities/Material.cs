using Albaflex.CrossCutting.Enums;

namespace Albaflex.Data.Entities
{
    public class Material : Product
    {
        public Material(int code, string description, double price, ProductType type) : base(code, description, price, type)
        {
        }
    }
}
