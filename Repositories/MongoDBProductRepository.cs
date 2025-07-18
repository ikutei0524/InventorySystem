using InventorySystem.models;

namespace InventorySystem.Repositories;

public class MongoDBProductRepository : IProductRepository
{
    public int GetNextProductId()
    {
        throw new NotImplementedException();
    }
    public MongoDBProductRepository()
    {
    }

    public List<Product> SearchOutOfStockProduct()
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(Product product)
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
    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}

