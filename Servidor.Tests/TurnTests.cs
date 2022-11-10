using Xunit;
using Servidor;

namespace Servidor.Tests;

public class TurnTests {
  private InstanceGenerator _instanceGenerator = new InstanceGenerator();
  private static List<List<Card>> _cardSubsets1 = new List<List<Card>>();
  private List<List<Card>> _cardSubsets2 = new List<List<Card>>();
  private List<List<Card>> _cardSubsets3 = new List<List<Card>>();

  [Fact]
  public void PlayCard_GetsCorrectAmountOfSubsetsThatAddUpTo15() {
    int expectedCardSubsetsCount = 2;

    Deck deck = _instanceGenerator.Deck();
    Player player = _instanceGenerator.Player(deck);
    TableCards tableCards = _instanceGenerator.TableCards();
    Turn turn = _instanceGenerator.Turn(player, tableCards);
    EscobaVerifier escobaVerifier = turn.PlayCard(2);  
    int cardSubsetsCount = escobaVerifier.GetCardSubsets().Count;

    Assert.Equal(expectedCardSubsetsCount, cardSubsetsCount);
  } 

}
