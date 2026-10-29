using WerewolfNS.Enums;

namespace WerewolfNS.Characters
{
    internal class Imp : ICharacter
    {
        public Character CHARACTER => Character.Imp;

        public CharacterAction? NightActionLoopOne(List<Player> players, Player currentPlayer)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(currentPlayer.PlayerName);
            Console.WriteLine("Who to kill");

            for (int i = 1; i <= players.Count; i++)
            {
                Console.WriteLine($"{i}: {players[i - 1].PlayerName}");
            }
            Console.WriteLine("?");

            var validSelection = int.TryParse(Console.ReadLine(), out var playerInt);
            validSelection = playerInt > 0 && playerInt <= players.Count;

            if (validSelection)
            {
                var player = players.ElementAt(playerInt - 1);

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

            if (action.Target.IsProtected == false || action.Target.Character.CHARACTER == Character.Soldier)
            {
                action.Target.IsAlive = false;
            }
        }
    }
}
