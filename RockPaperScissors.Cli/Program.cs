using RockPaperScissors.Core.GameRules;
using RockPaperScissors.Core.Orchestrator;
using RockPaperScissors.Core.Player;

//TODO: implement DI here, either config or prompt user
//IOrchestrator orchestrator = new Orchestrator(new HumanPlayer(), new RandomPlayer(), new RockPaperScissorsRuleSet());
//IOrchestrator orchestrator = new Orchestrator(new HumanPlayer(), new LastTurnPlayer(), new RockPaperScissorsRuleSet());
IOrchestrator orchestrator = new Orchestrator(new HumanPlayer(), new RandomPlayer(), new RockPaperScissorsLizardSpockRuleSet());

Dictionary<MoveOutcome, string> ResultFormats = new()
{
    { MoveOutcome.Player1, "Player 1 wins!" },
    { MoveOutcome.Player2, "Player 2 wins!" },
    { MoveOutcome.Draw, "the round was a draw" }
};

Console.WriteLine("Do you want to play a game?");

var continuePlaying = true;
MoveResults? turnResult = null;

while (continuePlaying)
{
    (var player1, var player2) = orchestrator.InputRequired();
    var player1Input = GetInput(player1, orchestrator, turnResult?.Player2);
    var player2Input = GetInput(player2, orchestrator, turnResult?.Player1);

    var player1Prompt = new InputPrompt { ProvidedMove = player1Input };
    var player2Prompt = new InputPrompt { ProvidedMove = player2Input };

    turnResult = orchestrator.PlayTurn(player1Prompt, player2Prompt);
    Console.WriteLine($"Player 1 chose {turnResult.Player1}");
    Console.WriteLine($"Player 2 chose {turnResult.Player2}");
    Console.WriteLine($"Result: {ResultFormats[turnResult.Outcome]}");

    Console.WriteLine("Play again? Y/N");
    var answer = Console.ReadLine();
    continuePlaying = (answer == "Y" || answer == "y");
    //TODO: add score tracking and best of n games before announcing a final winner
}

static MoveType? GetInput(InputType input, IOrchestrator orchestrator, MoveType? LastMove)
{
    switch (input)
    {
        case InputType.None:
            return null;
        case InputType.PlayerInput:
            while (true)
            {
                Console.WriteLine("Enter move:");
                var move = Console.ReadLine();
                if (Enum.TryParse<MoveType>(move, out var parsed) && orchestrator.AllowedMoves.Contains(parsed))
                {
                    return parsed;
                }
                else
                {
                    Console.WriteLine("Not a valid move. Try again");
                }
            }
        case InputType.LastPlayed:
            return LastMove;
        default:
            throw new Exception("Inrecognised input type");
    }
}