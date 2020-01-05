using System;
using System.Linq;

namespace ConsoleApp1.Actions
{
    public class FixBoatAction : Action
    {
        public override bool Condition(string input, GameState state)
        {
            string[] parts = input?.Split(" ");
            return parts.Length >= 2 && IsUse(parts[0]) && IsItem(parts[1]) && HasItem(state, parts[1]);
        }

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (state.BoatFixed)
            {
                Write("The boat is already fixed");
            }
            else if (!HasHammer(state) || !HasNails(state) || !HasWood(state))
            {
                Write("You need [Wood], [Nails] and [Hammer] to do that");
            }
            else
            {
                state.BoatFixed = true;
                Write("You fix the boat, you are amazing.");
            }
        }

        private bool IsUse(string input) => IsOneOf(input, new[] { "use", "wield", "consume" });

        private bool IsItem(string input) => IsOneOf(input, ItemNames);

        private string[] ItemNames => new[] { InventoryItem.Hammer, InventoryItem.Nails, InventoryItem.Wood }.Select(i => i.ToString().ToLower()).ToArray();

        private bool HasHammer(GameState state) => state.Inventory.HasItem(InventoryItem.Hammer);

        private bool HasNails(GameState state) => state.Inventory.HasItem(InventoryItem.Nails);

        private bool HasWood(GameState state) => state.Inventory.HasItem(InventoryItem.Wood);

        private bool HasItem(GameState state, string input) => Enum.TryParse(typeof(InventoryItem), input, true, out var item) && state.Inventory.HasItem((InventoryItem)item);
    }
}