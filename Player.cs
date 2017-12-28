using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGame
{
    public class Player
    {
        public List<Card> PlayerCards { get; set; }
        public Card PlayingCard { get; set; }

        public Player()
        {
            PlayerCards = new List<Card>();
        }

        public void ChooseCard(int i)
        {
            PlayingCard = PlayerCards[i];
            PlayerCards.RemoveAt(i);
        }



    }
}
