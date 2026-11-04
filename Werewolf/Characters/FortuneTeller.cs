using WerewolfNS.Enums;

namespace WerewolfNS.Characters
{
    internal class FortuneTeller : ICharacter
    {
        public Character CHARACTER => Character.FortuneTeller;

        public CharacterAction? NightActionLoopOne(List<Player> players, Player currentPlayer)
        {
            return null;
        }

        public CharacterAction? NightActionLoopTwo(List<Player> players, Player currentPlayer)
        {
            var player1 = Helpers.GetPlayerChoice(players);
            var player2 = Helpers.GetPlayerChoice([.. players.Where(x => x != player1)]);

            var trueAnswer = player1.IsDemon() || player1.IsRedHerring || player2.IsDemon() || player2.IsRedHerring;

            var answerToGive = currentPlayer.IsDroisened ? trueAnswer == false : trueAnswer;

            Console.WriteLine($"You learn a {(answerToGive ? "Yes" : "No")}");

            return null;
        }

        public void Process(CharacterAction action) { }
    }
}
