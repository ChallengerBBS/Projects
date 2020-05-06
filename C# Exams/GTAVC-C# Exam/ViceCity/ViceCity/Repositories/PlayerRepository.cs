using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class PlayerRepository
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (!players.Any(g => g.Name == player.Name))
            {
                players.Add(player);
            }
        }

        public IPlayer Find(string name)
        {
            return players.FirstOrDefault(g => g.Name == name);
        }

        public bool Remove(IPlayer player)
        {
            return players.Remove(player);
        }
    }
}