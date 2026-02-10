using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerewolfNS.Characters
{
    internal class Villager : ICharacter
    {
        public CharacterType CHARACTER  => CharacterType.Villager;

        public CharacterAction? Night(List<Player> _, Player currentPlayer)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(currentPlayer.PlayerName);
            Console.WriteLine("You are sad, there is nothing to do");
            Console.ReadLine();

            return null;
        }

        public void Process(CharacterAction action)
        {
            throw new NotImplementedException();
        }
    }
}
