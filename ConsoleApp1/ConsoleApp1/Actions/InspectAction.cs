using System.Collections.Generic;
using System;

namespace ConsoleApp1.Actions
{
    public class InspectAction : Action
    {
        public override bool Condition(string input, GameState state) => ContainsOneOf(input, new[] { "inspect" });

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            Write(InspectText(state, travelOptions, input));
        }

        private string InspectText(GameState state, TravelOptions travelOptions, string input)
        {
            foreach(InventoryItem item in state.Inventory.Items)
            {
                if (input.Contains(item.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return $"You inspect the {item} and lose your mind";
                }
            }

            return "There is nothing of interest";   
        }
    }
}