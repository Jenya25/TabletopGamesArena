using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTopGamesArena.Modules;

namespace TabletopGamesArena.Core.Games
{
    internal class Taki : Game
    {
        internal override int ID => 4;

        internal override int MaxNumOfPlayers { get { return 10; } }
        internal override int MinNumOfPlayers { get { return 2; } }

        private List<TakiCard> DeckOfCards { get; set; }
        internal TakiCard LastPlacedCard { get; set; }

        public Taki()
        {
            InitializeDeck();
        }
        /// <summary>
        /// Broadcast "Last Card!"
        /// </summary>
        internal void LastCardBroadcast() { }
        /// <summary>
        /// Checks if the card is suitble to place -
        /// according to the last card on the table
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        internal bool CheckCardIsValid(TakiCard card) { throw new NotImplementedException(); }
        /// <summary>
        /// gets a card from the deck
        /// </summary>
        /// <returns>Top Card From The Deck</returns>
        public TakiCard GetCardFromTheDeck() { throw new NotImplementedException(); }
        /// <summary>
        /// initializes the deck with all the taki cards
        /// </summary>
        private void InitializeDeck() { }
    }
}
