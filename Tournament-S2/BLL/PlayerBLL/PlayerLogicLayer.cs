using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PlayerBLL
{
    public class PlayerLogicLayer
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerLogicLayer(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public List<Player> GetAllPlayers()
        {
            List<Player> playerList = new List<Player>();

            playerList = playerRepository.GetPlayers();

            return playerList;
        }

        public bool AddNewPlayer(Player player)
        {
            return playerRepository.InsertPlayer(player);
        }

        public Player GetPlayerById(Player player)
        {
            return playerRepository.GetPlayerById(player.Id);
        }

        public bool UpdatePlayer(Player player)
        {
            return playerRepository.UpdatePlayer(player);
        }

        public bool DeletePlayer(Player player)
        {
            return playerRepository.DeletePlayer(player.Id);
        }
    }
}
