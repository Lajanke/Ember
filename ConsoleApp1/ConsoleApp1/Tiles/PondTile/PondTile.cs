using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tiles.PondTile
{
    public class PondTile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(2, 2); } }

        public override string Name => "Pond";

        public override string TravelName => "is a pond";
    }
}
