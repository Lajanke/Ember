using ConsoleApp1.Actions;
using System.Text;

namespace ConsoleApp1.Tiles
{
    public class StartTile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(1, 1); } }

        public override string Name => "Beach";

        public override string TravelName => "is a beach";

        public bool wokenUp = false;

        public StartTile()
        {
            _actions.AddRange(new Action[]
            {
                new UseBoatAction(),
                new FixBoatAction(),
                new InspectBoatAction(),
            });

            SetSearchAction(new StartTileSearchAction());
        }

        public override void Turn(GameState state, TravelOptions travelOptions)
        {
            base.Turn(state, travelOptions);
            wokenUp = true;
        }

        protected override void TurnText(GameState state, TravelOptions travelOptions)
        {
            StringBuilder builder = new StringBuilder();

            if (!wokenUp)
            {
                builder.Append("You wake up on a beach, standing next to a [Boat].");
            }
            else if (state.Travelling)
            {
                builder.Append("You arrive at the beach, there is a [Boat] nearby.");
            }
            else
            {
                builder.Append("You are at the beach, there is a [Boat] nearby.");
            }

            builder.Append(TravelText(travelOptions));

            Write(builder.ToString());          
        }
    }
}