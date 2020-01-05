namespace ConsoleApp1
{
    public class GameState
    {
        public Inventory Inventory { get; set; } = new Inventory();

        public Vector2Int PlayerLocation { get; set; } = new Vector2Int(0, 0);

        public bool Travelling { get; set; }

        public bool BoatFixed { get; set; }

        public bool GameWon { get; set; }

        public bool Died { get; set; }
    }
}