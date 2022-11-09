namespace Escoba;

public class Player { 
  private Hand _hand;
  private int _number;
  private int _points;
  private int _scoreToWin;
  private CardsCollection _cardsClaimedRound;

  public Player(int number) {
    _points = 0;
    _number = number;
    _scoreToWin = 16; 
    _hand = new Hand();
    _cardsClaimedRound = new CardsCollection();
  }

  public int CountCardsClaimedRound() {
    return _cardsClaimedRound.CountCards();
  }
  public int CountNumberOfGolds() {
    return _cardsClaimedRound.CountNumberOfGolds();
  }
  public int CountNumberOfSevens() {
    return _cardsClaimedRound.CountNumberOfSevens();
  }
  public int CountHandCards() {
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

  public bool HasSevenOfGold() {
    return _cardsClaimedRound.HasSevenOfGold();
  }
  public bool HasRunOutOfCards() {
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

  public void ClaimCards(List<Card> cards) {
    _cardsClaimedRound.AddCardList(cards);
  }
  public Card TakeCard(int choice) {
    return _hand.TakeCard(choice);
  }
  public void DrawCards(int numberOfCards, CardsCollection cardsCollection) {
    _hand.TakeCards(numberOfCards, cardsCollection);
  }

  public int GetNumber() {
    return _number;
  }
  public Hand GetHand() {
    return _hand;
  }

  public override string ToString() {
    return $"Player {_number}";
  }
  public string ToStringCardsClaimedRound() {
    return _cardsClaimedRound.ConvertCardsToString();
  }

}
