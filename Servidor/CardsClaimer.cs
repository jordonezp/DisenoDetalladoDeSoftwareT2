namespace Servidor;

public class CardsClaimer { 
  private View _view;
  private Point _points;
  private Player _player;
  private List<List<Card>> _cardsSubsets;
  private TableCards _tableCards;

  public CardsClaimer(TableCards tableCards, Player player, Point points, View view, List<List<Card>> cardsSubsets) {
    _view = view;
    _player = player;
    _points = points;
    _tableCards = tableCards;
    _cardsSubsets = cardsSubsets;
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

  public TableCards RemoveCardSubsets() {
    if (_points == Point.Two) {
      foreach(List<Card> subset in _cardsSubsets) {
        Remove(subset);
      }
    } else {
      Remove(_cardsSubsets[0]);
    }
    return _tableCards;
  }
  public void Remove(List<Card> cardsClaimed) {
    foreach(Card card in cardsClaimed) {
      _tableCards.Remove(card);
    }
  }

  public int GetPlayerId() {
    return _player.GetId();
  }

}