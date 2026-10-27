using WerewolfNS;
using WerewolfNS.Characters;
using WerewolfNS.Enums;

List<Player> _players = [];
List<CharacterAction?> _actions = [];
int nightNumber = 1;
CreateDefaultPlayers();

while (true)
{
    //Build Night Loop
    _actions = GetPlayersWithActions()
        .Where(x => x.IsAlive)
        .Select(x => x.Character.NightActionLoopOne(_players, x))
        .Concat(_players
            .Where(x => x.IsAlive)
            .Select(x => x.Character.NightActionLoopTwo(_players, x)))
        .ToList();

    //Excecute Night Loop
    foreach (var action in _actions)
    {
        if (action is null)
        {
            //insert blank action
        }
        else
        {
            action.Character.Process(action);
        }
    }

    //Reset
    Reset();

    //Day time into vote/excection
}

void Reset()
{
    _players.ForEach(x => x.IsProtected = false);
    _actions.Clear();
}

List<Player> GetPlayersWithActions()
{
    if (nightNumber == 1)
    {
        return [.. _players.Where(x => x.Character.CHARACTER.GetAttribute<ActionTypeAttribute>().ActionType != CharacterNightActionType.EachNightStar)];
    }
    else
    {
        return [.. _players.Where(x => x.Character.CHARACTER.GetAttribute<ActionTypeAttribute>().ActionType != CharacterNightActionType.YouStartKnowing)];
    }
}


void CreateDefaultPlayers()
{
    _players.Add(new Player
    {
        PlayerName = "Trent",
        Character = new Werewolf(),
    });

    _players.Add(new Player
    {
        PlayerName = "Jared",
        Character = new Empath(),
    });

    _players.Add(new Player
    {
        PlayerName = "Xenia",
        Character = new Monk(),
    });

    _players.Add(new Player
    {
        PlayerName = "Nate",
        Character = new Empath(),
    });

    _players.Add(new Player
    {
        PlayerName = "Thomas",
        Character = new Empath(),
    });
}