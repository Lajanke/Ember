using ConsoleApp1.Tiles;

namespace ConsoleApp1
{
    public class TravelOptions
    {
        public Tile North { get; set; }
        public Tile East { get; set; }
        public Tile South { get; set; }
        public Tile West { get; set; }
        public Tile NorthEast { get; set; }
        public Tile SouthEast { get; set; }
        public Tile NorthWest { get; set; }
        public Tile SouthWest { get; set; }
        public Tile CurrentLocation { get; set; }


        public TravelOptions(Tile[,] tiles, Vector2Int location)
        {
            North = FindTile(tiles, new Vector2Int(location.X, location.Y - 1));
            East = FindTile(tiles, new Vector2Int(location.X + 1, location.Y));
            South = FindTile(tiles, new Vector2Int(location.X, location.Y + 1));
            West = FindTile(tiles, new Vector2Int(location.X - 1, location.Y));
            NorthEast = FindTile(tiles, new Vector2Int(location.X + 1, location.Y - 1));
            SouthWest = FindTile(tiles, new Vector2Int(location.X - 1, location.Y + 1));
            NorthWest = FindTile(tiles, new Vector2Int(location.X - 1, location.Y - 1));
            SouthEast = FindTile(tiles, new Vector2Int(location.X + 1, location.Y + 1));
            CurrentLocation = FindTile(tiles, location);
        }

        private Tile FindTile(Tile[,] tiles, Vector2Int position)
        {
            bool positionExists = position.X >= 0 && position.X < tiles.GetLength(0)
                && position.Y >= 0 && position.Y < tiles.GetLength(1);

            return positionExists ? tiles[position.X, position.Y] : null;
        }
    }
}