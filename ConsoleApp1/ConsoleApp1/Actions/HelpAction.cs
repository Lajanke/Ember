namespace ConsoleApp1.Actions
{
    public class HelpAction : Action
    {
        public override bool Condition(string input, GameState state) => input == "help";

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            Write(
                "Use the following commands to interact with the game",
                "[Search] - Look around your current location. E.g. (search)",
                "[Go] - Travel to a new location. E.g. (go west)",
                "[Get] - Pick up an item. E.g. (get thing)",
                "[Use] - Use an item. E.g. (use thing)",
                "[Inspect] - Inspect something specific in your current location. E.g. (inspect thing)",
                "[Inventory] - Check the items in your inventory. E.g. (inventory)"
            );
        }
    }
}