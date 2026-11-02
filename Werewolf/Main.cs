using System.Runtime.InteropServices;
using WerewolfNS;
using WerewolfNS.Characters;

List<Player> _players = [];
List<CharacterAction?> _actions = [];
List<ICharacter> _tokenBag = [];
int nightNumber = 1;
bool adminMode = true;

CreateDefaultPlayers();
CreateBag();
AssignTokens();
PrintGameState(adminMode);

while (true)
{
    var aliveAtStartOfNight = _players.Where(x => x.IsAlive);

    //Run Loop One
    foreach (var player in aliveAtStartOfNight)
    {
        PrintStartOrEndOfAction(player, false);

        if (player.HasActionThisNight(nightNumber))
        {
            _actions.Add(player.Character?.NightActionLoopOne(_players, player));
        }
        else
        {
            Console.WriteLine("Blank Action");
        }

        PrintStartOrEndOfAction(player, true);
    }

    //Process
    foreach (var action in _actions.OfType<CharacterAction>().OrderBy(x => x.Character.CHARACTER))
    {
        action.Character.Process(action);
    }

    //Run Loop 2
    foreach (var player in aliveAtStartOfNight)
    {
        PrintStartOrEndOfAction(player, false);

        if (player.HasActionThisNight(nightNumber))
        {
            player.Character?.NightActionLoopTwo(_players, player);
        }
        else
        {
            Console.WriteLine("Blank Action");
        }

        PrintStartOrEndOfAction(player, true);
    }

    //Reset
    Reset();
    //CheckForEndOfGame

    PrintGameState(adminMode);

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

void PrintGameState(bool showRolesAndAlignments)
{
    Console.WriteLine($"Night {nightNumber}");

    foreach (var player in _players)
    {
        if (showRolesAndAlignments)
        {
            Console.WriteLine($"Player: {player.PlayerName}, {(player.IsAlive ? "Alive" : "Dead")}, {player.Character}, {(player.IsGood ? "Good" : "Evil")}");
        }
        else
        {
            Console.WriteLine($"Player: {player.PlayerName}, {(player.IsAlive ? "Alive" : "Dead")}");
        }
    }

    Console.ReadLine();
    Console.Clear();
}

void PrintStartOrEndOfAction(Player player, bool isEndOfTurn)
{
    Console.WriteLine($"{player.PlayerName}, press enter to {(isEndOfTurn ? "end" : "start")} your action");
    Console.ReadLine();
    Console.Clear();
}

void AssignTokens()
{
    if (_tokenBag.Count != _players.Count)
    {
        throw new Exception("Bag not equal to player count");
    }

    Random.Shared.Shuffle(CollectionsMarshal.AsSpan(_tokenBag));

    foreach (var player in _players)
    {
        player.Character = _tokenBag.First();
        _tokenBag.RemoveAt(0);

        player.IsGood = player.IsMinionOrDemon() == false;
    }

    //Sanity check
    if (_players.Any(x => x.Character is null))
    {
        throw new Exception("Not all charachters have tokens");
    }
}

void CreateDefaultPlayers()
{
    _players.Add(new Player
    {
        PlayerName = "Trent",
    });

    _players.Add(new Player
    {
        PlayerName = "Jared",
    });

    _players.Add(new Player
    {
        PlayerName = "Xenia",
    });

    _players.Add(new Player
    {
        PlayerName = "Nate",
    });

    _players.Add(new Player
    {
        PlayerName = "Thomas",
    });
}

void CreateBag()
{
    _tokenBag = [new Imp(), new Empath(), new Monk(), new Empath(), new Empath()];
}