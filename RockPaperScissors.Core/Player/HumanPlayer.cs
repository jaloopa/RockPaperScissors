using RockPaperScissors.Core.GameRules;

namespace RockPaperScissors.Core.Player
{
    public class HumanPlayer : IPlayer
    {
        public InputType InputRequired => InputType.PlayerInput;

        public MoveType TakeTurn(InputPrompt prompt)
        {
            if (prompt is null)
            {
                throw new ArgumentNullException(nameof(prompt));
            }

            if (prompt.ProvidedMove is null)
            {
                throw new ArgumentException("No move provided", nameof(prompt));
            }

            if (prompt.AllowedMoves is null || !prompt.AllowedMoves.Contains(prompt.ProvidedMove.Value)) 
            { 
                throw new ArgumentException("Provided prompt is not allowed", nameof(prompt)); 
            }

            return prompt.ProvidedMove.Value;
        }
    }
}
