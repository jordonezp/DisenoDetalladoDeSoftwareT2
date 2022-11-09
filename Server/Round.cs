namespace Escoba;

public class Round {
  private Deck _deck;
  private View _view;
  private int _whoDeals;
  private int _whoPlays;
  private List<Player> _players;
  private int _lastPlayerToHaveClaimedCards;
  private PointsAssigner _pointsAssigner;
  private CardsOnTableCenter _cardsOnTableCenter;

  public Round(int whoDeals, int whoPlays, Deck deck, CardsOnTableCenter cardsOnTableCenter, List<Player> players) {
    _deck = deck;
    _players = players;
    _view = new View();
    _whoPlays = whoPlays;
    _whoDeals = whoDeals;
    _lastPlayerToHaveClaimedCards = 0;
    _pointsAssigner = new PointsAssigner();
    _cardsOnTableCenter = cardsOnTableCenter;
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

  public void RoundPreparations() {
    DealCards();
    SetCardsOnTableCenter();
    VerifyIfPlayerClaimsCardsOnDeal();
    _view.PrintSeparator();
  }
  public void DealCards() {
    foreach(Player player in _players) {
      player.DrawCards(3, _deck);
    }
  }
  public void SetCardsOnTableCenter() {
    _cardsOnTableCenter.TakeCards(4, _deck);
  }
  public void VerifyIfPlayerClaimsCardsOnDeal() {
    Console.WriteLine(_cardsOnTableCenter);
    List<List<Card>> cardSubsetsThatAddUpTo15 = _cardsOnTableCenter.GetCardSubsetsThatAddUpTo15();
    // EscobaVerifier escobaVerifier = new EscobaVerifier(cardSubsetsThatAddUpTo15);
    // if (escobaVerifier.IsOneEscobaAtDeal()) {
    //   Game.ClaimSubsets(Point.One, _players[_whoDeals], _cardsOnTableCenter, escobaVerifier.GetCardSubsets());
    // } else if (escobaVerifier.IsTwoEscobasAtDeal()) {
    //   Game.ClaimSubsets(Point.Two, _players[_whoDeals], _cardsOnTableCenter, escobaVerifier.GetCardSubsets());
    // }
  }

  public bool HasRoundEnded() {
    if (HavePlayersRunOutOfCards() && HasDeckBeenDepleted()) {
      return true;
    } else {
      return false;
    }
  }
  public bool HavePlayersRunOutOfCards() {
    if (_players[0].HasRunOutOfCards() && _players[1].HasRunOutOfCards()) {
      return true;
    }
    return false;
  }
  public bool HasDeckBeenDepleted() {
    if (_deck.IsDepleted()) {
      return true;
    }
    return false;
  }

  public void PlayTurn() {
    TurnPreparations();
    Turn turn = new Turn(_lastPlayerToHaveClaimedCards, _whoPlays, _players[_whoPlays], _cardsOnTableCenter);
    _lastPlayerToHaveClaimedCards = turn.PlayTurn();
  }
  public void TurnPreparations() {
    if (HavePlayersRunOutOfCards() && !HasDeckBeenDepleted()) {
        DealCards();
      }
  }

  public void ChangeWhoPlays() {
    if (_whoPlays == 0) {
      _whoPlays = 1;
    } else {
      _whoPlays = 0;
    }
  }

  public void EndRound() {
    _view.PrintRoundEnd(_players[_lastPlayerToHaveClaimedCards]);
    List<List<Card>> cardsClaimed = new List<List<Card>>() {_cardsOnTableCenter.CopyCards()};
    Game.ClaimSubsets(Point.Zero, _players[_whoDeals], _cardsOnTableCenter, cardsClaimed);
    _players = _pointsAssigner.AssignPointsAtRoundEnd(_players);
    _view.PrintRoundResults(_players);
  }

}