namespace ConsoleApp1.Actions
{
    public class GoSouthAction : Action
    {
        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            return parts.Length >= 2 && IsGo(parts[0]) && IsSouth(parts[1]);
        }

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (travelOptions.South == null)
            {
                Write("You cannot travel [South] from here.");
                return;
            }

            if (!travelOptions.CurrentLocation.TravelExitCondition(Direction.South, state))
            {
                Write(travelOptions.CurrentLocation.ForbiddenTravelExitText(Direction.South, state));
                return;
            }

            if (!travelOptions.South.TravelEnterCondition(Direction.South, state))
            {
                Write(travelOptions.South.ForbiddenTravelEnterText(Direction.South, state));
                return;
            }

            state.PlayerLocation = new Vector2Int(state.PlayerLocation.X, state.PlayerLocation.Y + 1);
            state.Travelling = true;
            Write("You travel [South]");
        }

        

        private bool IsGo(string input) => IsOneOf(input, new[] { "go", "travel" });

        private bool IsSouth(string input) => IsOneOf(input, new[] { "south", "backward", "backwards" });
    }
}