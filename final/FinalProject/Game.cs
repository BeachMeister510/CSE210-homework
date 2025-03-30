using System.ComponentModel;

public class Game
{
    private string _name;
    private bool _started;
    private Player _player;
    private Random rand = new Random();

    private List<Event> _events = new List<Event>{
        new Encounter("Goblin Encounter", "You encounter a group of goblins wanting your things", 4)
    };


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
        int randindex = rand.Next(_events.Count());
        return _events[randindex];
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
}