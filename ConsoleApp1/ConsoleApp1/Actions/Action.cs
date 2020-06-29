using System;
using System.Linq;

namespace ConsoleApp1.Actions
{
    public abstract class Action
    {
        public abstract bool Condition(string input, GameState state);

        public abstract void Run(string input, GameState state, TravelOptions travelOptions);

        protected bool IsOneOf(string input, string[] options) => options.Contains(input);

        protected bool ContainsOneOf(string input, string[] options) => options.Any((string option) => input.Contains(option));

        protected void Write(params string[] lines)
        {
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        protected string Read()
        {
            return Console.ReadLine()?.ToLower();
        }
    }
}