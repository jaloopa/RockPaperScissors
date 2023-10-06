namespace RockPaperScissors.Core.GameRules
{
    public class RockPaperScissorsRuleSet : IRuleSet
    {
        private readonly Dictionary<MoveType, MoveType> MovesThatBeat = new()
        {
            {MoveType.Rock, MoveType.Paper},
            {MoveType.Paper, MoveType.Scissors },
            {MoveType.Scissors, MoveType.Rock }
        };

        private readonly Dictionary<MoveType, MoveType> MovesThatLose = new()
        {
            {MoveType.Rock, MoveType.Scissors },
            {MoveType.Paper, MoveType.Rock },
            {MoveType.Scissors, MoveType.Paper }
        };
        
        public IList<MoveType> AllowedMoves => new[] { MoveType.Rock, MoveType.Paper, MoveType.Scissors };

        public MoveOutcome TurnResult(MoveType player1, MoveType player2)
        {
            if (!AllowedMoves.Contains(player1)) throw new RulesetException("Invalid option for player 1");
            if (!AllowedMoves.Contains(player2)) throw new RulesetException("Invalid option for player 2");

            if (MovesThatBeat[player1] == player2) return MoveOutcome.Player2;
            if (MovesThatLose[player1] == player2) return MoveOutcome.Player1;
            return MoveOutcome.Draw;
        }
    }
}
