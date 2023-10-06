namespace RockPaperScissors.Core.GameRules
{
    public class RulesetException: Exception
    {
        public RulesetException(string message): base(message) { }
    }
}
