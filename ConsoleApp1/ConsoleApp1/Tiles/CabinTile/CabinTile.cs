using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tiles.CabinTile
{
    public class CabinTile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(2, 1); } }

        public override string Name => "Cabin";

        public override string TravelName => "is a cabin";
    }
}
