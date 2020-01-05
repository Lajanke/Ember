using ConsoleApp1.Actions;
using System.Text;

namespace ConsoleApp1.Tiles
{
    public class WoodsTile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(1, 0); } }

        public override string Name => "Woods";

        public override string TravelName => "are some woods";

        public WoodsTile()
        {
            _actions.AddRange(new Action[]
            {
                new GoSouthAction(),
                new PickUpItemAction(InventoryItem.Wood),
                new SearchAction(),
            });
        }

        protected override void TurnText(GameState state, TravelOptions travelOptions)
        {
            StringBuilder builder = new StringBuilder();

            if (state.Travelling)
            {
                builder.Append("You arrive at the woods");
            }
            else
            {
                builder.Append("You are in the woods");
            }

            if (!state.Inventory.HasItem(InventoryItem.Wood))
            {
                builder.Append(", there is some [Wood] nearby");
            }

            builder.Append(".");
            builder.Append(TravelText(travelOptions));

            Write(builder.ToString());
        }
    }
}