using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        // Marten UPSERT will cater for existing records
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
            {
                new Product()
{
    Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
    Name = "iPhone 14 Pro",
    Description = "The latest iPhone with advanced camera systems, A16 Bionic chip, and always-on display.",
    ImageFile = "product-1.png",
    Price = 999.00M,
    Category = new List<string> { "Smart Phone" }
},
new Product()
{
    Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
    Name = "Samsung Galaxy S23",
    Description = "Samsung's flagship with a powerful Snapdragon 8 Gen 2 processor and Dynamic AMOLED display.",
    ImageFile = "product-2.png",
    Price = 899.00M,
    Category = new List<string> { "Smart Phone" }
},
new Product()
{
    Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
    Name = "Huawei P60 Pro",
    Description = "Huawei's premium smartphone featuring a quad-camera setup and a large OLED display.",
    ImageFile = "product-3.png",
    Price = 799.00M,
    Category = new List<string> { "Smart Phone" }
},
new Product()
{
    Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
    Name = "Xiaomi 13 Pro",
    Description = "Xiaomi's top-tier phone with a Leica camera system and Snapdragon 8 Gen 2 chipset.",
    ImageFile = "product-4.png",
    Price = 799.00M,
    Category = new List<string> { "Smart Phone" }
},
new Product()
{
    Id = new Guid("b786103d-c621-4f5a-b498-23452610f88c"),
    Name = "Google Pixel 7 Pro",
    Description = "Google's latest with a Tensor G2 chip and the best-in-class Android experience.",
    ImageFile = "product-5.png",
    Price = 899.00M,
    Category = new List<string> { "Smart Phone" }
},
new Product()
{
    Id = new Guid("c4bbc4a2-4555-45d8-97cc-2a99b2167bff"),
    Name = "Sony Xperia 1 V",
    Description = "Sony's flagship with a 4K OLED display, Snapdragon 8 Gen 2, and professional-grade cameras.",
    ImageFile = "product-6.png",
    Price = 1199.00M,
    Category = new List<string> { "Smart Phone" }
},
new Product()
{
    Id = new Guid("93170c85-7795-489c-8e8f-7dcf3b4f4188"),
    Name = "OnePlus 11",
    Description = "OnePlus's latest with a Hasselblad camera system and ultra-fast charging capabilities.",
    ImageFile = "product-7.png",
    Price = 699.00M,
    Category = new List<string> { "Smart Phone" }
}
            };

}