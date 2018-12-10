using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TableTopGamesArena.Modules.FrenchPlayingCard;

namespace TableTopGamesArena.Modules
{
    internal class FrenchPlayingCard : Tuple<CardValue, CardSuit>, IComparable<FrenchPlayingCard>
    {
        internal enum CardSuit { Hearts, Tiles, Clovers, Pikes, RedJoker, BlackJoker }
        internal enum CardValue { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Prince, Queen, King, Ace, Joker }

        internal CardValue Value { get; }
        internal CardSuit Suit { get; }

        public FrenchPlayingCard(CardValue _value, CardSuit _suit) : base(_value, _suit)
        {
            if (((_suit == CardSuit.BlackJoker || _suit == CardSuit.RedJoker) && _value != CardValue.Joker) ||
                    (_suit != CardSuit.BlackJoker && _suit != CardSuit.RedJoker && _value == CardValue.Joker))
            {
                throw new ArgumentException("Incorrect Suit-Value pair.");
            }

            Value = _value;
            Suit = _suit;
        }
        /// <summary>
        /// Compare two cards
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// -1 if this instance smaller then the other card
        /// 0 if they are equal
        /// 1 if this instance bigger then the other card
        /// </returns>
        public int CompareTo(FrenchPlayingCard other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
