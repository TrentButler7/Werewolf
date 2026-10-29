using WerewolfNS;
using WerewolfNS.Characters;

List<Player> _players = [];
List<CharacterAction?> _actions = [];
int nightNumber = 1;
CreateDefaultPlayers();

//AssignTokens();

while (true)
{
    var aliveAtStartOfNight = _players.Where(x => x.IsAlive);

    //Run Loop One
    foreach (var player in aliveAtStartOfNight)
    {
        if (player.HasActionThisNight(nightNumber))
        {
            _actions.Add(player.Character.NightActionLoopOne(_players, player));
        }
        else
        {
            Console.WriteLine("Blank Action");
        }
    }

    //Process
    foreach (var action in _actions.OfType<CharacterAction>().OrderBy(x => x.Character.CHARACTER))
    {
        action.Character.Process(action);
        //Insert end of action clear screen here
    }

    //Run Loop 2
    foreach (var player in aliveAtStartOfNight)
    {
        if (player.HasActionThisNight(nightNumber))
        {
            player.Character.NightActionLoopTwo(_players, player);
        }
        else
        {
            Console.WriteLine("Blank Action");
        }
    }

    //Reset
    Reset();
    //CheckForEndOfGame

    PrintGameState();

    //Day time into vote/excection, virgin check
    Console.ReadLine();

    //check for end of game inc saint

    nightNumber++;
}

void Reset()
{
    _players.ForEach(x => x.IsProtected = false);
    _actions.Clear();
}

//List<Player> GetPlayersWithActions()
//{
//    if (nightNumber == 1)
//    {
//        return [.. _players.Where(x => x.Character.CHARACTER.GetAttribute<ActionTypeAttribute>().ActionType != CharacterNightActionType.EachNightStar)];
//    }
//    else
//    {
//        return [.. _players.Where(x => x.Character.CHARACTER.GetAttribute<ActionTypeAttribute>().ActionType != CharacterNightActionType.YouStartKnowing)];
//    }
//}

void PrintGameState()
{
    foreach (var player in _players)
    {
        Console.WriteLine($"Player: {player.PlayerName}, {(player.IsAlive ? "Alive" : "Dead")}");
    }
}

void CreateDefaultPlayers()
{
    _players.Add(new Player
    {
        PlayerName = "Trent",
        Character = new Imp(),
        IsGood = false
    });

    _players.Add(new Player
    {
        PlayerName = "Jared",
        Character = new Empath(),
        IsGood = true
    });

    _players.Add(new Player
    {
        PlayerName = "Xenia",
        Character = new Monk(),
        IsGood = true
    });

    _players.Add(new Player
    {
        PlayerName = "Nate",
        Character = new Empath(),
        IsGood = true
    });

    _players.Add(new Player
    {
        PlayerName = "Thomas",
        Character = new Empath(),
        IsGood = true
    });
}