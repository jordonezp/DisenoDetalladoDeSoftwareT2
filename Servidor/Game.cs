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
    _players = new List<Player>() { new Player(0), new Player(1)  };
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

  private bool HasAnyPlayerWon() {
    foreach(Player player in _players) {
      if (player.HasWon()) {
        return true;
      }
    }
    return false;
  }

  private void PlayRound() {
    _view.PrintRoundStart(_round, _players[_whoDeals]);
    Round round = new Round(_whoDeals, _whoPlays, new Deck(), _tableCards, _view, _players);
    _players = round.PlayRound();
  }

  private void PrepareForNextRound() {
    ClearPlayersCardsClaimedLastRound();
    InvertPlayersOrder();
    _round++;
  }
  private void ClearPlayersCardsClaimedLastRound() {
    foreach (Player player in _players) {
      player.ClearCardsClaimedRound();
    }
  }
  private int InvertPlayersOrder() {
    if (_whoDeals == 0) {
      _whoPlays = 0;
      _whoDeals = 1;
    } else {
      _whoDeals = 0;
      _whoPlays = 1;
    }
    return 0;
  }
  
  private void EndGame() {
    _view.PrintGameResults(GetWinner());
  }
  private GameOutcome GetWinner() {
    if (_players[0].GetPoints() > _players[1].GetPoints()) {
      return GameOutcome.Player0Won;
    } else if (_players[0].GetPoints() < _players[1].GetPoints()) {
      return GameOutcome.Player1Won;
    } else {
      return GameOutcome.Tie;
    }
  }

}