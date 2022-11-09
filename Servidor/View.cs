namespace Servidor;

public class View {
  private InputHandler _inputHandler;

  public View() {
    _inputHandler = new InputHandler();
  }

  public void PrintRoundStart(int round, Player player) {
    PrintSeparatorWithLineBreak();
    Console.WriteLine($"Round {round} has started!");
    Console.WriteLine($"{player} is dealing the cards...");
  }
  public void PrintRoundEnd(Player player) {
    PrintSeparatorWithLineBreak();
    Console.WriteLine("The round has ended!");
    Console.WriteLine($"{player} claims the cards left on the table.");
  }
  public void PrintRoundResults(List<Player> players) {
    PrintCardsClaimedRound(players);
    PrintActualScore(players);
    PrintSeparator();
  }
  public void PrintCardsClaimedRound(List<Player> players) {
    PrintSeparator();
    Console.WriteLine("Cards claimed this round:");
    for(int i = 0; i < players.Count; i++) {
      Console.WriteLine($"{players[i]}: {players[i].ToStringCardsClaimedRound()}");
    }
  }
  public void PrintActualScore(List<Player> players) {
    PrintSeparator();
    Console.WriteLine("Points up to this round:");
    for(int i = 0; i < players.Count; i++) {
      Console.WriteLine($"{players[i]}: {players[i].GetPoints()}");
    }
  }

  public int PrintBeginTurn(Player player, CardsOnTableCenter cardsOnTableCenter) {
    PrintSeparatorWithLineBreak();
    Console.WriteLine($"{player}'s turn!");
    Console.WriteLine(cardsOnTableCenter);
    Console.WriteLine(player.GetHand());
    int choice = PrintChoseCard(player);
    return choice;
  }
  public int PrintChoseCard(Player player) {
    int HandCardsCount = player.CountHandCards();
    Console.WriteLine("What card do you wish to play?");
    Console.WriteLine($"(Chose a card between 0 and {HandCardsCount - 1})");
    int choice = _inputHandler.HandleInput(HandCardsCount);
    return choice;
  }
  public int PrintChoseValidSubset(List<List<Card>> subsetsThatAddUpTo15) {
    int validSubsetsCount = subsetsThatAddUpTo15.Count;
    Console.WriteLine($"\nThere are {validSubsetsCount} valid card subsets:");
    PrintValidSubsets(subsetsThatAddUpTo15);
    Console.WriteLine("What subset of cards do pick?");
    Console.WriteLine($"(Chose a subset between 0 and {validSubsetsCount - 1})");
    int choice = _inputHandler.HandleInput(validSubsetsCount);
    return choice;
  }
  public void PrintValidSubsets(List<List<Card>> subsetsThatAddUpTo15) {
    for(int i = 0; i < subsetsThatAddUpTo15.Count; i++) {
      Console.WriteLine($"{i}. {CardsCollection.ConvertCardsToDisplayFormat(subsetsThatAddUpTo15[i])}");
    }
  }
  public void PrintCardsClaimed(Point point, List<Card> cards) {
    if (!(point == Point.Zero)) {
      PrintEscoba();
    }
    Console.WriteLine($"You've claimed the following cards: {CardsCollection.ConvertCardsToDisplayFormat(cards)}");
  }

  public void PrintGameStart(Player player) {
    PrintSeparatorWithLineBreak();
    Console.WriteLine($"Welcome to Escoba! Let's begin!");
    PrintSeparator();
  }
  public void PrintGameResults(GameOutcome gameOutcome) {
    if (gameOutcome == GameOutcome.Player0Won) {
      Console.WriteLine("Player 0 won!");
    } else if (gameOutcome == GameOutcome.Player1Won) {
      Console.WriteLine("Player 1 won!");
    } else {
      Console.WriteLine("It's a tie!");
    }
    Console.WriteLine("Thanks for playing! Until next time");
  }

  public void PrintSevenOfGoldPoint(Player player) {
    Console.WriteLine($"{player} get's a point for having the Seven of gold");
  }
  public void PrintMostSevensPoint(Player player) {
    Console.WriteLine($"{player} get's a point for having the most Sevens");
  }
  public void PrintMostCardsPoint(Player player) {
    Console.WriteLine($"{player} get's a point for having the most cards");
  }
  public void PrintMostGoldPoint(Player player) {
    Console.WriteLine($"{player} get's a point for having the most gold");
  }

  public void PrintEscoba() {
    Console.WriteLine($"Escoba! *********************************************************************"); 
  }
  public void PrintNoCardsClaimed() {
    Console.WriteLine("You didn't claim any cards this round. Better luck next time!");
  }
  public void PrintEscobasClaimedAtDeal() {
    Console.WriteLine("This must be your lucky day!");
  }

  public void PrintSeparator() {
    Console.WriteLine($"-----------------------------------------------------------------------------");
  }
  public void PrintSeparatorWithLineBreak() {
    Console.WriteLine($"\n-----------------------------------------------------------------------------");
  }
  
  public static void PrintInputError() {
    Console.WriteLine("Invalid input. Please try again.");
  }
}
