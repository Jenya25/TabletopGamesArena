using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopGamesArena.Core.Games
{
    internal class Chess : Game
    {
        internal enum PawnType { Rook, Knight, Bishop, Queen, King, Pawn }

        internal override int ID => 3;

        internal override int MaxNumOfPlayers { get { return 2; } }
        internal override int MinNumOfPlayers { get { return 2; } }

        private const int BoardSize = 8;
        internal char[,] Chessboard { get; private set; }

        internal Chess()
        {
            Chessboard = new char[BoardSize, BoardSize];
            SetUpBoard();
        }
        /// <summary>
        /// Sets the initial stricture of the board.
        /// asigns pawns to their initial places
        /// black pawns on one side, white pawns on the other
        /// </summary>
        private void SetUpBoard() { }
        /// <summary>
        /// check if the conditions enabling a castling by the king
        /// </summary>
        /// <returns></returns>
        private bool CheckIfCastlingIsPosible() { throw new NotImplementedException(); }
        /// <summary>
        /// Broadcast "Check"
        /// throws exception if the conditions for a check not occured
        /// </summary>
        public void CheckBroadcast() { }
    }

}
