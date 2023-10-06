using RockPaperScissors.Core.GameRules;
using RockPaperScissors.Core.Player;

namespace RockPaperScissors.Core.Orchestrator
{
    public class Orchestrator : IOrchestrator
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly IRuleSet _rules;

        public Orchestrator(IPlayer player1, IPlayer player2, IRuleSet rules)
        {
            _player1 = player1 ?? throw new ArgumentNullException(nameof(player1));
            _player2 = player2 ?? throw new ArgumentNullException(nameof(player2));
            _rules = rules ?? throw new ArgumentNullException(nameof(rules));
        }

        public IList<MoveType> AllowedMoves => _rules.AllowedMoves;

        public (InputType player1, InputType player2) InputRequired()
        {
            return (_player1.InputRequired, _player2.InputRequired);
        }

        public MoveResults PlayTurn(InputPrompt player1Prompt, InputPrompt player2Prompt)
        {
            player1Prompt.AllowedMoves = AllowedMoves;
            player2Prompt.AllowedMoves = AllowedMoves;

            var player1Move = _player1.TakeTurn(player1Prompt);
            var player2Move = _player2.TakeTurn(player2Prompt);

            return new MoveResults(player1Move, player2Move, _rules.TurnResult(player1Move, player2Move));
        }
    }
}
