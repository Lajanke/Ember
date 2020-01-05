namespace ConsoleApp1.Actions
{
    public class PickUpItemAction : Action
    {
        public InventoryItem Item { get; private set; }

        public PickUpItemAction(InventoryItem item)
        {
            Item = item;
        }

        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            return parts.Length >= 2 && IsPickUp(parts[0]) && IsItem(parts[1]) && !HasItem(state);
        }

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            state.Inventory.Items.Add(Item);
            Write($"You pick up the {Item.ToString()}");
        }

        private bool IsPickUp(string input) => IsOneOf(input, new[] { "pickup", "pick-up", "get" });

        private bool IsItem(string input) => Item.ToString().ToLower() == input;

        private bool HasItem(GameState state) => state.Inventory.Items.Contains(Item);
    }
}