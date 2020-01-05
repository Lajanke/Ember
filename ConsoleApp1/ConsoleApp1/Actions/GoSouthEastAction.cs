namespace ConsoleApp1.Actions
{
    public class GoSouthEastAction : Action
    {
        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            
            if (parts.Length == 2 && IsGo(parts[0]) && IsSouthEast(parts[1]))
            { 
                return true; 
            }

            return parts.Length >= 3 && IsGo(parts[0]) && IsSouth(parts[1]) && IsEast(parts[2]);
        }

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (travelOptions.SouthEast == null)
            {
                Write("You cannot travel [SouthEast] from here.");
                return;
            }

            if (!travelOptions.CurrentLocation.TravelExitCondition(Direction.SouthEast, state))
            {
                Write(travelOptions.CurrentLocation.ForbiddenTravelExitText(Direction.SouthEast, state));
                return;
            }

            if (!travelOptions.SouthEast.TravelEnterCondition(Direction.SouthEast, state))
            {
                Write(travelOptions.SouthEast.ForbiddenTravelEnterText(Direction.SouthEast, state));
                return;
            }

            state.PlayerLocation = new Vector2Int(state.PlayerLocation.X + 1, state.PlayerLocation.Y + 1);
            state.Travelling = true;
            Write("You travel [SouthEast]");
        }

        private bool IsGo(string input) => IsOneOf(input, new [] { "go", "travel" });

        private bool IsSouth(string input) => IsOneOf(input, new[] { "south" });

        private bool IsSouthEast(string input) => IsOneOf(input, new[] { "southeast", "south-east" });

        private bool IsEast(string input) => IsOneOf(input, new[] { "east" });
    }
}