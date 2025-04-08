using System.Dynamic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

public class Inventory
{
    private List<Item> _items;
    private int _inventoryMax;
    private List<Item> _gameItems = new List<Item>{
        new Weapon("Your Fist", "your own clenched hand", "N/A", 0, "bludgeoning", 2, 2, false),
        new Weapon("Short sword", "your average short sword", "common", 5, "slashing", 5, 2, false),
        new Weapon("Longsword", "A general use longsword that has seen its use in battle", "uncommon", 10, "slashing", 15, 2, false),
        new Weapon("Great Axe", "A fairly heavy weapon with a good amoutn of damage", "rare", 25, "slashing", 20, 2, false),
        new Armor(),
        new Armor("Leather Armor", "Light armor offering moderate protection", "common", 10, 5, false),
        new Armor("Studded Leather Armor", "offers more protection than standard Leather but only slightly", "common", 15, 8, false),
        new Armor("Chainmail", "Offers good protection against most attacks", "rare", 25, 15, false),
        new Armor("Scalemail", "Like chainmail it gives you good protection but offers slightly better resistance to damage", "rare", 30, 20, false),
        new Armor("Platemail", "Offers great protection and looks coo too!", "epic", 50, 30, false),
        new Consumable("Health Potion", "Restores up to 20 health", "uncommon", 15, 20)
    };

    public void AddItem(Item item)
    {
        if (_items.Count() < _inventoryMax)
        {
            _items.Add(item);
        }
        else
        {
            Console.WriteLine("Inventory Full!");
        }
    }

    public bool CheckInventoryFull()
    {
        if (_items.Count() >= _inventoryMax)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckInventoryEmpty()
    {
        if (_items.Count() == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Item GetRandomItemRarity(string rarity)
    {
        Random rand = new Random();
        List<Item> tempItemList = new List<Item>();
        int index = rand.Next(tempItemList.Count());

        foreach (Item item in _gameItems)
        {
            if (item.CheckItemRarity() == rarity)
            {
                tempItemList.Add(item);
            }
        }

        return tempItemList[index];
    }

    public Item GetRandomItem()
    {
        Random rand = new Random();

        bool getting = true;
        Item newItem = _gameItems[0];

        while (getting)
        {
            int index = rand.Next(_gameItems.Count());

            if (_gameItems[index].CheckItemRarity() != "epic" && _gameItems[index].CheckItemRarity() != "N/A")
            {
                newItem = _gameItems[index];
                getting = false;
            }

        }
        return newItem;
    }

    public Item GetItem(int index)
    {
        index = index - 1;
        return _items[index];
    }

    public void Display()
    {
        int count = 0;
        foreach (Item item in _items)
        {
            count++;
            Console.WriteLine($"{count}.");
            item.Display();
            Console.WriteLine();
        }
    }

    public void StoreDisplay()
    {
        int count = 0;
        foreach (Item item in _items)
        {
            count++;
            Console.WriteLine($"{count}.");
            item.DisplayStoreInfo();
            Console.WriteLine();
        }
    }

    public void RemoveItem(int index)
    {
        _items.RemoveAt(index - 1);
    }

    public int GetMaxInventory()
    {
        return _inventoryMax;
    }

    public Inventory()
    {
        _items = new List<Item>();
        _inventoryMax = 10;
    }

    public Inventory(int max)
    {
        _items = new List<Item>();
        _inventoryMax = max;
    }
}