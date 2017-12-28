using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGame
{
    public class Card
    {
        public Cards Rank { get; set; }
        public string Suit { get; set; }
        public Card(Cards rank, string suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public Card()
        {
            Rank = 0;
            Suit = "Default Suit";
        }
    }
}
