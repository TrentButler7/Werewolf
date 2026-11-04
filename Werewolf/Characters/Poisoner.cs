using WerewolfNS.Enums;

namespace WerewolfNS.Characters
{
    internal class Poisoner : ICharacter
    {
        public Character CHARACTER => Character.Poisoner;

        public CharacterAction? NightActionLoopOne(List<Player> players, Player currentPlayer)
        {
            return new CharacterAction
            {
                Target = Helpers.GetPlayerChoice([.. players.Where(x => x.IsAlive)]),
                PlayerWhoDidThisAction = currentPlayer,
                Character = this,
            };
        }

        public CharacterAction? NightActionLoopTwo(List<Player> players, Player currentPlayer)
        {
            return null;
        }

        public void Process(CharacterAction action)
        {
            if (action.Target == null)
                throw new Exception("Poisoner has no Target");

            action.Target.IsPoisened = true;
        }
    }
}
