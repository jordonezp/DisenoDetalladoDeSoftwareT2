namespace Escoba;

public class EscobaVerifier { 
  private Point _points;
  private bool _createdAtDeal;
  private List<List<Card>> _cardSubsets;

  public EscobaVerifier(bool createdAtDeal, List<List<Card>> cardSubsets, Point points = Point.Zero) {
    _cardSubsets = cardSubsets;
    _createdAtDeal = createdAtDeal;
    if (_createdAtDeal) {
      DeterminePointsAtDeal();
    } else {
      _points = points;
    }
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

  public void DeterminePoints() {
    if (_createdAtDeal) {
      DeterminePointsAtDeal();
    } else {
    }
  }
  public void DeterminePointsAtDeal() {
    if (IsTwoEscobasAtDeal()) {
      _points = Point.Two;
    } else if (IsOneEscobaAtDeal()) {
      _points = Point.One;
    } else {
      _points = Point.Zero;
    }
  }
  public void DeterminePointsAfterPlay () {

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
  public Point GetPoints() {
    return _points;
  }
  public bool WasCreatedAtDeal() {
    return _createdAtDeal;
  }
}
