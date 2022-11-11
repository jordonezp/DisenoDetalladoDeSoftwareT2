namespace Servidor.Tests;

using Servidor;

public class InstanceGenerator {

  public TableCards TableCards() {
    TableCards tableCards = new TableCards();
    tableCards.AppendCardList(new List<Card>() {
      new Card(Suit.Oro, Value.Cinco),
      new Card(Suit.Oro, Value.Seis),
      new Card(Suit.Oro, Value.Caballo),
      new Card(Suit.Oro, Value.Dos)
      });
    return tableCards;
  }
  public Deck Deck() {
    Deck deck = new Deck();
    deck.AppendCardList(new List<Card>() { 
      new Card(Suit.Oro, Value.Rey),
      new Card(Suit.Oro, Value.Siete),
      new Card(Suit.Oro, Value.Uno) 
    });
    return deck;
  }
  public Player PlayerWithCardsHand(Deck deck) {
    Player player = new Player(0);
    player.DrawCards(3, deck);
    return player;
  }
  public Turn Turn(Player player, TableCards tableCards) {
    Turn turn = new Turn(0, 0, player, new View(), tableCards);
    return turn;
  }

  public Player PlayerWithCardsClaimed() {
    List<Card> cardsClaimed = new List<Card>() {
      new Card(Suit.Oro, Value.Cinco),
      new Card(Suit.Oro, Value.Siete),
      new Card(Suit.Espada, Value.Siete),
      new Card(Suit.Oro, Value.Dos)
    };
    Player player = new Player(0);
    player.Claim(cardsClaimed);
    return player;
  }

  public Round Round() {
    int whoDeals = 0;
    int whoPlays = 1;
    Deck deck = new Deck();
    View view = new View(true);
    TableCards tableCards = new TableCards();
    List<Player> players = new List<Player>() { new Player(0), new Player(1) };
    Round round = new Round(whoDeals, whoPlays, deck, tableCards, view, players);
    return round;
  }

}
