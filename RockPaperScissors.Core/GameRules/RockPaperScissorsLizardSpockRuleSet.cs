namespace RockPaperScissors.Core.GameRules
{
    public class RockPaperScissorsLizardSpockRuleSet : IRuleSet
    {
        public IList<MoveType> AllowedMoves => new[] { MoveType.Rock, MoveType.Paper, MoveType.Scissors, MoveType.Lizard, MoveType.Spock };

        private readonly Dictionary<MoveType, IEnumerable<MoveType>> MovesThatBeat = new()
        {
            {MoveType.Rock, new[]{MoveType.Paper, MoveType.Spock } },
            {MoveType.Paper, new[]{MoveType.Scissors, MoveType.Lizard } },
            {MoveType.Scissors, new[]{MoveType.Rock, MoveType.Spock } },
            {MoveType.Lizard, new[]{MoveType.Rock, MoveType.Scissors } },
            {MoveType.Spock, new[]{MoveType.Paper, MoveType.Lizard} }
        };

        private readonly Dictionary<MoveType, IEnumerable<MoveType>> MovesThatLose = new()
        {
            {MoveType.Rock, new[]{MoveType.Scissors, MoveType.Lizard } },
            {MoveType.Paper, new[]{MoveType.Rock, MoveType.Spock } },
            {MoveType.Scissors, new[]{MoveType.Paper, MoveType.Lizard } },
            {MoveType.Lizard, new[]{ MoveType.Paper, MoveType.Spock } },
            {MoveType.Spock, new[]{ MoveType.Rock, MoveType.Scissors} }
        };

        public MoveOutcome TurnResult(MoveType player1, MoveType player2)
        {
            if (!AllowedMoves.Contains(player1)) throw new RulesetException("Invalid option for player 1");
            if (!AllowedMoves.Contains(player2)) throw new RulesetException("Invalid option for player 2");

            if (MovesThatBeat[player1].Contains(player2)) return MoveOutcome.Player2;
            if (MovesThatLose[player1].Contains(player2)) return MoveOutcome.Player1;
            return MoveOutcome.Draw;
        }
    }
}
