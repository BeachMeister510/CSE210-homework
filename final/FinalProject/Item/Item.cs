using System.ComponentModel.DataAnnotations;

public abstract class Item
{
    protected string _itemName;
    protected string _itemDesc;
    protected string _itemRarity;
    protected int _itemValue;

    public virtual void Display()
    {

        Console.WriteLine($"Name: {_itemName}   Rarity: {_itemRarity}");
        Console.WriteLine(_itemDesc);
    }

    public int GetItemValue()
    {
        return _itemValue;
    }

    public abstract string CheckItemName();

    public abstract string CheckItemRarity();

    public void DisplayStoreInfo()
    {

        Console.WriteLine($"Name: {_itemName}  Rarity: {_itemRarity}");
        Console.WriteLine(_itemDesc);
        Console.WriteLine($"Value: {_itemValue}");
    }

    public Item(string name, string desc, string rarity, int value)
    {
        _itemName = name;
        _itemDesc = desc;
        _itemRarity = rarity;
        _itemValue = value;
    }

    public Item()
    {
        _itemName = "Unkown Item";
        _itemDesc = "No description";
        _itemRarity = "common";
        _itemValue = 0;
    }

}