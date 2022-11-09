namespace Escoba;

public class CardsClaimer { 
  private Player _player;
  private Point _points;
  private View _view;
  private List<List<Card>> _cardsSubsets;
  private CardsOnTableCenter _cardsOnTableCenter;

  public CardsClaimer(Point points, Player player, CardsOnTableCenter cardsOnTableCenter, List<List<Card>> cardsSubsets) {
    _player = player;
    _points = points;
    _view = new View();
    _cardsSubsets = cardsSubsets;
    _cardsOnTableCenter = cardsOnTableCenter;
  }

  public Player ClaimCardSubsets() {
    _player.AddPoints(_points);
    if (_points == Point.Two) {
      foreach(List<Card> subset in _cardsSubsets) {
        Claim(subset);
      }
    } else {
      Claim(_cardsSubsets[0]);
    }
    return _player;
  }
  public void Claim(List<Card> cards) {
    _view.PrintCardsClaimed(_points, cards);
    _player.Claim(cards);
  }

  public CardsOnTableCenter RemoveCardSubsets() {
    if (_points == Point.Two) {
      foreach(List<Card> subset in _cardsSubsets) {
        Remove(subset);
      }
    } else {
      Remove(_cardsSubsets[0]);
    }
    return _cardsOnTableCenter;
  }
  public void Remove(List<Card> cardsClaimed) {
    foreach(Card card in cardsClaimed) {
      _cardsOnTableCenter.Remove(card);
    }
  }

}