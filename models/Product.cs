namespace InventorySystem.models;




public class Product
{
    public enum ProductStatus
    {
        InStock,//有庫存
        LouwStock,//庫存偏低
        OutOfStock//沒有庫存
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public ProductStatus Status { get; set; }

    public Product(int id , string name, decimal price, int quantity)
    {
      Id = id;
      Name = name;
      Price = price;
      Quantity = quantity;
      UpdateStatus();
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity},Status:{Status}";
    }

    public void UpdateStatus()
    {
        if (Quantity <= 0)
        {
            Status = ProductStatus.OutOfStock;
        }
        else if (Quantity < 10)
        {
            Status = ProductStatus.LouwStock;
        }
        else
        {
            Status = ProductStatus.InStock;
        }
    }
}








