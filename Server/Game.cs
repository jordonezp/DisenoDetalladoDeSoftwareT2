namespace Escoba;

// TODO: methods take up to 3 methods

public class Game {
  private int _round;
  private View _view;
  private int _whoDeals;
  private int _whoPlays;
  private List<Player> _players;
  private CardsOnTableCenter _cardsOnTableCenter;

  public Game() {
    _round = 1;
    _whoDeals = 0;
    _whoPlays = 1;
    _view = new View();
    _cardsOnTableCenter = new CardsOnTableCenter();
    _players = new List<Player>() {
      new Player(0),
      new Player(1),
    };
  }

  public void PlayEscoba() {
    _view.PrintGameStart(_players[_whoDeals]);
    while (!HasAnyPlayerWon()) {
      PlayRound();  
      PrepareForNextRound();
    }
    EndGame();
  }

  public bool HasAnyPlayerWon() {
    foreach(Player player in _players) {
      if (player.HasWon()) {
        return true;
      }
    }
    return false;
  }

  public void PlayRound() {
    _view.PrintRoundStart(_round, _players[_whoDeals]);
    Round round = new Round(_whoDeals, _whoPlays, new Deck(), _cardsOnTableCenter, _players);
    _players = round.PlayRound();
  }

  public void PrepareForNextRound() {
    ClearPlayersCardsClaimedLastRound();
    InvertPlayersOrder();
    _round++;
  }
  public void ClearPlayersCardsClaimedLastRound() {
    foreach (Player player in _players) {
      player.ClearCardsClaimedRound();
    }
  }
  public int InvertPlayersOrder() {
    if (_whoDeals == 0) {
      _whoPlays = 0;
      _whoDeals = 1;
    } else {
      _whoDeals = 0;
      _whoPlays = 1;
    }
    return 0;
  }
  
  public void EndGame() {
    _view.PrintGameResults(GetWinner());
  }
  public GameOutcome GetWinner() {
    if (_players[0].GetPoints() > _players[1].GetPoints()) {
      return GameOutcome.Player0Won;
    } else if (_players[0].GetPoints() < _players[1].GetPoints()) {
      return GameOutcome.Player1Won;
    } else {
      return GameOutcome.Tie;
    }
  }

  public static void ClaimSubsets(EscobaEvaluation escobaEvaluation, Player player, CardsOnTableCenter cardsOnTableCenter, List<List<Card>> cardSubsets) {
    AddEscobaPoint(escobaEvaluation, player);
    if (escobaEvaluation == EscobaEvaluation.Double) {
      foreach(List<Card> subset in cardSubsets) {
        ClaimCards(player, escobaEvaluation, cardsOnTableCenter, subset);
      }
    } else {
      ClaimCards(player, escobaEvaluation, cardsOnTableCenter, cardSubsets[0]);
    }
  }
  public static void ClaimCards(Player player, EscobaEvaluation escobaEvaluation, CardsOnTableCenter cardsOnTableCenter, List<Card> cards) {
    View view = new View();
    view.PrintCardsClaimed(escobaEvaluation, cards);
    player.ClaimCards(cards);
    RemoveCards(cardsOnTableCenter, cards);
  }
  public static void AddEscobaPoint(EscobaEvaluation escobaEvaluation, Player player) {
    if (escobaEvaluation == EscobaEvaluation.Double) {
      player.AddPoints(2);
    } else if (escobaEvaluation == EscobaEvaluation.Single) {
      player.AddPoints(1);
    }
  }
  public static void RemoveCards(CardsOnTableCenter cardsOnTableCenter, List<Card> cardsClaimed) {
    foreach(Card card in cardsClaimed) {
      cardsOnTableCenter.RemoveCard(card);
    }
  }

}