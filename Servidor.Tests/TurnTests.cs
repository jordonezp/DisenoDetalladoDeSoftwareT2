using Xunit;
using Servidor;

namespace Servidor.Tests;

public class TurnTests {
  private InstanceGenerator _instanceGenerator = new InstanceGenerator();
  private static List<List<Card>> _cardSubsets1 = new List<List<Card>>();
  private List<List<Card>> _cardSubsets2 = new List<List<Card>>();
  private List<List<Card>> _cardSubsets3 = new List<List<Card>>();

  [Fact]
  public void PlayCard_GetsAllCardSubsetsThatAddUpTo15() {
    List<List<Card>> expectedCardSubsets = new List<List<Card>>() { new List<Card>() { new Card(Suit.Oro, Value.Cinco), new Card(Suit.Oro, Value.Seis), new Card(Suit.Oro, Value.Caballo), new Card(Suit.Oro, Value.Dos) } };

    Deck deck = _instanceGenerator.Deck();
    Player player = _instanceGenerator.Player(deck);
    TableCards tableCards = _instanceGenerator.TableCards();
    Turn turn = _instanceGenerator.Turn(player, tableCards);
    EscobaVerifier escobaVerifier = turn.PlayCard(1);  

    Assert.Equal(expectedCardSubsets, escobaVerifier.GetCardSubsets());
  } 

}
