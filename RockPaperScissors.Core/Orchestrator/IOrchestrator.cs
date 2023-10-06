using RockPaperScissors.Core.GameRules;

namespace RockPaperScissors.Core.Orchestrator
{
    public interface IOrchestrator
    {
        MoveResults PlayTurn(InputPrompt player1, InputPrompt Player2);
        (InputType player1, InputType player2) InputRequired();
        IList<MoveType> AllowedMoves { get; }
    }
}
