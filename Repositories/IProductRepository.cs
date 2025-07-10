using InventorySystem.models;

namespace InventorySystem.Repositories;

public interface IProductRepository
{
    List<Product> GetAllProducts();
    Product GetProductById(int id);
    void AddProduct(Product product);
    //合約內容如下:
    //打掃廚房
    void CleanKitchen();
    //打掃浴室
    void CleanBathrooms();
    //拖地
    void Cleanfloor();
    //洗衣服
    void Washcloths();
    //共計三小時
    int GetNextProductId()
    {
        return 1;
    }
    void UpdateProduct(Product product);
}