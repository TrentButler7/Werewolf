using WerewolfNS.Enums;

namespace WerewolfNS.Characters
{
    public interface ICharacter
    {
        Character CHARACTER { get; }

        CharacterAction? NightActionLoopOne(List<Player> players, Player currentPlayer);
        CharacterAction? NightActionLoopTwo(List<Player> players, Player currentPlayer);
        void Process(CharacterAction action);

    }
}
