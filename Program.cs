﻿// See https://aka.ms/new-console-template for more information


using System.ComponentModel;
using InventorySystem.models;
using InventorySystem.Repositories;
using InventorySystem.Service;
using InventorySystem.Utils;


const string MYSQL_CONNETION_STRING = "Server=localhost;Port=3306;Database=inventory_db;uid=root;pwd=John0524@;";

//MySqlProductRepository mySqlProductRepository = new MySqlProductRepository(MYSQL_CONNETION_STRING);
MySqlProductRepository productRepo = new MySqlProductRepository(MYSQL_CONNETION_STRING);
InventoryService inventoryService = new InventoryService(productRepo);

//通知功能相關
//使用EmailNotifier
INotifier emailNotifier = new EmailNotifier();
NotificationService emailService = new NotificationService(emailNotifier);
//使用SmsNotifier
INotifier smsNotifier = new SmsNotifier();
NotificationService smsService = new NotificationService(smsNotifier);

//InventoryService inventoryService1 = new InventoryService(productRepository);
//小明注入 打掃阿姨1
//InventoryService inventoryService = new InventoryService(mongoDbProductRepository);
//小明注入 打掃阿姨2





RunMenu();

void RunMenu()
{
    while (true)
    {
        DisplayMenu();
        string input = Console.ReadLine();
        switch (input) 
        {
            case "1":
            {
                GetAllProducts();
            }
                break;
            case "2": SearchProduct();
                break;
            case "3": AddProduct();
                break;
            case "4": UpdateProduct();
                break;
            case "0": 
                Console.WriteLine("再見");
                return;
        }
    }
}

void DisplayMenu()
{
    Console.WriteLine("Welcome to the inventory system!");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1. 查看所有產品");
    Console.WriteLine("2. 查詢產品");
    Console.WriteLine("3. 新增產品");
    Console.WriteLine("4. 更新產品");
    Console.WriteLine("0. 離開");
}

void GetAllProducts()
{
    Console.WriteLine("\n--- 所有產品列表 ---");
    var products = inventoryService.GetAllProducts();
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("ID | Name | Price | Quantity | Status");
        Console.WriteLine("-----------------------------------------------");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine("-----------------------------------------------");
        emailService.NotifyUser("user","查詢已完成");
    }


void SearchProduct()
{
    Console.WriteLine("輸入欲查詢的產品編號");
    int input = ReadIntLine(1);
    var product = inventoryService.GetProductById(input);
    if (product != null)
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("ID | Name | Price | Quantity | Status");
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine(product);
        Console.WriteLine("-----------------------------------------------");
    }
}

void AddProduct()
{
    Console.WriteLine("輸入產品名稱：");
    string name = Console.ReadLine();
    Console.WriteLine("輸入產品價格：");
    decimal price = ReadDecimalLine();
    Console.WriteLine("輸入產品數量：");
    int quantity = ReadIntLine();
    inventoryService.AddProduct(name, price, quantity);
    smsService.NotifyUser("Jeffrey","新增產品成功");
}

void UpdateProduct()
{
    Console.WriteLine("請輸入要更新的產品id");
    int id = ReadIntLine();
    //找到對應產品
    var product = inventoryService.GetProductById(id);
    
    if (product == null)
    {
        return;
    }
    Console.WriteLine("輸入產品名稱：");
    string name = Console.ReadLine();
    Console.WriteLine("輸入產品價格：");
    decimal price = ReadDecimalLine();
    Console.WriteLine("輸入產品數量：");
    int quantity = ReadIntLine();
    //service.UpdateProduct
    inventoryService.UpdateProduct(product, name, price,quantity);
}

int ReadInt(string input)
{
    try
    {
        return Convert.ToInt32(input);
    }
    catch (FormatException e)
    {
        Console.WriteLine("請輸入有效數字。");
        return 0;
    }
}

int ReadIntLine(int defaultValue = 0)
{
    while (true)
    {
        
        String input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) && defaultValue != 0)
        {
            return defaultValue;
        }
        //string parsing to int 
        if (int.TryParse(input,out int value))
        {
            return value;
        }
        else
        {
            Console.WriteLine("請輸入有效數字。");
        }
    }
}

decimal ReadDecimalLine(decimal defaultValue = 0.0m)
{
    while (true)
    {
        
        String input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) && defaultValue != 0.0m)
        {
            return defaultValue;
        }
        //string parsing to int 
        if (decimal.TryParse(input,out decimal value))
        {
            return value;
        }
        else
        {
            Console.WriteLine("請輸入有效數字。");
        }
    }
}

void OOP()
{
    //實體化(new)
    Cat meow = new Cat("meow");
    Dog bob = new Dog("bob");
    //一隻狗bob 一隻貓meow

    Animal milk = new Cat("john");
    Animal john = new Dog("milk");
    //兩隻動物 john(dog) milk(cat)
}