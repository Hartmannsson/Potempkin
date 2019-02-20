using System;
using System.Collections.Generic;
using System.Text;

namespace Potempkin.src
{
    public class Board
    {
        private List<string> _board = new List<string>(100);
        private List<string> _occupied = new List<string>();
        private int _squareSiqe = 10;

        public Board()
        {
            BuildMatrix();
        }

        private void BuildMatrix()
        {
            for (int letter = 65; letter < 75; letter++)
                for (int n = 1; n < 11; n++)
                    _board.Add(new string( ((char)letter).ToString()) + n.ToString());
        }

        public List<string> ReservePlace(int ShipLength)
        {
            List<string> NewPlaceCandidate = new List<string>(ShipLength);
            int Direction = SetCourse();

            while (true)
            {
                NewPlaceCandidate = CreateSequenceCandidate(ShipLength, Direction);
                if (!_occupied.Exists(o => o == NewPlaceCandidate.Find(x => x == o)))
                {
                    _occupied.AddRange(NewPlaceCandidate);
                    return NewPlaceCandidate;
                }
            }
        }

        private List<string> CreateSequenceCandidate(int ShipLength, int Direction)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            List<string> ret = new List<string>(ShipLength);

            if (Direction == 0)
            {
                int StartingPoint = r.Next(65, 75 - ShipLength);
                int StartingPointFixed = r.Next(1, _squareSiqe);
                for (int i = StartingPoint; i < StartingPoint + ShipLength; i++)
                    ret.Add(new string(((char)i).ToString() + StartingPointFixed));
            }
            else
            {
                int StartingPoint = r.Next(1, _squareSiqe - ShipLength + 2);
                int StartingPointFixed = r.Next(65, 75);
                for (int i = StartingPoint; i < StartingPoint + ShipLength; i++)
                    ret.Add(new string((char)StartingPointFixed + i.ToString()));
            }
            return ret;
        }

        private int SetCourse()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(0, 2);
        }


        // Debug
        public string SpyLocations()
        {
            return string.Join(" ", _occupied.ToArray());
        }
    }
}
