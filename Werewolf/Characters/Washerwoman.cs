using WerewolfNS.Enums;

namespace WerewolfNS.Characters
{
    internal class Washerwoman : ICharacter
    {
        public Character CHARACTER  => Character.Washerwoman;

        public CharacterAction? NightActionLoopOne(List<Player> _, Player currentPlayer)
        {
            return null;
        }

        public CharacterAction? NightActionLoopTwo(List<Player> players, Player currentPlayer)
        {
            var minions = players
                .Where(x => x.Character?.CHARACTER.GetAttribute<CharachterTypeAttribute>().CharachterType == CharacterType.Minion);

            var numberToGive = currentPlayer.IsDroisened ? Helpers.RandomNumberExcluding(trueNumber, 0, 2) : trueNumber;
            
            Console.WriteLine($"You learn a {numberToGive}");

            return null;
        }

        public void Process(CharacterAction action) { }
    }
}
