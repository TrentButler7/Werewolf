using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerewolfNS.Characters
{
    public interface ICharacter
    {
        CharacterType CHARACTER { get; }
        CharacterAction? Night(List<Player> players, Player currentPlayer);
        void Process(CharacterAction action);
    }
}
