using System;
using System.Collections.Generic;
using System.Text;

namespace Potempkin.src
{
    class Fleet
    {
        private List<Ship> Ships;

        public Fleet()
        {
            Ships = new List<Ship>(3)
            {
         //       new Ship(3),

                new Ship(5),
                new Ship(4),
                new Ship(4)


  //              new Ship(3),
//                new Ship(1)
            };
        }

        public Ship UnallocatedShip => Ships.Find(f => f.Displacement == 0);

        public List<Ship> UnallocatedShips => Ships.FindAll(f => f.Displacement == 0);

        public void Deploy(List<string> positions)
        {
            Ship s = Ships.Find(f => f.Displacement == 0);
            s.PlaceShip(positions);
        }

        public bool IncomingSalvo(string Bomb)
        {
            return Ships.Exists(s => s.IncomingSalvo(Bomb));
        }

        public int ActiveShips => Ships.FindAll(s => s.Floating).Count;

        public string Status => Ships.FindAll(s => s.Displacement > 0).Count.ToString();

    }
}
