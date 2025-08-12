using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Product : BaseEntity
    {

        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public int Price { get; private set; }
        public int InStock { get; private set; }
        public string Sku { get; private set; } = default!;
        public string Slug { get; private set; } = default!;

        public Product(string name, string description, int price, int inStock, string sku, string slug)
        {
            Name = name;
            Description = description;
            Price = price;
            InStock = inStock;
            Sku = sku;
            Slug = slug;
        }

        public void UpdateProductData(string name, string description, int price, int inStock, string sku, string slug)
        {
            Name = name;
            Description = description;
            Price = price;
            InStock = inStock;
            Sku = sku;
            Slug = slug;
        }
    }
}
