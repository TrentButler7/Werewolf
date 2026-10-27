using WerewolfNS.Enums;

namespace WerewolfNS.Characters
{
    internal class Werewolf : ICharacter
    {
        public CharacterType CHARACTER => CharacterType.Werewolf;

        public CharacterAction? NightActionLoopOne(List<Player> players, Player currentPlayer)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(currentPlayer.PlayerName);
            Console.WriteLine("Who to kill");

            var playersWhoAreNotWerewolfs = players
                .Where(x => x.Character.CHARACTER != CharacterType.Werewolf)
                .Where(x => x.IsAlive)
                .ToList();

            for (int i = 1; i <= playersWhoAreNotWerewolfs.Count; i++)
            {
                Console.WriteLine($"{i}: {playersWhoAreNotWerewolfs[i - 1].PlayerName}");
            }
            Console.WriteLine("?");

            var validSelection = int.TryParse(Console.ReadLine(), out var playerInt);
            validSelection = playerInt > 0 && playerInt <= players.Count;

            if (validSelection)
            {
                var player = playersWhoAreNotWerewolfs.ElementAt(playerInt - 1);

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
                throw new Exception("Werewolf has no Target");

            if (action.Target.IsProtected == false)
            {
                action.Target.IsAlive = false;
            }
        }
    }
}
