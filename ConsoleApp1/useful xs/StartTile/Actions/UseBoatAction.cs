namespace ConsoleApp1.Actions
{
    public class UseBoatAction : Action
    {
        public override bool Condition(string input, GameState state) => input == "use boat";

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (state.BoatFixed)
            {
                Write("You're now a pirate and you have escaped!");
                state.GameWon = true;
            }
            else
            {
                Write("The boat has a hole, you sink and die");
                state.Died = true;
            }
        }
    }
}