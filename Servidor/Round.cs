namespace Servidor;

public class Round {
  private Deck _deck;
  private View _view;
  private int _whoDeals;
  private int _whoPlays;
  private List<Player> _players;
  private int _lastPlayerToHaveClaimedCards;
  private PointsAssigner _pointsAssigner;
  private TableCards _tableCards;

  public Round(int whoDeals, int whoPlays, Deck deck, TableCards tableCards, View view, List<Player> players) {
    _deck = deck;
    _players = players;
    _view = view;
    _whoPlays = whoPlays;
    _whoDeals = whoDeals;
    _lastPlayerToHaveClaimedCards = 0;
    _pointsAssigner = new PointsAssigner();
    _tableCards = tableCards;
  }

  public List<Player> PlayRound() {
    RoundPreparations();
    while (!HasRoundEnded()) {
      PlayTurn();
      ChangeWhoPlays();
    }
    EndRound();
    return _players;
  }

  private void RoundPreparations() {
    DealCards();
    SetCardsOnTableCenter();
    VerifyIfEscobasAtDeal();
    _view.PrintSeparator();
  }
  private void DealCards() {
    foreach(Player player in _players) {
      player.DrawCards(3, _deck);
    }
  }
  private void SetCardsOnTableCenter() {
    _tableCards.TakeCards(4, _deck);
  }
  private void VerifyIfEscobasAtDeal() {
    List<List<Card>> cardSubsets = _tableCards.GetCardSubsetsThatAddUpTo15();
    Point point = EscobaVerifier.DeterminePointsAtDeal(cardSubsets);
    CardsClaimer cardsClaimer = new CardsClaimer(point, _players[_whoDeals], _tableCards, cardSubsets);
    if (!(point == Point.Zero)) {
      UpdateCardsData(cardsClaimer);
    }
  }

  private bool HasRoundEnded() {
    if (HavePlayersRunOutOfCards() && HasDeckBeenDepleted()) {
      return true;
    } else {
      return false;
    }
  }
  private bool HavePlayersRunOutOfCards() {
    if (_players[0].HasRunOutOfCardsInHand() && _players[1].HasRunOutOfCardsInHand()) {
      return true;
    }
    return false;
  }
  private bool HasDeckBeenDepleted() {
    if (_deck.IsDepleted()) {
      return true;
    }
    return false;
  }

  private void PlayTurn() {
    TurnPreparations();
    Turn turn = new Turn(_lastPlayerToHaveClaimedCards, _whoPlays, _players[_whoPlays], _view, _tableCards);
    _lastPlayerToHaveClaimedCards = turn.PlayTurn();
  }
  private void TurnPreparations() {
    if (HavePlayersRunOutOfCards() && !HasDeckBeenDepleted()) {
        DealCards();
      }
  }

  private void ChangeWhoPlays() {
    if (_whoPlays == 0) {
      _whoPlays = 1;
    } else {
      _whoPlays = 0;
    }
  }

  private void EndRound() {
    _view.PrintRoundEnd(_players[_lastPlayerToHaveClaimedCards]);
    List<Card> cards = _tableCards.CopyCards();
    Point point = EscobaVerifier.DetermineRoundEndPoints(_tableCards, cards);
    UpdateGame(point, cards);
    _view.PrintRoundResults(_players);
  }
  private void UpdateGame(Point point, List<Card> cards) {
    CardsClaimer cardsClaimer = new CardsClaimer(point, _players[_whoDeals], _tableCards, new List<List<Card>>() {cards});
    UpdateCardsData(cardsClaimer);
    _players = _pointsAssigner.AssignPointsAtRoundEnd(_players);
  }
  private void UpdateCardsData(CardsClaimer cardsClaimer) {
    _players[_lastPlayerToHaveClaimedCards] = cardsClaimer.ClaimCardSubsets(); 
    _tableCards = cardsClaimer.RemoveCardSubsets();
  } 

}