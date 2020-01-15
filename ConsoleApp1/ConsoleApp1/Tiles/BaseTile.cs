using ConsoleApp1.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Tiles
{
    public abstract class Tile
    {
        public abstract Vector2Int Location { get; }

        public abstract string Name { get; }

        public virtual string TravelName { get { return Name; } }

        public List<Actions.Action> Actions { get; private set; } = new List<Actions.Action> {
            // Diagonals go first as they have more parts.
            new GoNorthEastAction(),
            new GoNorthWestAction(),
            new GoSouthEastAction(),
            new GoSouthWestAction(),
            new HelpAction(),
            new InventoryAction(),
            new SearchAction(),
            new GoNorthAction(),
            new GoEastAction(),
            new GoSouthAction(),
            new GoWestAction(),

        };

        public virtual void Turn(GameState state, TravelOptions travelOptions)
        {
            TurnText(state, travelOptions);
            if (!state.Died && !state.GameWon)
            {
                PlayerAction(state, travelOptions);
            }
        }

        public virtual bool TravelEnterCondition(Direction direction, GameState state)
        {
            return true;
        }

        public virtual bool TravelExitCondition(Direction direction, GameState state)
        {
            return true;
        }

        public virtual string ForbiddenTravelEnterText(Direction direction, GameState state)
        {
            return $"You cannot travel to the {Name} from the [{OppositeDirection(direction).ToString()}]";
        }

        public virtual string ForbiddenTravelExitText(Direction direction, GameState state)
        {
            return $"You cannot leave the {Name} from the [{direction.ToString()}]";
        }

        protected void Write(params string[] lines)
        {
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        protected string Read()
        {
            var input = Console.ReadLine()?.ToLower();
            Console.Clear();
            return input;
        }

        protected void PlayerAction(GameState state, TravelOptions travelOptions)
        {
            ResetFlags(state);
            string input = Read();
            bool actionTaken = false;

            foreach (Actions.Action action in Actions)
            {
                if (action.Condition(input, state))
                {
                    action.Run(input, state, travelOptions);
                    actionTaken = true;
                    break;
                }
            }

            if (!actionTaken)
            {
                Write("Invalid action", $"Could not undertand ({input})");
            }
        }

        protected virtual void TurnText(GameState state, TravelOptions travelOptions)
        {
            StringBuilder builder = new StringBuilder();

            if (state.Travelling)
            {
                builder.Append($"You arrive at the {Name}.");
            }
            else
            {
                builder.Append($"You are at the {Name}.");
            }

            builder.Append(TravelText(travelOptions));

            builder.Append(CatText(state));

            Write(builder.ToString());
        }

        protected string CatText(GameState state)
        {
            if (state.PlayerLocation.Equals(state.CatLocation))
            {
                Random random = new Random();

                int randomNumber = random.Next(0, 5);

                switch (randomNumber)
                {
                    case 0: return " A cat is sitting idly by, staring at you.";
                    case 1: return " A cat is licking it's ass, staring at you.";
                    case 2: return " A cat is languishing, staring at you.";
                    case 3: return " A cat is sleeping nearby, staring at you.";
                    case 4: return " A cat is taking a dump, staring at you.";
                }           
            }
            return null;
        }

        protected string TravelText(TravelOptions travelOptions)
        {
            StringBuilder builder = new StringBuilder();

            if (travelOptions.North != null)
                builder.Append($" To the [North] {travelOptions.North.TravelName}.");
            if (travelOptions.NorthEast != null)
                builder.Append($" To the [NorthEast] {travelOptions.NorthEast.TravelName}.");
            if (travelOptions.East != null)
                builder.Append($" To the [East] {travelOptions.East.TravelName}.");
            if (travelOptions.SouthEast != null)
                builder.Append($" To the [SouthEast] {travelOptions.SouthEast.TravelName}.");
            if (travelOptions.South != null)
                builder.Append($" To the [South] {travelOptions.South.TravelName}.");
            if (travelOptions.SouthWest != null)
                builder.Append($" To the [SouthWest] {travelOptions.SouthWest.TravelName}.");
            if (travelOptions.West != null)
                builder.Append($" To the [West] {travelOptions.West.TravelName}.");
            if (travelOptions.NorthWest != null)
                builder.Append($" To the [NorthWest] {travelOptions.NorthWest.TravelName}.");

            return builder.ToString();
        }

        protected void SetSearchAction(SearchAction action)
        {
            int index = Actions.FindIndex(a => a.GetType() == typeof(SearchAction));
            Actions[index] = action;
        }

        private void ResetFlags(GameState state)
        {
            state.Travelling = false;
        }

        private Direction OppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.North: return Direction.South;
                case Direction.NorthEast: return Direction.SouthWest;
                case Direction.East: return Direction.West;
                case Direction.SouthEast: return Direction.NorthWest;
                case Direction.South: return Direction.North;
                case Direction.SouthWest: return Direction.NorthEast;
                case Direction.West: return Direction.East;
                case Direction.NorthWest: return Direction.SouthEast;
                default: throw new ArgumentException("Invalid direction", nameof(direction));
            }
        }
    }
}