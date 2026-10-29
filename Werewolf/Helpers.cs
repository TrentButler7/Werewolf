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

        public static bool HasActionThisNight(this Player player, int nightNumber)
        {
            var actionType = player.Character.CHARACTER.GetAttribute<ActionTypeAttribute>().ActionType;

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
    }
}
