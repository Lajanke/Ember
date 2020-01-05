namespace ConsoleApp1.Tiles
{
    public class SeaTile : Tile
    {
        public override Vector2Int Location { get { return new Vector2Int(1, 2); } }

        public override string Name => "The Sea";

        public override string TravelName => "is the sea";

        protected override void TurnText(GameState state, TravelOptions travelOptions)
        {
            Write("You swim into the sea but the tide is strong and you are swept out into the ocean.");
            state.Died = true;
        }
    }
}