namespace Servidor.Tests;

using Servidor;

public class InstanceGenerator {

  public TableCards TableCards() {
    TableCards tableCards = new TableCards();
    tableCards.AppendCardList(new List<Card>() { new Card(Suit.Oro, Value.Cinco), new Card(Suit.Oro, Value.Seis), new Card(Suit.Oro, Value.Caballo), new Card(Suit.Oro, Value.Dos) });
    return tableCards;
  }
  public Deck Deck() {
    Deck deck = new Deck();
    deck.AppendCardList(new List<Card>() { new Card(Suit.Oro, Value.Rey), new Card(Suit.Oro, Value.Siete), new Card(Suit.Oro, Value.Uno) });
    return deck;
  }
  public Player Player(Deck deck) {
    Player player = new Player(0);
    player.DrawCards(3, deck);
    return player;
  }
  public Turn Turn(Player player, TableCards tableCards) {
    Turn turn = new Turn(0, player, tableCards, new View());
    return turn;
  }

}
