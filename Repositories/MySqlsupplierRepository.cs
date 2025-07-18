using InventorySystem.models;
using MySql.Data.MySqlClient;

namespace InventorySystem.Repositories;

public class MySqlSupplierRepository : ISupplierRepository
{
    private readonly string _connectionString;
    public MySqlSupplierRepository(string connectionString)
    {
        _connectionString = connectionString;
        CreateSupplierTable();
    }

    private void CreateSupplierTable()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string createTableSql = @"
                 create table if not exists Products(
                 id int primary key auto_increment,
                 name varchar(100) not null,
                 price decimal(10.2) not null,
                 quantity int not null,
                 status int not null -- 對應enum的整數值
                 );";
                using (MySqlCommand cmd = new MySqlCommand(createTableSql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("[Supplier]Mysql初始化失敗或成功已存在");
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"[Supplier]初始化Mysql失敗:{e.Message}");
            }
        }
    }


    private void InitializeDatabase()
    {
        
    }






    public void CreateSupplier(Supplier supplier)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            try
            {
                connection.Open();
                string createTableSql = @"
                 create table if not exists Products(
                 id int primary key auto_increment,
                 name varchar(100) not null,
                 price decimal(10.2) not null,
                 quantity int not null,
                 status int not null -- 對應enum的整數值
                 );";
                using (MySqlCommand cmd = new MySqlCommand(createTableSql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Mysql初始化失敗或成功已存在");
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"初始化Mysql失敗:{e.Message}");
            }
        }
    }

    public void AddSupplier(Supplier supplier)
    {
        throw new NotImplementedException();
    }

    public List<Supplier> GetAllSuppliers()
    {
        throw new NotImplementedException();
    }

    public Product GetProduct(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(Supplier product)
    {
        throw new NotImplementedException();
    }

    public void ExistSupplier(int id)
    {
        throw new NotImplementedException();
    }
}