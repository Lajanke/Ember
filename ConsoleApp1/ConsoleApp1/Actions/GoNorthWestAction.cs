namespace ConsoleApp1.Actions
{
    public class GoNorthWestAction : Action
    {
        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            
            if (parts.Length == 2 && IsGo(parts[0]) && IsNorthWest(parts[1]))
            { 
                return true; 
            }

            return parts.Length >= 3 && IsGo(parts[0]) && IsNorth(parts[1]) && IsWest(parts[2]);
        }

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (travelOptions.NorthWest == null)
            {
                Write("You cannot travel [NorthWest] from here.");
                return;
            }

            if (!travelOptions.CurrentLocation.TravelExitCondition(Direction.NorthWest, state))
            {
                Write(travelOptions.CurrentLocation.ForbiddenTravelExitText(Direction.NorthWest, state));
                return;
            }

            if (!travelOptions.NorthWest.TravelEnterCondition(Direction.NorthWest, state))
            {
                Write(travelOptions.NorthWest.ForbiddenTravelEnterText(Direction.NorthWest, state));
                return;
            }

            state.PlayerLocation = new Vector2Int(state.PlayerLocation.X - 1, state.PlayerLocation.Y - 1);
            state.Travelling = true;
            Write("You travel [NorthWest]");
        }

        private bool IsGo(string input) => IsOneOf(input, new [] { "go", "travel" });

        private bool IsNorth(string input) => IsOneOf(input, new[] { "north" });

        private bool IsNorthWest(string input) => IsOneOf(input, new[] { "northwest", "north-west" });

        private bool IsWest(string input) => IsOneOf(input, new[] { "west" });
    }
}