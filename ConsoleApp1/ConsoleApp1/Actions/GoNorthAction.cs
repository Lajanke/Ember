namespace ConsoleApp1.Actions
{
    public class GoNorthAction : Action
    {
        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            return parts.Length >= 2 && IsGo(parts[0]) && IsNorth(parts[1]);
        }

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (travelOptions.North == null)
            {
                Write("You cannot travel [North] from here.");
                return;
            }

            if (!travelOptions.CurrentLocation.TravelExitCondition(Direction.North, state))
            {
                Write(travelOptions.CurrentLocation.ForbiddenTravelExitText(Direction.North, state));
                return;
            }

            if (!travelOptions.North.TravelEnterCondition(Direction.North, state))
            {
                Write(travelOptions.North.ForbiddenTravelEnterText(Direction.North, state));
                return;
            }

            state.PlayerLocation = new Vector2Int(state.PlayerLocation.X, state.PlayerLocation.Y - 1);
            state.Travelling = true;
            Write("You travel [North]");
        }

        private bool IsGo(string input) => IsOneOf(input, new [] { "go", "travel" });

        private bool IsNorth(string input) => IsOneOf(input, new[] { "north", "forward", "forwards" });
    }
}