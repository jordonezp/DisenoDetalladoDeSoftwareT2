namespace Servidor;

public class TableCards : CardsCollection  {

  public List<List<Card>> GetCardSubsetsThatAddUpTo15() {
    List<List<Card>> cardSubsets = GetCardSubsets();
    List<List<Card>> cardSubsetsThatAddUpTo15 = FindCardSubsetsThatAddUpTo15(cardSubsets);
    return cardSubsetsThatAddUpTo15;
  }
  public List<List<Card>> GetCardSubsets() {
    List<List<Card>> cardSubsets = new List<List<Card>>();
    FindCardSubsetsRecursively(0, new List<Card>(), cardSubsets);
    return cardSubsets;
  }
  // Method based on code from: https://www.geeksforgeeks.org/backtracking-to-find-all-subsets/
  public void FindCardSubsetsRecursively(int index, List<Card> currentCardSubset, List<List<Card>> cardSubsets) {
    // Base Condition
    if (index == Cards.Count) {
      cardSubsets.Add(currentCardSubset);
      return;
    }
    // Not including Card at position index
    FindCardSubsetsRecursively(index + 1, new List<Card>(currentCardSubset), cardSubsets);
    // Including Card at position index
    currentCardSubset.Add(Cards[index]);
    FindCardSubsetsRecursively(index + 1, new List<Card>(currentCardSubset), cardSubsets);
  }
  public List<List<Card>> FindCardSubsetsThatAddUpTo15(List<List<Card>> cardSubsets) {
    List<List<Card>> cardSubsetsThatAddUpTo15 = new List<List<Card>>();
    foreach(List<Card> subset in cardSubsets) {
      if (DoCardsAddUpTo15(subset)) {
        cardSubsetsThatAddUpTo15.Add(subset);
      }
    }
    return cardSubsetsThatAddUpTo15;
  }
  public bool DoCardsAddUpTo15(List<Card> subset) {
    int cardsSum = 0;
    foreach (Card card in subset) {
      cardsSum += card.GetValue();
    }
    return (cardsSum == 15);
  }

  public override string ToString() {
    string s = $"Cards on the table: ";
    s += ConvertCardsToDisplayFormat(Cards);
    return s;
  }
  
}