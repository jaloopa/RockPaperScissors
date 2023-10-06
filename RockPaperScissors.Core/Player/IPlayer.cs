using RockPaperScissors.Core.GameRules;

namespace RockPaperScissors.Core.Player
{
    public interface IPlayer
    {
        MoveType TakeTurn(InputPrompt prompt);
        InputType InputRequired { get; }
    }
}
