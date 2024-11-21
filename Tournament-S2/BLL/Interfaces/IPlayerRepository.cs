using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPlayerRepository
    {
        public List<Player> GetPlayers();
        public Player GetPlayerById(int playerId);
        public bool InsertPlayer(Player Player);
        public bool UpdatePlayer(Player Player);
        public bool DeletePlayer(int playerId);
    }
}
