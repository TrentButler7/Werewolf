using WerewolfNS.Enums;

namespace WerewolfNS.Characters
{
    internal class Empath : ICharacter
    {
        public CharacterType CHARACTER  => CharacterType.Empath;

        public CharacterAction? NightActionLoopOne(List<Player> _, Player currentPlayer)
        {
            return null;
        }

        public CharacterAction? NightActionLoopTwo(List<Player> players, Player currentPlayer)
        {
            return null;
        }

        public void Process(CharacterAction action)
        {
            throw new NotImplementedException();
        }
    }
}
