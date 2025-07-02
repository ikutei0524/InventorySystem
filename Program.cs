// See https://aka.ms/new-console-template for more information


using System.ComponentModel;
using InventorySystem.models;
using InventorySystem.Repositories;


Product testProduct = new Product(1, "testProduct",100.0m,20);
testProduct.Quantity = 15;
testProduct.UpdateStatus();
Console.WriteLine(testProduct.ToString());


List<Animal> animals = new List<Animal>();
animals.Add(new Cat("JOJO"));
animals.Add(new Dog("dog"));
//animals.Add(new Animal("bird"));
foreach (Animal animal in animals)
{
    animal.MakeSound();
}








void ConsoleReadLine()
{
    Console.Write("請輸入你的名字");
    string userName = Console.ReadLine();
    Console.WriteLine($"哈囉,{
        userName}!");
    Console.Write("請輸入您的年齡");
    string inputAge = Console.ReadLine();
    if (int.TryParse(inputAge, out int age))
    {
        Console.WriteLine($"你的年齡為,{age}!");
    }
    else
    {
        Console.WriteLine("年齡輸入錯誤");
    }
}

void ForLoop()
{
    List<int> numbers = new List<int>() { 1, 2, 3, 4,5,};
    foreach (int number in numbers)
    {
        if (number == 4)
        {
            continue;
        }
        else if (number != 4)
        {
            Console.WriteLine("1,2,3,5,");
        }
    }
}












const string MYSQL_CONNETION_STRING = "Server=localhost;Port=3306;Database=inventory_db;uid=root;pwd=John0524@;";

MySqlProductRepository productRepository = new MySqlProductRepository(MYSQL_CONNETION_STRING);


    

    
