using ConsoleApp1.Actions;
using System.Text;

namespace ConsoleApp1.Tiles
{
    public class CabinTile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(0, 1); } }

        public override string Name => "Cabin";

        public override string TravelName => "is a cabin";

        public CabinTile()
        {
            _actions.AddRange(new Action[]
            {
                new PickUpItemAction(InventoryItem.Hammer),
            });
        }

        protected override void TurnText(GameState state, TravelOptions travelOptions)
        {
            StringBuilder builder = new StringBuilder();

            if (state.Travelling)
            {
                builder.Append("You arrive at the cabin");
            }
            else
            {
                builder.Append("You are by the cabin");
            }

            if (!state.Inventory.HasItem(InventoryItem.Hammer))
            {
                builder.Append(", there is a [Hammer] nearby");
            }

            builder.Append(".");
            builder.Append(TravelText(travelOptions));

            Write(builder.ToString());
        }
    }
}