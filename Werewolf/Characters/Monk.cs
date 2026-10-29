using WerewolfNS.Enums;

namespace WerewolfNS.Characters
{
    internal class Monk : ICharacter
    {
        public Character CHARACTER => Character.Monk;

        public CharacterAction? NightActionLoopOne(List<Player> players, Player currentPlayer)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(currentPlayer.PlayerName);
            Console.WriteLine("Who to save");

            var alivePlayers = players
                .Where(x => x.IsAlive)
                .ToList();

            for (int i = 1; i <= alivePlayers.Count; i++)
            {
                Console.WriteLine($"{i}: {alivePlayers[i - 1].PlayerName}");
            }
            Console.WriteLine("?");

            var validSelection = int.TryParse(Console.ReadLine(), out var playerInt);
            validSelection = playerInt > 0 && playerInt <= players.Count;

            if (validSelection)
            {
                var player = alivePlayers.ElementAt(playerInt - 1);

                return new CharacterAction
                {
                    Target = player,
                    PlayerWhoDidThisAction = currentPlayer,
                    Character = this,
                };
            }
            else
            {
                NightActionLoopOne(players, currentPlayer);
            }

            return null;
        }

        public CharacterAction? NightActionLoopTwo(List<Player> players, Player currentPlayer)
        {
            return null;
        }

        public void Process(CharacterAction action)
        {
            if (action.Target == null)
                throw new Exception("Monk has no Target");

            action.Target.IsProtected = true;
        }
    }
}
