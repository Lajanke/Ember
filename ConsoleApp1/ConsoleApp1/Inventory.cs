using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Inventory
    {
        public List<InventoryItem> Items = new List<InventoryItem>();

        public bool HasItem(InventoryItem item) => Items.Contains(item);
    }
}