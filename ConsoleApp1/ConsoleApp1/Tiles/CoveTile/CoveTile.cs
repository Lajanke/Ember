using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tiles.CoveTile
{
    public class CoveTile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(0, 0); } }

        public override string Name => "Cove";

        public override string TravelName => "is a cove";
    }
}
