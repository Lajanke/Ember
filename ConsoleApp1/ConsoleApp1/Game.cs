using ConsoleApp1.Tiles;
using System;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    public class Game
    {
        GameState _state = new GameState();
        Tile[,] _tiles = new Tile[10,10];

        public void Start()
        {
            ResetGame();
            NextTurn();
        }

        private void NextTurn()
        {
            Tile tile = _tiles[_state.PlayerLocation.X, _state.PlayerLocation.Y];
            TravelOptions travelOptions = new TravelOptions(_tiles, _state.PlayerLocation);
            tile.Turn(_state, travelOptions);
            CatTravel(travelOptions);

            if (_state.GameWon)
            {
                GameWon();
            }
            else if (_state.Died)
            {
                Died();
            }
            else
            {
                NextTurn();
            }
        }

        private void ResetGame()
        {
            Console.Clear();
            _state = new GameState();
            _tiles = new Tile[10, 10];

            Type tileType = typeof(Tile);
            Assembly tilesAssembly = tileType.Assembly;
            var tileTypes = tilesAssembly.GetTypes().Where(t => tileType.IsAssignableFrom(t) && t != tileType);

            foreach (var type in tileTypes)
            {
                Tile tile = (Tile)Activator.CreateInstance(type);
                _tiles[tile.Location.X, tile.Location.Y] = tile;
            }
        }

        private void CatTravel(TravelOptions travelOptions)
        {
            Random random = new Random();

            Direction randomCatDirection = (Direction)random.Next(0, 8);

            switch (randomCatDirection)
            {
                case Direction.North:
                    if (travelOptions.North != null)
                    {
                        _state.CatLocation = travelOptions.North.Location;
                    }
                    break;

                case Direction.East:
                    if (travelOptions.East != null)
                    {
                        _state.CatLocation = travelOptions.East.Location;
                    }
                    break;

                case Direction.South:
                    if (travelOptions.South != null)
                    {
                        _state.CatLocation = travelOptions.South.Location;
                    }
                    break;

                case Direction.West:
                    if (travelOptions.West != null)
                    {
                        _state.CatLocation = travelOptions.West.Location;
                    }
                    break;
               
                case Direction.NorthEast:
                    if (travelOptions.NorthEast != null)
                    {
                        _state.CatLocation = travelOptions.NorthEast.Location;
                    }
                    break;

                case Direction.SouthEast:
                    if (travelOptions.SouthEast != null)
                    {
                        _state.CatLocation = travelOptions.SouthEast.Location;
                    }
                    break;

                case Direction.SouthWest:
                    if (travelOptions.SouthWest != null)
                    {
                        _state.CatLocation = travelOptions.SouthWest.Location;
                    }
                    break;

                case Direction.NorthWest:
                    if (travelOptions.NorthWest != null)
                    {
                        _state.CatLocation = travelOptions.NorthWest.Location;
                    }
                    break;
            }
        }

        private void GameWon()
        {
            Console.WriteLine("You have won the game!");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private void Died()
        {
            Console.WriteLine("You are dead.");
            Console.WriteLine("Press any key to restart");
            Console.ReadKey();

            Start();
        }
    }
}