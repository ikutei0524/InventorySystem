using InventorySystem.models;
using InventorySystem.Repositories;
using InventorySystem.Utils;

namespace InventorySystem.Service;

public class InventoryService
{
    private readonly IProductRepository _productRepository;

    //透過建構子,注入介面
    public InventoryService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    
    public List<Product> GetAllProducts()
    {
        try
        {
            
            //呼叫介面,而非實作(DI)
            List<Product> products = _productRepository.GetAllProducts();
            if (!products.Any())
            {
                Console.WriteLine("找不到產品");
            }
            //通知功能相關
            //使用EmailNotifier
            EmailNotifier emailNotifier = new EmailNotifier();
            NotificationService emailService = new NotificationService(emailNotifier);
            emailService.NotifyUser("user","查詢已完成");
            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine($"讀取產品列表失敗: {e.Message}");
            return new List<Product>();
        }
    }
}