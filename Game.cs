using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsGame
{
    public class Game
    {
        public List<Card> TotalCards { get; set; }
        public List<Player> Players { get; set; }
        public Game(int numberPlayers)
        {
            TotalCards = new List<Card>();
            Players = new List<Player>();
            for (int i = 0; i < numberPlayers; i++)
            {
                Players.Add(new Player());
            }
            for (int i = 0; i < 36; i++)
            {
                TotalCards.Add(new Card());
            }

            int index = 0;

            foreach (var rank in new[] { Cards.Six, Cards.Seven, Cards.Eight, Cards.Nine, Cards.Ten, Cards.Jack, Cards.Queen, Cards.King, Cards.Ace })
            {
                foreach (var suit in new[] { "Spades", "Hearts", "Diamonds", "Clubs" })
                {
                    TotalCards[index++] = new Card(rank, suit);
                }
            }
            Shuffle();
            HandOutCards(numberPlayers);
        }


        public int ChooseWinner()
        {
            Card maxCard = Players[0].PlayingCard;
            Player winnerPlayer = Players[0];
            int numberOfWinner = Players.IndexOf(Players[0]);
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].PlayingCard.Rank > maxCard.Rank)
                {
                    maxCard = Players[i].PlayingCard;
                    winnerPlayer = Players[i];
                    numberOfWinner = Players.IndexOf(Players[i]);
                }
            }

            for (int i = 0; i < Players.Count; i++)
            {
                Players[numberOfWinner].PlayerCards.Add(Players[i].PlayingCard);
            }

            return numberOfWinner;
        }


        public void Shuffle()
        {
            TotalCards = TotalCards.OrderBy(a => Guid.NewGuid()).ToList();
        }

        public void HandOutCards(int numberOfPlayers)
        {
            int cardsToEachPlayer = TotalCards.Count / numberOfPlayers;

            for (int j = 0; j < cardsToEachPlayer; j++)
            {
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    Players[i].PlayerCards.Add(TotalCards.Last());
                    TotalCards.RemoveAt(TotalCards.Count - 1);
                }
            }
        }


    }

    public enum Cards
    {
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
