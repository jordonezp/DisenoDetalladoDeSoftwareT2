namespace Servidor;

public class Card { 
  private Suit _suit;
  private Value _value;

  public Card(Suit suit, Value value) {
    _suit = suit;
    _value = value;
  }

  public int GetValue() {
    return (int)_value;
  }
  public Suit GetSuit() {
    return _suit;
  }

  public override string ToString() {
    return $"{_value}_{_suit}";
  }
}