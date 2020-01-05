namespace ConsoleApp1.Actions
{
    public class GoEastAction : Action
    {
        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            return parts.Length >= 2 && IsGo(parts[0]) && IsEast(parts[1]);
        }

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (travelOptions.East == null)
            {
                Write("You cannot travel [East] from here.");
                return;
            }

            if (!travelOptions.CurrentLocation.TravelExitCondition(Direction.East, state))
            {
                Write(travelOptions.CurrentLocation.ForbiddenTravelExitText(Direction.East, state));
                return;
            }

            if (!travelOptions.East.TravelEnterCondition(Direction.East, state))
            {
                Write(travelOptions.East.ForbiddenTravelEnterText(Direction.East, state));
                return;
            }

            state.PlayerLocation = new Vector2Int(state.PlayerLocation.X + 1, state.PlayerLocation.Y);
            state.Travelling = true;
            Write("You travel [East]");
        }

        private bool IsGo(string input) => IsOneOf(input, new[] { "go", "travel" });

        private bool IsEast(string input) => IsOneOf(input, new[] { "east", "right" });
    }
}