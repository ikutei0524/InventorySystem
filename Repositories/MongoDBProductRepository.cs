using InventorySystem.models;

namespace InventorySystem.Repositories;

public class MongoDBProductRepository : IProductRepository
{
    public MongoDBProductRepository()
    {
    }

    public List<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(string? name, decimal price, int quantity)
    {
        throw new NotImplementedException();
    }

    public void CleanKitchen()
    {
        throw new NotImplementedException();
    }

    public void CleanBathrooms()
    {
        throw new NotImplementedException();
    }

    public void Cleanfloor() // ✅ 注意這裡的命名必須完全符合介面定義
    {
        throw new NotImplementedException();
    }

    public void Washcloths()
    {
        throw new NotImplementedException();
    }
}
