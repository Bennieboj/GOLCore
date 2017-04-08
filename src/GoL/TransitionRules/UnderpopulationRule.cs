using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoL.TransitionRules
{
    public class UnderpopulationRule : ITransitionRule
    {
        public bool IsApplicable(int amountOfLivingNeighbours, Cell currentCellState)
        {
            return amountOfLivingNeighbours < 2 && currentCellState == Cell.Alive;
        }

        public Cell GetTransitionResult(Cell currentCellState)
        {
            return Cell.Dead;
        }
    }
}
