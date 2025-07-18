namespace InventorySystem.models;

public class Supplier
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Address { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }


    public Supplier(string name,string address,string phone,string email)
    {
        Name = name;
        Address = address;
        Phone = phone;
        Email = email;
    }
    
    //空的建構子 for Darabase 使用
    public Supplier()
    {
        
    }

    public override string ToString()
    {
        return $"ID:{Id},Name:{Name},Address:{Address},Phone:{Phone},Email:{Email}";
    }




}
