using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Actions
{
    public class InventoryAction : Action
    {
        public override bool Condition(string input, GameState state) => IsOneOf(input, new [] { "inventory", "check bag", "check bags" });

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            if (state.Inventory.Items.Any())
            {
                IEnumerable<string> items = state.Inventory.Items.Select(item => $"[{item.ToString()}]");
                Write($"You are holding {string.Join(", ", items)}");
            }
            else
            {
                Write("You are not holding anything");
            }
        }
    }
}