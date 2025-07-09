using InventorySystem.Repositories;
namespace InventorySystem.Service;



public class ProductService
{
    const string MYSQL_CONNETION_STRING = "Server=localhost;Port=3306;Database=inventory_db;uid=root;pwd=John0524@;";
    MySqlProductRepository productRepository = new MySqlProductRepository(MYSQL_CONNETION_STRING);
    
    public void GetAllProducts()
    {
        Console.WriteLine("\n--- 所有產品列表 ---");
        var products = productRepository.GetAllProducts();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("ID | Name | Price | Quantity | Status");
        Console.WriteLine("-----------------------------------------------");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine("-----------------------------------------------");
    }
}