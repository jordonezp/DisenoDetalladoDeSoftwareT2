using Xunit;
using Servidor;

namespace Servidor.Tests;

public class CardTests {

  [Fact]
  public void GetValue_ReturnsCardValue(){
    Value expectedValue = Value.Cinco;

    Card card = new Card(Suit.Oro, Value.Cinco);

    Assert.Equal((int)expectedValue, (int)card.GetValue());
  } 

  [Fact]
  public void GetSuit_ReturnsCardSuit(){
    Suit expectedSuit = Suit.Oro;

    Card card = new Card(Suit.Oro, Value.Cinco);

    Assert.Equal(expectedSuit, card.GetSuit());
  } 

}
