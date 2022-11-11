namespace Servidor;

public class Player { 
  private Hand _hand;
  private int _id;
  private int _points;
  private int _scoreToWin;
  private CardsCollection _cardsClaimedRound;

  public Player(int id) {
    _id = id;
    _points = 0;
    _scoreToWin = 16; 
    _hand = new Hand();
    _cardsClaimedRound = new CardsCollection();
  }

  public int CountCardsClaimedRound() {
    return _cardsClaimedRound.CountCards();
  }
  public int CountGoldsClaimedRound() {
    return _cardsClaimedRound.CountGolds();
  }
  public int CountSevensClaimedRound() {
    return _cardsClaimedRound.CountSevens();
  }
  public bool HasSevenOfGold() {
    return _cardsClaimedRound.HasSevenOfGold();
  }
  public int CountCardsHand() {
    return _hand.CountCards();
  }

  public void ClearCardsClaimedRound() {
    _cardsClaimedRound.ClearCards();
  }

  public void AddPoints(Point points) {
    if (points == Point.Two) {
      _points += 2;
    } else if (points == Point.One) {
      _points += 1;
    }
  }
  public int GetPoints() {
    return _points;
  }

  public bool HasRunOutOfCardsInHand() {
    if (_hand.CountCards() == 0) {
      return true;
    }
    return false;
  }
  public bool HasWon() {
    if (_points >= _scoreToWin) {
      return true;
    }
    return false;
  }

  public void Claim(List<Card> cards) {
    _cardsClaimedRound.AppendCardList(cards);
  }
  public Card TakeCardFromHand(int choice) {
    return _hand.TakeCard(choice);
  }
  public void DrawCards(int numberOfCards, CardsCollection cardsCollection) {
    _hand.TakeCards(numberOfCards, cardsCollection);
  }

  public int GetId() {
    return _id;
  }
  public Hand GetHand() {
    return _hand;
  }

  public override string ToString() {
    return $"Player {_id}";
  }
  public string ToStringCardsClaimedRound() {
    return _cardsClaimedRound.ConvertCardsToString();
  }

}
