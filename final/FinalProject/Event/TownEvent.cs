using System.CodeDom.Compiler;

public class TownEvent : Event
{
    private string _townName;
    private Inventory _townInventory;

    public override bool CheckEventFinished()
    {
        throw new NotImplementedException();
    }

    public void GenerateStore()
    {
        Random rand = new Random();
        int itemCounter = 0;
        while (itemCounter != _townInventory.GetMaxInventory())
        {
            itemCounter++;
            _townInventory.AddItem(_townInventory.GetRandomItem());
        }
    }

    public void DisplayStore()
    {
        _townInventory.StoreDisplay();
    }

    public bool CheckStoreEmpty()
    {
        return _townInventory.CheckInventoryEmpty();
    }

    public Item Buyitem(int index)
    {
        Item item = GetItem(index);
        _townInventory.RemoveItem(index);
        return item;
    }

    public Item GetItem(int index)
    {
        return _townInventory.GetItem(index);
    }

    public TownEvent()
    {
        _eventName = "Unknown Town Event";
        _eventDescription = "This town has to be desserted";
        _townName = "Unknown Town";
        _townInventory = new Inventory(3);
    }
    public TownEvent(string eventName, string desc, string townName) : base(eventName, desc)
    {
        _townName = townName;
        _townInventory = new Inventory(5);
    }
}