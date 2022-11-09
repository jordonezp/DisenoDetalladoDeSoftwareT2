namespace Escoba;

public class Deck : CardsCollection  { 

  public Deck() {
    Populate();
    Shuffle();
  }
  public void Shuffle() {
    Cards = Cards.OrderBy(card => RandomNumbersGenerator.Generate()).ToList();  
  }
  public void Populate() {
    foreach (Suit suit in Enum.GetValues(typeof(Suit))) {
      foreach (Value vale in Enum.GetValues(typeof(Value))) {
        Cards.Add(new Card(suit, vale));
      }
    }
  }

  public bool IsDepleted() {
    return Cards.Count == 0;
  }

}