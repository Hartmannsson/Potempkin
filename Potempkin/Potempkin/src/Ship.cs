using System;
using System.Collections.Generic;
using System.Text;

namespace Potempkin.src
{
    public class Ship
    {
        private List<string> _coordinates = new List<string>();
        public int Capacity { get; }
        public int Displacement => _coordinates.Count;
        public bool Floating => _coordinates.Count > 0;

        public Ship(int Size)
        {
            Capacity = Size;
            _coordinates = new List<string>(Capacity);
        }

        public void PlaceShip(List<string> Coordinates)
        {
            _coordinates = Coordinates;
        }

        public bool IncomingSalvo(string Bomb)
        {
            return _coordinates.Remove(Bomb);
        }
    }
}
