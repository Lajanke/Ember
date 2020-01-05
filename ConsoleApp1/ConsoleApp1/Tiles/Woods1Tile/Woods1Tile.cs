using ConsoleApp1.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tiles.Woods1Tile
{
    public class Woods1Tile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(2, 0); } }

        public override string Name => "Wood";

        public override string TravelName => "is a wood";
        
        public Woods1Tile()
        {
            Actions.AddRange(new Actions.Action[]
            {
                new PickUpItemAction(InventoryItem.Amulet),
                new PickUpItemAction(InventoryItem.Beer),
            });
        }
    }
}
