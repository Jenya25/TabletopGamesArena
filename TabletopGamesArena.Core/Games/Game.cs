using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopGamesArena.Core.Modules;

namespace TabletopGamesArena.Core.Games
{
    public abstract class Game
    {
        internal abstract int ID { get; }
        internal abstract int MaxNumOfPlayers { get; }
        internal abstract int MinNumOfPlayers { get; }
        
        private List<Player> Players { get; }

        internal Game()
        {
            Players = new List<Player>();
        }

        internal int GetNumOfActivePlayers() => Players.Count;

        internal void AddPlayer(Player player)
        {
            if (!RoomIsFull())
            {
                Players.Add(player);
            }
            else
            {
                throw new Exception("No More Players Can Join The Game.");
            }
        }
        internal void RemovePlayer(Player player)
        {
            if (Players.Contains(player))
            {
                Players.Remove(player);
            }
        }
        internal Player RandomWinner()
        {
            if(Players.Count < MinNumOfPlayers)
            {
                throw new Exception("Game hasn't started yet!");
            }

            Random rnd = new Random();
            int index = rnd.Next(Players.Count);

            return Players[index];
        }

        internal bool GameCanStart() => Players.Count >= MinNumOfPlayers;
        internal bool RoomIsFull() => Players.Count == MaxNumOfPlayers;
    }
}
