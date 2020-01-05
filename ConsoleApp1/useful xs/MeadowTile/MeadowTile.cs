using ConsoleApp1.Actions;
using System.Text;

namespace ConsoleApp1.Tiles
{
    public class MeadowTile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(2, 1); } }

        public override string Name => "Meadow";

        public override string TravelName => "is a meadow";

        public MeadowTile()
        {
            _actions.AddRange(new Action[]
            {
                new PickUpItemAction(InventoryItem.Nails),
            });
        }


        protected override void TurnText(GameState state, TravelOptions travelOptions)
        {
            StringBuilder builder = new StringBuilder();

            if (state.Travelling)
            {
                builder.Append("You arrive at the meadow");
            }
            else
            {
                builder.Append("You are in the meadow");
            }

            if (!state.Inventory.HasItem(InventoryItem.Nails))
            {
                builder.Append(", there are some [Nails] nearby");
            }

            builder.Append(".");
            builder.Append(TravelText(travelOptions));

            Write(builder.ToString());
        }
    }
}