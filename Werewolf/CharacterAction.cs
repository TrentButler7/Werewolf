using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WerewolfNS;
using WerewolfNS.Characters;

namespace WerewolfNS
{
    public class CharacterAction
    {
        public Player? Target { get; set; }
        public Player? PlayerWhoDidThisAction { get; set; }
        public ICharacter Character { get; set; }
    }
}
