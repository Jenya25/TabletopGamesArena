using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTopGamesArena.Modules;

namespace TabletopGamesArena.Core.Games
{
    internal class CardWar : Game
    {
        internal override int ID => 1;

        internal override int MaxNumOfPlayers { get { return 3; } }
        internal override int MinNumOfPlayers { get { return 2; } }

        /// <summary>
        /// Broadcast "War!" when the cards are equal
        /// </summary>
        internal void WarBroadcast() { }
        /// <summary>
        /// Shuffles a group of cards
        /// </summary>
        /// <param name="cards"></param>
        internal void ShuffleCards(List<FrenchPlayingCard> cards) {        }
        /// <summary>
        /// Compares two cards
        /// </summary>
        /// <param name="firstCard"></param>
        /// <param name="secondCard"></param>
        /// <returns></returns>
        internal int CompareCards(FrenchPlayingCard firstCard, FrenchPlayingCard secondCard)
        {
            return firstCard.CompareTo(secondCard);
        }
        /// <summary>
        /// Devides a deck of cards into even groups of cards
        /// - according to numOfPlayers parameter
        /// </summary>
        /// <param name="numOfPlayers"></param>
        /// <returns></returns>
        internal List<List<FrenchPlayingCard>> DevideTheDeck(int numOfPlayers) { throw new NotImplementedException(); }

    }
}
