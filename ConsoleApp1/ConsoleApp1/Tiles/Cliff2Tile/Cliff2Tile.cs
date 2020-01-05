﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tiles.Cliff2Tile
{
    public class Cliff2Tile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(0, 1); } }

        public override string Name => "Cliff";

        public override string TravelName => "are some cliffs";

        public override bool TravelEnterCondition(Direction direction, GameState state)
        {
            return false;
        }

        public override string ForbiddenTravelEnterText(Direction direction, GameState state)
        {
            return "You cannot access the cliffs";
        }
    }
}
