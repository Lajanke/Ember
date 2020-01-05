using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ConsoleApp1.Tiles.CaveTile
{
    public class CaveTile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(0, 2); } }

        public override string Name => "Cave";

        public override string TravelName => "is a cave";

        public override bool TravelEnterCondition(Direction direction, GameState state)
        {
            return direction == Direction.West;
        }

        public override bool TravelExitCondition(Direction direction, GameState state)
        {
            return direction == Direction.East;
        }
        public override void Turn(GameState state, TravelOptions travelOptions)
        {
            if (state.Inventory.HasItem(InventoryItem.Amulet))
            { 
                base.Turn(state, travelOptions); 
            }
            
            else
            {
                Write($"You enter the {Name} and a loud roar knocks you back.");
                Actions.Action action = Actions.First(a => a.GetType() == typeof(Actions.GoEastAction));
                action.Run(null, state, travelOptions);
            }
        }
    }
}
