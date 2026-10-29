using WerewolfNS.Characters;

namespace WerewolfNS
{
    public class Player
    {
        public string? PlayerName { get; set; }
        public required ICharacter Character { get; set; }

        //Status Bools
        public bool IsAlive { get; set; } = true;
        public bool IsProtected { get; set; }
        public bool IsDrunk { get; set; }
        public bool IsPoisened { get; set; }
        public bool IsDroisened => IsDrunk || IsPoisened;
        public bool IsGood { get; set; }
    }
}
