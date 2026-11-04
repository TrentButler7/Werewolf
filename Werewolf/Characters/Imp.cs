using WerewolfNS.Enums;

namespace WerewolfNS.Characters
{
    internal class Imp : ICharacter
    {
        public Character CHARACTER => Character.Imp;

        public CharacterAction? NightActionLoopOne(List<Player> players, Player currentPlayer)
        {
            return new CharacterAction
            {
                Target = Helpers.GetPlayerChoice(players),
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
                throw new Exception("Werewolf has no Target");

            if (action.Target.IsProtected == false || action.Target.Character?.CHARACTER == Character.Soldier)
            {
                action.Target.IsAlive = false;
            }
        }
    }
}
