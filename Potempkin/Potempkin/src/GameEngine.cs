using System;
using System.Collections.Generic;
using System.Text;

namespace Potempkin.src
{
    class GameEngine
    {
        private Board _board;
        private Fleet _fleet;

        public int NumberOfShots { get; private set; } = 0;
        public bool Lost => _fleet.ActiveShips == 0;


        public GameEngine()
        {
            _board = new Board();
            _fleet = new Fleet();
        }

        public void StartNewGame()
        {
            foreach (Ship s in _fleet.UnallocatedShips)
            {
                List<string> newLoc = _board.ReservePlace(s.Capacity);
                _fleet.Deploy(newLoc);
            }
        }

        public void FireShot(string Position)
        {
            NumberOfShots++;

            if (_fleet.IncomingSalvo(Position))
                Console.WriteLine(" You hit a target!");
        }

        public string Status => _fleet.Status;


        // Debug purposes only
        public string SpyLocations => _board.SpyLocations();
    }
}
