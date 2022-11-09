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
        ClaimCards(subset);
      }
    } else {
      ClaimCards(_cardsSubsets[0]);
    }
    return _player;
  }
  public void ClaimCards(List<Card> cards) {
    _view.PrintCardsClaimed(_points, cards);
    _player.ClaimCards(cards);
  }

  public CardsOnTableCenter RemoveCardSubsets() {
    if (_points == Point.Two) {
      foreach(List<Card> subset in _cardsSubsets) {
        RemoveCards(subset);
      }
    } else {
      RemoveCards(_cardsSubsets[0]);
    }
    return _cardsOnTableCenter;
  }
  public void RemoveCards(List<Card> cardsClaimed) {
    foreach(Card card in cardsClaimed) {
      _cardsOnTableCenter.RemoveCard(card);
    }
  }

}