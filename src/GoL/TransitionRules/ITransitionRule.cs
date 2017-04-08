namespace GoL.TransitionRules
{
    public interface ITransitionRule
    {
        bool IsApplicable(int amountOfLivingNeighbours, Cell currentCellState);
        Cell GetTransitionResult(Cell currentCellState);
    }
}