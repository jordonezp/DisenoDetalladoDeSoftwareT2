namespace Servidor;

public class Hand : CardsCollection  {

  public override string ToString() {
    string s = $"Your hand:";
    s += base.ConvertCardsToEligibleFormat();
    return s;
  }

}