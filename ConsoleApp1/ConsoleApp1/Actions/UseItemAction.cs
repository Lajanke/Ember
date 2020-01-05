namespace ConsoleApp1.Actions
{
    public abstract class UseItemAction : Action
    {
        InventoryItem _item;

        protected UseItemAction(InventoryItem item)
        {
            _item = item;
        }

        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            return parts.Length >= 2 && IsUse(parts[0]) && IsItem(parts[1]) && HasItem(state);
        }

        public abstract override void Run(string input, GameState state, TravelOptions travelOptions);

        private bool IsUse(string input) => IsOneOf(input, new[] { "use", "wield", "consume" });

        private bool IsItem(string input) => _item.ToString().ToLower() == input;

        private bool HasItem(GameState state) => state.Inventory.Items.Contains(_item);
    }
}