namespace RockPaperScissors.Core.GameRules
{
    public interface IRuleSet
    {
        IList<MoveType> AllowedMoves { get; }
        MoveOutcome TurnResult(MoveType player1, MoveType player2);
    }
}
