public class Chest
{
    private Inventory _items;
    private int _totalitems;

    public void DisplayChestItems()
    {
        _items.Display();
    }

    public void GenerateChest()
    {
        int itemCount = 0;
        while (itemCount != _totalitems)
        {
            itemCount++;
            _items.AddItem(_items.GetRandomItem());
        }
    }

    public Item TakeChestItem(int index)
    {
        Item item = _items.GetItem(index);
        _items.RemoveItem(index);
        return item;
    }

    public bool CheckChestEmpty()
    {
        return _items.CheckInventoryEmpty();
    }

    public Chest()
    {
        _items = new Inventory(1);
        _totalitems = 1;
    }

    public Chest(int numOfItems)
    {
        _items = new Inventory(numOfItems);
        _totalitems = numOfItems;
    }
}