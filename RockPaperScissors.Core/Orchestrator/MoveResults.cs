using RockPaperScissors.Core.GameRules;

namespace RockPaperScissors.Core.Orchestrator
{
    public record MoveResults(MoveType Player1, MoveType Player2, MoveOutcome Outcome);
}