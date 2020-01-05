using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tiles.BeachTile
{
    public class BeachTile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(1, 2); } }

        public override string Name => "Beach";

        public override string TravelName => "is a beach";
    }
}
