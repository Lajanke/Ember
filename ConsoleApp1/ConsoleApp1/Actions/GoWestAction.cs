namespace ConsoleApp1.Actions
{
    public class GoWestAction : Action
    {
        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            return parts.Length >= 2 && IsGo(parts[0]) && IsWest(parts[1]);
        }

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (travelOptions.West == null)
            {
                Write("You cannot travel [West] from here.");
                return;
            }

            if (!travelOptions.CurrentLocation.TravelExitCondition(Direction.West, state))
            {
                Write(travelOptions.CurrentLocation.ForbiddenTravelExitText(Direction.West, state));
                return;
            }

            if (!travelOptions.West.TravelEnterCondition(Direction.West, state))
            {
                Write(travelOptions.West.ForbiddenTravelEnterText(Direction.West, state));
                return;
            }

            state.PlayerLocation = new Vector2Int(state.PlayerLocation.X - 1, state.PlayerLocation.Y);
            state.Travelling = true;
            Write("You travel [West]");
        }

        private bool IsGo(string input) => IsOneOf(input, new[] { "go", "travel" });

        private bool IsWest(string input) => IsOneOf(input, new[] { "west", "left" });
    }
}