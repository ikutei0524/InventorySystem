namespace InventorySystem.models;

public abstract class Animal
{
    public String Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public abstract void MakeSound();

}