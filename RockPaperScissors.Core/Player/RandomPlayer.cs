using RockPaperScissors.Core.GameRules;

namespace RockPaperScissors.Core.Player
{
    public class RandomPlayer : IPlayer
    {
        private readonly Random _random = new();
        public InputType InputRequired => InputType.None;

        public MoveType TakeTurn(InputPrompt prompt)
        {
            if (prompt is null)
            {
                throw new ArgumentNullException(nameof(prompt));
            }

            if (prompt.AllowedMoves is null)
            {
                throw new ArgumentException("No valid moves found", nameof(prompt));
            }

            return prompt.AllowedMoves[_random.Next(prompt.AllowedMoves.Count)];
        }
    }
}
