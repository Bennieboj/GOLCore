using System.Collections.Generic;
using System.Linq;
using GoL.TransitionRules;

namespace GoL
{
    public class Neighbourhood
    {
        private List<List<Cell>> _cells;
        private IEnumerable<ITransitionRule> _transitionRules;
        public Neighbourhood(Universe universe, Location location)
        {
            _cells = universe.GetNeighborhoodAroundLocation(location);
            _transitionRules = new List<ITransitionRule> {new OverpopulationRule(), new ReproductionRule(), new StaysAliveRule(), new UnderpopulationRule()};
        }

        public int GetNumberOfLivingNeighbours()
        {
            var allLivingCellsInNeighbourhood = _cells.Sum(row => row.Count(cell => cell == Cell.Alive));

            //we do not want to count the middle cell
            if (_cells[1][1] == Cell.Alive)
            {
                return allLivingCellsInNeighbourhood - 1;
            }
            return allLivingCellsInNeighbourhood;
        }

        public Cell GetTransitionResult()
        {
            int numberOfLivingNeighbours = GetNumberOfLivingNeighbours();
            var middleCell = _cells[1][1];
            var applicableRule = _transitionRules.SingleOrDefault(r => r.IsApplicable(numberOfLivingNeighbours, middleCell));
            if (applicableRule != null)
            {
                return applicableRule.GetTransitionResult(middleCell);
            }
            return middleCell;
        }
    }
}
