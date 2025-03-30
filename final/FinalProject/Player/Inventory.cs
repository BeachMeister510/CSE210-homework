public class Inventory
{
    List<Item> _items;
    private int _inventoryMax;

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

    public void Display()
    {
        foreach (Item item in _items)
        {
            item.Display();
        }
    }

    public Inventory()
    {
        _items = new List<Item>();
        _inventoryMax = 10;
    }
}