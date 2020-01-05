namespace ConsoleApp1.Actions
{
    public class SearchAction : Action
    {
        public override bool Condition(string input, GameState state) => IsOneOf(input, new[] { "search", "search-around", "look", "look-around" });

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            Write(SearchText(state));
        }

        public virtual string SearchText(GameState state)
        {
            return "You search around but find nothing of interest";
        }
    }
}