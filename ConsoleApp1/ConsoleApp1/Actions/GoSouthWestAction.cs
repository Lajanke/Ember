namespace ConsoleApp1.Actions
{
    public class GoSouthWestAction : Action
    {
        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            
            if (parts.Length == 2 && IsGo(parts[0]) && IsSouthWest(parts[1]))
            { 
                return true; 
            }

            return parts.Length >= 3 && IsGo(parts[0]) && IsSouth(parts[1]) && IsWest(parts[2]);
        }

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (travelOptions.SouthWest == null)
            {
                Write("You cannot travel [SouthWest] from here.");
                return;
            }

            if (!travelOptions.CurrentLocation.TravelExitCondition(Direction.SouthWest, state))
            {
                Write(travelOptions.CurrentLocation.ForbiddenTravelExitText(Direction.SouthWest, state));
                return;
            }


            if (!travelOptions.SouthWest.TravelEnterCondition(Direction.SouthWest, state))
            {
                Write(travelOptions.SouthWest.ForbiddenTravelEnterText(Direction.SouthWest, state));
                return;
            }

            state.PlayerLocation = new Vector2Int(state.PlayerLocation.X - 1, state.PlayerLocation.Y + 1);
            state.Travelling = true;
            Write("You travel [SouthWest]");
        }

        private bool IsGo(string input) => IsOneOf(input, new [] { "go", "travel" });

        private bool IsSouth(string input) => IsOneOf(input, new[] { "south" });

        private bool IsSouthWest(string input) => IsOneOf(input, new[] { "southwest", "south-west" });

        private bool IsWest(string input) => IsOneOf(input, new[] { "west" });
    }
}