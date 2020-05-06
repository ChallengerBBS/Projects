using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (mainPlayer.GunRepository.Models.Any(g => g.BulletsPerBarrel > 0)
                && civilPlayers.Any(p => p.IsAlive))
            {
                var gun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.BulletsPerBarrel > 0);
                var player = civilPlayers.FirstOrDefault(p => p.IsAlive);

                while (player.IsAlive)
                {
                    player.TakeLifePoints(gun.Fire());

                    if (gun.BulletsPerBarrel == 0)
                    {
                        if (!mainPlayer.GunRepository.Models.Any(g => g.BulletsPerBarrel > 0))
                        {
                            break;
                        }
                        else
                        {
                            gun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.BulletsPerBarrel > 0);
                        }
                    }
                }
            }

            if (civilPlayers.Any(p => p.IsAlive))
            {
                while (mainPlayer.IsAlive
                    && civilPlayers.Any(p => p.GunRepository.Models.Any(m => m.BulletsPerBarrel > 0)))
                {
                    var player = civilPlayers.FirstOrDefault(p => p.IsAlive);

                    while (player.GunRepository.Models.Any(g => g.BulletsPerBarrel > 0))
                    {
                        var gun = player.GunRepository.Models.FirstOrDefault(g => g.BulletsPerBarrel > 0);
                        mainPlayer.TakeLifePoints(gun.Fire());

                        if (!mainPlayer.IsAlive)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}