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
    List<List<Card>> cardSubsets = _cardsOnTableCenter.GetCardSubsetsThatAddUpTo15();
    Point point = EscobaVerifier.DeterminePointsAtDeal(cardSubsets);
    CardsClaimer cardsClaimer = new CardsClaimer(point, _players[_whoDeals], _cardsOnTableCenter, cardSubsets);
    if (!(point == Point.Zero)) {
      UpdateCardsData(cardsClaimer);
    }
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
    List<Card> cards = _cardsOnTableCenter.CopyCards();
    Point point = EscobaVerifier.DetermineRoundEndPoints(_cardsOnTableCenter, cards);
    UpdateGame(point, cards);
    _view.PrintRoundResults(_players);
  }
  public void UpdateGame(Point point, List<Card> cards) {
    CardsClaimer cardsClaimer = new CardsClaimer(point, _players[_whoDeals], _cardsOnTableCenter, new List<List<Card>>() {cards});
    UpdateCardsData(cardsClaimer);
    _players = _pointsAssigner.AssignPointsAtRoundEnd(_players);
  }
  public void UpdateCardsData(CardsClaimer cardsClaimer) {
    _players[_lastPlayerToHaveClaimedCards] = cardsClaimer.ClaimCardSubsets(); 
    _cardsOnTableCenter = cardsClaimer.RemoveCardSubsets();
  } 

}