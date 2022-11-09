namespace Escoba;

public class EscobaVerifier { 
  private List<List<Card>> _cardSubsets;

  public EscobaVerifier(List<List<Card>> cardSubsets) {
    _cardSubsets = cardSubsets;
  }

  public bool HasMultipleCardSubsetsThatAddUpTo15() {
    if (_cardSubsets.Count > 1) {
      return true;
    }
    return false;
  }
  public bool HasCardSubsetsThatAddUpTo15() {
    if (_cardSubsets.Count > 0) {
      return true;
    }
    return false;
  }
  public bool IsOneEscobaAtDeal() {
    if (_cardSubsets.Count == 1 && _cardSubsets[0].Count == 4) {
      return true;
    }
    return false;
  }
  public bool IsTwoEscobasAtDeal() {
    if (_cardSubsets.Count == 2 && !VerifyIfCardSubsetsShareCards()) {
      return true;
    }
    return false;
  }
  // Method based on code from: https://stackoverflow.com/questions/17506753/verify-if-two-lists-share-values-in-c-sharp
  public bool VerifyIfCardSubsetsShareCards() {
    return _cardSubsets[0].Intersect(_cardSubsets[1]).Any();
  }
  
  public static bool IsEscoba (CardsOnTableCenter cardsOnTableCenter, List<Card> cards) {
    if (cards.Count == cardsOnTableCenter.CountCards()) {
      return true;
    }
    return false;
  }

  public List<List<Card>> GetCardSubsets() {
    return _cardSubsets;
  }
}
