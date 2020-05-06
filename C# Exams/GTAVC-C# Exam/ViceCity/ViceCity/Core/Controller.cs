using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private GangNeighbourhood hood;
        private List<IPlayer> civils;
        private List<IGun> guns;
        private IPlayer mainPlayer;

        public Controller()
        {
            hood = new GangNeighbourhood();
            civils = new List<IPlayer>();
            guns = new List<IGun>();
            mainPlayer = new MainPlayer();

        }
        public string AddGun(string type, string name)
        {
            if (type == "Pistol")
            {
                var gun = new Pistol(name);
                guns.Add(gun);
                return $"Successfully added {name} of type: {type}";
            }
            else if (type == "Rifle")
            {
                var gun = new Rifle(name);
                guns.Add(gun);
                return $"Successfully added {name} of type: {type}";
            }
            else
            {
                return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            var gun = guns[0];
            string gunName = gun.Name;

            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(gun);
                guns.RemoveAt(0);
                return $"Successfully added {gunName} to the Main Player: Tommy Vercetti";
            }
            else if (!civils.Any(p => p.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }
            else
            {
                var player = civils.FirstOrDefault(p => p.Name == name);

                player.GunRepository.Add(gun);
                guns.RemoveAt(0);
                return $"Successfully added {gunName} to the Civil Player: {player.Name}";
            }
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);
            civils.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            hood.Action(mainPlayer, civils);

            if (mainPlayer.IsAlive && civils.All(p => p.IsAlive))
            {
                return "Everything is okay!";
            }
            else
            {
                var sb = new StringBuilder();

                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {civils.Where(p => !p.IsAlive).Count()} players!");
                sb.AppendLine($"Left Civil Players: {civils.Where(p => p.IsAlive).Count()}!");

                return sb.ToString().TrimEnd();
            }
        }
    }
}