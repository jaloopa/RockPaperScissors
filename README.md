# RockPaperScissors

## About
This is a simple implementation of the game Rock, Paper, Scissors, with two rulesets and multiple computer strategies.

### Rulesets
There are two rulesets implemented
* Rock, Paper, Scissors
    * Rock beats Scissors
    * Paper beats Rock
    * Scissors beats Paper
* Rock, Paper, Scissors, Lizard, Spock, inspired by the Big Bang Theory
    * Rock beats Scissors and Lizard
    * Paper beats Rock and Spock
    * Scissors beats Paper and Lizard
    * Lizard beats Paper and Spock
    * Spock beats Rock and Scissors

### Computer Strategies
* Random: the computer chooses randomly from the available moves
* Last turn: the computer copies the last move made by its opponent

The game can be set to run player vs player, player vs computer or computer vs computer, and with a choice of rule set. In the initial release this requires a code change to set the hard coded inputs in the `RockPaperScissors.Cli\Program.cs` file. In a future version there will be the ability to set this via config file or prompting when setting up the game

## Game instructions
For a human player, gameplay consists of choosing a move, then choosing whether to play again. Move inputs are case sensitive and must be one of Rock, Paper, Scissors or, if available, Lizard or Spock. To play another round, enter Y or y when prompted

## Future plans
Upcoming versions will allow:
* Setting the game type and players by config or prompt
* Additional computer strategies
* Score tracking and best of N games for an overall winner
* Graphical and/or web based versions