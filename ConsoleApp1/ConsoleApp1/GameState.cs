using System;

namespace ConsoleApp1
{
    public class GameState
    {
        public GameState()
        {
            Random random = new Random();

            int randomX = random.Next(0, 3);
            int randomY = random.Next(0, 3);

            CatLocation = new Vector2Int(randomX, randomY);
        }

        public Inventory Inventory { get; set; } = new Inventory();

        public Vector2Int PlayerLocation { get; set; } = new Vector2Int(0, 0);

        public Vector2Int CatLocation { get; set; } = new Vector2Int(0, 0); 

        public bool Travelling { get; set; }

        public bool BoatFixed { get; set; }

        public bool GameWon { get; set; }

        public bool Died { get; set; }
    }
}