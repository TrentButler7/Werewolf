using WerewolfNS;
using WerewolfNS.Characters;

List<Player> _players = new();
List<CharacterAction> actions = new();
CreateDefaultPlayers();

while (true)
{
    //Night Loop
    var alivePlayers = _players.Where(x => x.IsAlive);

    foreach (var player in alivePlayers)
    {
        var actionTaken = player.Character.Night(_players, player);

        if (actionTaken != null)
        {
            actions.Add(actionTaken);
        }
    }

    actions = actions
        .OrderBy(x => x.Character.CHARACTER)
        .ToList();

    foreach (var action in actions)
    {
        action.Character.Process(action);
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
        Character = new Villager(),
    });

    _players.Add(new Player
    {
        PlayerName = "Xenia",
        Character = new Villager(),
    });

    _players.Add(new Player
    {
        PlayerName = "Nate",
        Character = new Villager(),
    });

    _players.Add(new Player
    {
        PlayerName = "Thomas",
        Character = new Villager(),
    });
}