namespace ConsoleApp1.Actions
{
    public class GoNorthEastAction : Action
    {
        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            
            if (parts.Length == 2 && IsGo(parts[0]) && IsNorthEast(parts[1]))
            { 
                return true; 
            }

            return parts.Length >= 3 && IsGo(parts[0]) && IsNorth(parts[1]) && IsEast(parts[2]);
        }

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (travelOptions.NorthEast == null)
            {
                Write("You cannot travel [NorthEast] from here.");
                return;
            }

            if (!travelOptions.CurrentLocation.TravelExitCondition(Direction.NorthEast, state))
            {
                Write(travelOptions.CurrentLocation.ForbiddenTravelExitText(Direction.NorthEast, state));
                return;
            }


            if (!travelOptions.NorthEast.TravelEnterCondition(Direction.NorthEast, state))
            {
                Write(travelOptions.NorthEast.ForbiddenTravelEnterText(Direction.NorthEast, state));
                return;
            }

            state.PlayerLocation = new Vector2Int(state.PlayerLocation.X + 1, state.PlayerLocation.Y - 1);
            state.Travelling = true;
            Write("You travel [NorthEast]");
        }

        private bool IsGo(string input) => IsOneOf(input, new [] { "go", "travel" });

        private bool IsNorth(string input) => IsOneOf(input, new[] { "north" });

        private bool IsNorthEast(string input) => IsOneOf(input, new[] { "northeast", "north-east" });

        private bool IsEast(string input) => IsOneOf(input, new[] { "east" });
    }
}