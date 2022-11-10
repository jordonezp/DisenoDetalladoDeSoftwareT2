namespace Servidor;

public class Game {
  private int _round;
  private View _view;
  private int _whoDeals;
  private int _whoPlays;
  private List<Player> _players;
  private TableCards _tableCards;

  public Game() {
    _round = 1;
    _whoDeals = 0;
    _whoPlays = 1;
    _view = new View();
    _tableCards = new TableCards();
    _players = new List<Player>() { new Player(), new Player()  };
  }

  public void SimulateEscoba() {
    _view.IsSimulated = true;
    PlayEscoba();
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
    Round round = new Round(_whoDeals, _whoPlays, new Deck(), _tableCards, _view, _players);
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

}