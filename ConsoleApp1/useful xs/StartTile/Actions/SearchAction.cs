namespace ConsoleApp1.Actions
{
    public class StartTileSearchAction : SearchAction
    {
        public override string SearchText(GameState state)
        {
            if (state.BoatFixed)
            {
                return "The beach is deserted apart from the boat, but it is now fixed so perhaps you should use it.";
            }
            else if (CanFixBoat(state))
            {
                return "The beach is deserted apart from the broken boat, but you now have tools to fix it, perhaps you should try to [Use] them.";
            }
            else
            {
                return "The beach is deserted apart from the broken boat, and you do not have all the tools to fix it.";
            }
        }

        private bool CanFixBoat(GameState state)
        {
            return state.Inventory.HasItem(InventoryItem.Hammer)
                && state.Inventory.HasItem(InventoryItem.Nails)
                && state.Inventory.HasItem(InventoryItem.Wood);
        }
    }
}