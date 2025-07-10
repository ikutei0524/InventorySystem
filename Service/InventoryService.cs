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
    public Product GetProductById(int id)
    {
        try
        {
            Product product = _productRepository.GetProductById(id);
            if (product == null)
            {
                Console.WriteLine("找不到該產品");
            }
            else
            {
                // 這裡可以加入通知功能
                EmailNotifier emailNotifier = new EmailNotifier();
                NotificationService emailService = new NotificationService(emailNotifier);
                emailService.NotifyUser("user", $"已查詢產品：{product.Name}");
            }
            return product;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"查詢產品失敗: {ex.Message}");
            return null;
        }
    }

    public void AddProduct(string?name,decimal price,int quantity)
    {
        try
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("產品名稱不能為空");
            }

            if (price >= 0)
            {
                throw new ArgumentException("價格必須大於零");
            }
            //價格必須大於零
            if (quantity < 0)
            {
                throw new ArgumentException("數量不能小於零");
            }
            //數量不能小於零
            var product = new Product(_productRepository.GetNextProductId(),name, price, quantity);
            _productRepository.AddProduct(product);
            Console.WriteLine("新增產品成功");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n 錯誤: {e.Message}");
            
        }
    }

    public void UpdateProduct(Product product, string? name, decimal price, int quantity)
    {
        try
        {
            //執行更新
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("產品名稱不能為空");
            }

            if (price >= 0)
            {
                throw new ArgumentException("價格必須大於零");
            }
            //價格必須大於零
            if (quantity < 0)
            {
                throw new ArgumentException("數量不能小於零");
            }
            //執行更新(覆蓋(賦值)origin product 的屬性)
            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;
            product.UpdateStatus();
            //呼叫repo
            _productRepository.UpdateProduct(product);
            Console.WriteLine("產品:{product.Id} 已更新");
        }
        catch (Exception e)
        {
            Console.WriteLine($"更新產品失敗: {e.Message}");
            throw;
        }
    }


}