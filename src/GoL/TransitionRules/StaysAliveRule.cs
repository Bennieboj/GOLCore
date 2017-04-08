using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoL.TransitionRules
{
    public class StaysAliveRule : ITransitionRule
    {
        public bool IsApplicable(int amountOfLivingNeighbours, Cell currentCellState)
        {
            return (amountOfLivingNeighbours == 2 || amountOfLivingNeighbours == 3) && currentCellState == Cell.Alive;
        }

        public Cell GetTransitionResult(Cell currentCellState)
        {
            return currentCellState;
        }
    }
}
