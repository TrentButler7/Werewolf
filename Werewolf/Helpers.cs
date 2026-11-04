using WerewolfNS.Enums;

namespace WerewolfNS
{
    public static class Helpers
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }

        public static bool IsMinionOrDemon(this Player player)
        {
            var charType = player.Character?.CHARACTER.GetAttribute<CharachterTypeAttribute>().CharachterType;

            return charType == CharacterType.Minion || charType == CharacterType.Demon;
        }

        public static bool IsDemon(this Player player)
        {
            var charType = player.Character?.CHARACTER.GetAttribute<CharachterTypeAttribute>().CharachterType;

            return charType == CharacterType.Demon;
        }

        public static bool HasActionThisNight(this Player player, int nightNumber)
        {
            var actionType = player.Character?.CHARACTER.GetAttribute<ActionTypeAttribute>().ActionType;

            if (nightNumber == 1)
            {
                return actionType == CharacterNightActionType.EachNight || actionType == CharacterNightActionType.YouStartKnowing; 
            }
            else
            {
                return actionType == CharacterNightActionType.EachNight || actionType == CharacterNightActionType.EachNightStar;
            }
        }

        public static List<Player> GetNeighbors(Player currentPlayer, List<Player> players)
        {
            var index = players.IndexOf(currentPlayer);

            var leftIndex = index == 0 ? players.Count - 1 : index - 1;
            var rightIndex = index + 1 >= players.Count ? 0 : index + 1;

            return [players.ElementAt(leftIndex), players.ElementAt(rightIndex)];
        }

        public static int RandomNumberExcluding(int excluding, int min, int max)
        {
            var random = new Random();

            int result = random.Next(min, max);

            if (result >= excluding)
            {
                result++;
            }

            return result;
        }

        public static Player GetPlayerChoice(List<Player> players)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Who to pick");

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

                return player;
            }

            return GetPlayerChoice(players);
        }
    }
}
