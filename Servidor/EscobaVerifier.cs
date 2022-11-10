namespace Servidor;

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
  
  public static Point DetermineTurnPoints(TableCards tableCards, List<List<Card>> cards) {
    Point point;
    if (IsEscobaOnTurn(tableCards, cards)) {
      point = Point.One;
    } else {
      point = Point.Zero;
    }
    return point;
  }
  private static bool IsEscobaOnTurn(TableCards tableCards, List<List<Card>> cards) {
    if (cards[0].Count == tableCards.CountCards()) {
      return true;
    }
    return false;
  }
  public static Point DetermineRoundEndPoints(TableCards tableCards, List<Card> cards) {
    Point point;
    if (tableCards.DoCardsAddUpTo15(cards)) {
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
  private static bool IsOneEscobaAtDeal(List<List<Card>> cardSubsets) {
    if (cardSubsets.Count == 1 && cardSubsets[0].Count == 4) {
      return true;
    }
    return false;
  }
  private static bool IsTwoEscobasAtDeal(List<List<Card>> cardSubsets) {
    if (cardSubsets.Count == 2 && !VerifyIfCardSubsetsShareCards(cardSubsets)) {
      return true;
    }
    return false;
  }
  // Method based on code from: https://stackoverflow.com/questions/17506753/verify-if-two-lists-share-values-in-c-sharp
  private static bool VerifyIfCardSubsetsShareCards(List<List<Card>> cardSubsets) {
    return cardSubsets[0].Intersect(cardSubsets[1]).Any();
  }

  public List<List<Card>> GetCardSubsets() {
    return _cardSubsets;
  }
}
