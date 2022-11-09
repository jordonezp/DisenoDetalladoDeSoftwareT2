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
  
  public static Point DetermineTurnPoints(CardsOnTableCenter cardsOnTableCenter, List<List<Card>> cards) {
    Point point;
    if (IsEscobaOnTurn(cardsOnTableCenter, cards)) {
      point = Point.One;
    } else {
      point = Point.Zero;
    }
    return point;
  }
  public static bool IsEscobaOnTurn(CardsOnTableCenter cardsOnTableCenter, List<List<Card>> cards) {
    if (cards[0].Count == cardsOnTableCenter.CountCards()) {
      return true;
    }
    return false;
  }
  public static Point DetermineRoundEndPoints(CardsOnTableCenter cardsOnTableCenter, List<Card> cards) {
    Point point;
    if (cardsOnTableCenter.DoCardsAddUpTo15(cards)) {
      point = Point.One;
    } else {
      point = Point.Zero;
    }
    return point;
  }
  public static Point DeterminePointsAtDeal(List<List<Card>> cardSubsets) {
    if (IsOneEscobaAtDeal(cardSubsets)) {
      return Point.One;
    } else if (IsTwoEscobasAtDeal(cardSubsets)) {
      return Point.Two;
    } else {
      return Point.Zero;
    }
  }
  public static bool IsOneEscobaAtDeal(List<List<Card>> cardSubsets) {
    if (cardSubsets.Count == 1 && cardSubsets[0].Count == 4) {
      return true;
    }
    return false;
  }
  public static bool IsTwoEscobasAtDeal(List<List<Card>> cardSubsets) {
    if (cardSubsets.Count == 2 && !VerifyIfCardSubsetsShareCards(cardSubsets)) {
      return true;
    }
    return false;
  }
  // Method based on code from: https://stackoverflow.com/questions/17506753/verify-if-two-lists-share-values-in-c-sharp
  public static bool VerifyIfCardSubsetsShareCards(List<List<Card>> cardSubsets) {
    return cardSubsets[0].Intersect(cardSubsets[1]).Any();
  }

  public List<List<Card>> GetCardSubsets() {
    return _cardSubsets;
  }
}
