using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WerewolfNS.Characters;

namespace WerewolfNS
{
    public class Player
    {
        public string? PlayerName { get; set; }
        public ICharacter Character { get; set; }
        public bool IsAlive { get; set; } = true;
        public bool IsProtected { get; set; }

        public Player()
        {
            Character = new Empath();
        }
    }
}
