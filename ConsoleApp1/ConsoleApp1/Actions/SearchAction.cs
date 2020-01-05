using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Actions
{
    public class SearchAction : Action
    {
        public override bool Condition(string input, GameState state) => IsOneOf(input, new[] { "search", "search-around", "look", "look-around" });

        public override void Run(string input, GameState state, TravelOptions travelOptions)
        {
            Write(SearchText(state, travelOptions));
        }

        public virtual string SearchText(GameState state, TravelOptions travelOptions)
        {
            bool foundItems = false;
            StringBuilder builder = new StringBuilder("You look around and see");
            List<string> items = new List<string>();

            foreach(Action action in travelOptions.CurrentLocation.Actions)
            {
                if (action.GetType() != typeof(PickUpItemAction))
                { 
                    continue; 
                }

                InventoryItem item = ((PickUpItemAction)action).Item;
                if (!state.Inventory.HasItem(item))
                {
                    foundItems = true;
                    items.Add($" the {item.ToString()}");
                }
            }

            builder.Append(string.Join(",", items) + ".");

            return foundItems ? builder.ToString() : "You search around but find nothing of interest";
        }
    }
}