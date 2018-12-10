using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopGamesArena.Core.Games
{
    internal class Checkers : Game
    {
        internal override int ID => 2;

        internal override int MaxNumOfPlayers { get { return 2; } }
        internal override int MinNumOfPlayers { get { return 2; } }

        private const int BoardSize = 8;
        internal char[,] Checkerboard { get; private set; }


        internal Checkers()
        {
            Checkerboard = new char[BoardSize,BoardSize];
            SetUpBoard();
        }
        /// <summary>
        /// Sets the initial stricture of the board.
        /// white pawns on one side, black pawns on the other side - all on black spaces
        /// </summary>
        private void SetUpBoard() { }
        /// <summary>
        /// Move pawn up-right diagonally from the source location
        /// throws exception when the move exceeds the bounds of the board
        /// or the cell is taken
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceColumn"></param>
        public void MovePawnUpRight(int sourceRow, int sourceColumn) { }
        /// <summary>
        /// Move pawn up-left diagonally from the source location
        /// throws exception when the move exceeds the bounds of the board
        /// or the cell is taken
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceColumn"></param>
        public void MovePawnUpLeft(int sourceRow, int sourceColumn) { }
        /// <summary>
        /// Move pawn down-right diagonally from the source location
        /// throws exception when the move exceeds the bounds of the board
        /// or the cell is taken
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceColumn"></param>
        public void MovePawnDownRight(int sourceRow, int sourceColumn) { }
        /// <summary>
        /// Move pawn down-left diagonally from the source location
        /// throws exception when the move exceeds the bounds of the board
        /// or the cell is taken
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceColumn"></param>
        public void MovePawnDownLeft(int sourceRow, int sourceColumn) { }

    }
}
