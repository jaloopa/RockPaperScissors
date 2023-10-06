namespace RockPaperScissors.Core.GameRules
{
    public record InputPrompt
    {
        public MoveType? ProvidedMove { get; set; }
        public IList<MoveType>? AllowedMoves { get; set; }
    }
}
