using RockPaperScissors.Core.GameRules;

namespace RockPaperScissors.Core.Player
{
    public class LastTurnPlayer : IPlayer
    {
        private readonly Random _random = new();
        public InputType InputRequired => InputType.LastPlayed;

        public MoveType TakeTurn(InputPrompt prompt)
        {
            if (prompt is null)
            {
                throw new ArgumentNullException(nameof(prompt));
            }

            if (prompt.AllowedMoves is null || (prompt.ProvidedMove != null &&!prompt.AllowedMoves.Contains(prompt.ProvidedMove.Value)))
            {
                throw new ArgumentException("Provided prompt is not allowed", nameof(prompt));
            }

            if (prompt.ProvidedMove is null)
            {
                //No last move provided so choose randomly
                return prompt.AllowedMoves[_random.Next(prompt.AllowedMoves.Count)];
            }

            return prompt.ProvidedMove.Value;
        }
    }
}
