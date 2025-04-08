using System.ComponentModel;

public class Game
{
    private string _name;
    private bool _started;
    private Player _player;
    private Random rand = new Random();

    private List<Event> _events = new List<Event>{
        new Encounter("Goblin Encounter", "You encounter a group of goblins wanting your things", 4),
        new Encounter("Orc Encounter", "You encounter a group of orcs", 3),
        new TownEvent("Midvale Encounter", "You encounter the city of Midvale", "Midvale")
    };

    public void Display()
    {
        Console.WriteLine($"{_name} a world of fun encounters");
    }


    public void DisplayPlayer()
    {
        _player.DisplayPlayer();
    }

    public void DisplayInventory()
    {
        _player.DisplayInventory();
    }

    public void GameStart()
    {
        _started = true;
    }

    public Event GetEvent()
    {
        GameStart();
        int randindex = rand.Next(_events.Count());
        return _events[2];
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public Game()
    {
        _name = "New Game";
        _started = false;
        _player = new Player();
    }

    public Game(bool started, Player player, int points)
    {
        _name = "Goal Adventures";
        _started = started;
        _player = player;
    }
}