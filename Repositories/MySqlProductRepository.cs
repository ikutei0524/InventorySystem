using InventorySystem.models;
using MySql.Data.MySqlClient;

namespace InventorySystem.Repositories;

public class MySqlProductRepository: IProductRepository
{
    private readonly string _connectionString;
    public MySqlProductRepository(string connectionString)
    {
        _connectionString = connectionString;
        InitializeDatabase();
    }

    private void InitializeDatabase()
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
                Console.WriteLine("[Product]Mysql初始化失敗或成功已存在");
            }
            catch (MySqlException e)
            {
                Console.WriteLine($"[Supplier]初始化Mysql失敗:{e.Message}");
            }
        }
    }

    public List<Product> GetAllProducts()
    {
        var products = new List<Product>();
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string selectSql = "SELECT * FROM Products";
            //1.box 
            //2.dish
            //3.phone
            using (MySqlCommand cmd = new MySqlCommand(selectSql, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //origin way
                        //Product product = new Product(reader.GetInt32(column: "id"),
                                //reader.GetString(column: "name"),
                                //reader.GetDecimal(column: "price"),
                                //reader.GetInt32(column: "quantity"));
                        
                            //product.Status = (Product .ProductStatus)reader.GetInt32(column:"status");
                        //products.Add(product);
                        
                        //obj initializer
                        products.Add(new Product(reader.GetInt32("id"),
                        name:reader.GetString("name"),
                        price:reader.GetDecimal("price"),
                        quantity:reader.GetInt32(column:"quantity"))
                        {
                           Status = (Product .ProductStatus)reader.GetInt32(column:"status")
                        });
                    }
                    }
                }
            }

        return products;
    }

    public Product GetProductById(int id)
    {
        Product product = null;

        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string selectSql = "SELECT * FROM Products WHERE id = @id";
            using (MySqlCommand cmd = new MySqlCommand(selectSql, connection))
            {
                //防止sql injection...
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product(reader.GetInt32("id"),
                        name:reader.GetString("name"),
                        price:reader.GetDecimal("price"),
                        quantity:reader.GetInt32(column:"quantity"))
                        {
                        Status = (Product .ProductStatus)reader.GetInt32(column:"status")    
                        };
                    }
                    }
                }
            }
        return product;
    }
    
    public void UpdateProduct(Product product)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string insertSql = "UPDATE products SET name = @name, price=@price,quantity=@quantity,status=@status where id = @id";
            using (MySqlCommand cmd = new MySqlCommand(insertSql, connection))
            {
                //防止sql injection...
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@name",product.Name);
                cmd.Parameters.AddWithValue("@price",product.Price);
                cmd.Parameters.AddWithValue("@quantity",product.Quantity);
                cmd.Parameters.AddWithValue("@status",product.Status);
                cmd.ExecuteNonQuery();
            }
        }
    }
    
    public void AddProduct(Product product)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string insertSql = "INSERT INTO  products(name, price, quantity,status) VALUES (@name, @price, @quantity,@status) ";
            using (MySqlCommand cmd = new MySqlCommand(insertSql, connection))
            {
                //防止sql injection...
                cmd.Parameters.AddWithValue("@name",product.Name);
                cmd.Parameters.AddWithValue("@price",product.Price);
                cmd.Parameters.AddWithValue("@quantity",product.Quantity);
                cmd.Parameters.AddWithValue("@status",product.Status);
                cmd.ExecuteNonQuery();
                    }
                }
        
            }
    public int GetNextProductId()
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string selectSql = @"SELECT iFNull(MAX(id),0) FROM products";
            using (MySqlCommand cmd = new MySqlCommand(selectSql, connection))
            {
                var result = cmd.ExecuteScalar();
                if (result != null)
                {return Convert.ToInt32(result)+1;
                }
                return 0;
            }
        }
    }
    
    public List<Product> GetLowProducts()
    {
        List<Product> products = new List<Product>();
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string selectSql = "SELECT * FROM products WHERE status = 1";
            using (MySqlCommand cmd = new MySqlCommand(selectSql, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product(reader.GetInt32("id"),
                            reader.GetString("name"),
                            reader.GetDecimal("price"),
                            reader.GetInt32("quantity"))
                        {
                            Status = (Product.ProductStatus)reader.GetInt32("status")
                        });
                    }
                }
            }
        }
        return products;
    }
    

    public List<Product> SearchOutOfStockProduct()
    {
        List<Product> products = new List<Product>();
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string selectSql = "SELECT * FROM products WHERE status = 2";
            using (MySqlCommand cmd = new MySqlCommand(selectSql, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product(reader.GetInt32("id"),
                            reader.GetString("name"),
                            reader.GetDecimal("price"),
                            reader.GetInt32("quantity"))
                        {
                            Status = (Product.ProductStatus)reader.GetInt32("status")
                        });
                    }
                }
            }
        }
        return products;
    }
    


    public void CleanKitchen()
    {
        throw  new NotImplementedException();
    }

    public void CleanBathrooms()
    {
        throw new NotImplementedException();
    }

    public void Cleanfloor()
    {
        
        throw new NotImplementedException();
    }

    public void Washcloths()
    {
        throw new NotImplementedException();
    }

    
}

