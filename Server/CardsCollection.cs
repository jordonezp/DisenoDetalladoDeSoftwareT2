namespace Escoba;

public class CardsCollection { 
  protected List<Card> Cards;

  public CardsCollection() {
    Cards = new List<Card>();
  }

  public void TakeCards(int numberOfCards, CardsCollection cardsCollection) {
    AddCardList(cardsCollection.DrawCards(numberOfCards));
  }
  public List<Card> DrawCards(int numberOfCards) {
    List<Card> cardsDrawn = new List<Card>();
    while (numberOfCards > 0) {
      cardsDrawn.Add(Cards[Cards.Count - 1]);
      Cards.RemoveAt(Cards.Count - 1);
      numberOfCards--;
    }
    return cardsDrawn;
  }
  public void AddCardList(List<Card> cards) {
    Cards.AddRange(cards);
  }
  public void AddCard(Card card) {
    Cards.Add(card);
  }
  public Card TakeCard(int index) {
    Card card = Cards[index];
    Cards.RemoveAt(index); 
    return card;
  }
  public void RemoveCard(Card card) {
    Cards.Remove(card);
  }

  public List<Card> GetCards() {
    return Cards; 
  }
  public List<Card> CopyCards() {
    List<Card> cardsCopy = new List<Card>(Cards);
    return cardsCopy;
  }
  public void ClearCards() {
    Cards.Clear();
  }

  public int CountNumberOfSevens() {
    int n = 0;
    foreach(Card card in Cards) {
      if (card.GetValue() == (int)Value.Siete) {
        n++;
      }
    }
    return n;
  }
  public int CountCards() {
    return Cards.Count;
  }
  public int CountNumberOfGolds() {
    int n = 0;
    foreach(Card card in Cards) {
      if (card.GetSuit() == Suit.Oro) {
        n++;
      }
    }
    return n;
  }

  public bool HasSevenOfGold() {
    foreach(Card card in Cards) {
      if (card.GetSuit() == Suit.Oro && card.GetValue() == (int)Value.Siete) {
        return true;
      }
    }
    return false;
  }
  
  public string ConvertCardsToString() {
    string printable = ConvertCardsToDisplayFormat(Cards);
    return printable;
  }
  public static string ConvertCardsToDisplayFormat(List<Card> cards) {
    string s = "";
    for(int i = 0; i < cards.Count; i++) {
      if (i == 0) {
        s += $"{cards[i]}";  
      } else {
        s += $", {cards[i]}";
      }
    }
    return s;
  }
  public string ConvertCardsToEligibleFormat() {
    string s = "";
    for (int i = 0; i < Cards.Count; i++) {
      s += $" |{i}. {Cards[i]}|";
    }
    return s;
  }
}