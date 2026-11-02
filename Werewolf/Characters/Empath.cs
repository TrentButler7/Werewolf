using WerewolfNS.Enums;

namespace WerewolfNS.Characters
{
    internal class Empath : ICharacter
    {
        public Character CHARACTER  => Character.Empath;

        public CharacterAction? NightActionLoopOne(List<Player> _, Player currentPlayer)
        {
            return null;
        }

        public CharacterAction? NightActionLoopTwo(List<Player> players, Player currentPlayer)
        {
            var trueNumber = Helpers
                .GetNeighbors(currentPlayer, players)
                .Count(x => x.IsGood == false);

            var numberToGive = currentPlayer.IsDroisened ? Helpers.RandomNumberExcluding(trueNumber, 0, 2) : trueNumber;
            
            Console.WriteLine($"You learn a {numberToGive}");

            return null;
        }

        public void Process(CharacterAction action) { }
    }
}
