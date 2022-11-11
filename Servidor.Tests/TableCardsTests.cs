using Xunit;
using Servidor;

namespace Servidor.Tests;

public class TableCardsTests {

  private InstanceGenerator _instanceGenerator = new InstanceGenerator();

  [Theory]
  [InlineData(false, 4, 10, 2)]
  [InlineData(true, 2, 8, 5)]
  [InlineData(false, 7, 4, 1)]
  public void DoCardsAddUpTo15_ReturnsCorrectCardsValueSum(bool expectedEvaluation, int value1, int value2, int value3) {

    TableCards tableCards = _instanceGenerator.TableCards();
    List<Card> cards = _instanceGenerator.Cards(value1, value2, value3);
    bool isSumOf15 = tableCards.DoCardsAddUpTo15(cards);

    Assert.Equal(expectedEvaluation, isSumOf15);

  } 

}
