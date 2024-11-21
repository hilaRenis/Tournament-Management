using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;

namespace Mock_DAL
{
    public class FakePlayerDBMediator : IPlayerRepository
    {
        private List<Player> players;

        public FakePlayerDBMediator()
        {
            this.players = new List<Player>();
        }

        public bool DeletePlayer(int playerId)
        {
            if (GetPlayerById(playerId) != null)
            {
                return this.players.Remove(GetPlayerById(playerId));
            }

            return false;
        }

        public List<Player> GetPlayers()
        {
            return this.players;
        }

        public Player GetPlayerById(int playerId)
        {
            foreach (Player player in this.players)
            {
                if (player.Id == playerId)
                    return player;
            }

            return null;
        }

        public bool InsertPlayer(Player player)
        {
            if (player == null)
            {
                return false;
            }

            this.players.Add(player);
            return true;
        }

        public bool UpdatePlayer(Player player)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Id == player.Id)
                {
                    players[i] = player;
                    return true;
                }
            }

            return false;
        }
    }
}
