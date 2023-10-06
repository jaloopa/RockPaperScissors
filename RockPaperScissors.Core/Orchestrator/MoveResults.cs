using RockPaperScissors.Core.GameRules;

namespace RockPaperScissors.Core.Orchestrator
{
    public record MoveResults (MoveType player1, MoveType player2, MoveOutcome outcome);
}