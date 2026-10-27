using WerewolfNS.Characters;

namespace WerewolfNS
{
    public class CharacterAction
    {
        public Player? Target { get; set; }
        public Player? PlayerWhoDidThisAction { get; set; }
        public required ICharacter Character { get; set; }
    }
}
