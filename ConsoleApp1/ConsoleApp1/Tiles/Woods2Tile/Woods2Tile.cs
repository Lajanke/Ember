using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tiles.Woods2Tile
{
    public class Woods2Tile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(1, 1); } }

        public override string Name => "Wood";

        public override string TravelName => "is a wood";
    }
}
