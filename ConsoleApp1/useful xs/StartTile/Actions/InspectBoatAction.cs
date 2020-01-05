namespace ConsoleApp1.Actions
{
    public class InspectBoatAction : Action
    {
        public override bool Condition(string input, GameState state) => input == "inspect boat";

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (state.BoatFixed)
            {
                Write("The boat is now fixed");
            }
            else
            {
                Write("There is a hole in the boat, it will not float.");
            }
        }
    }
}