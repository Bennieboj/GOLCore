using System.Collections.Generic;

namespace GoL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var universe = new Universe(new List<List<Cell>>
            {
                new List<Cell> { Cell.Alive, Cell.Dead,  Cell.Dead,  Cell.Dead },
                new List<Cell> { Cell.Dead,  Cell.Alive, Cell.Dead,  Cell.Dead },
                new List<Cell> { Cell.Dead,  Cell.Alive, Cell.Alive, Cell.Dead },
                new List<Cell> { Cell.Dead,  Cell.Dead,  Cell.Dead,  Cell.Dead }
            });
            var nextGeneration = universe.DetermineNextGeneration();
        }
    }
}
