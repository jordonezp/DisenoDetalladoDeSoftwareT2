namespace Servidor.Tests;

using Servidor;

public class InstanceGenerator {

  public Turn Turn() {
    int whoPlays = 1;
    View view = new View(true);
    int lastPlayerToHaveClaimedCards = 0;
    TableCards tableCards = TableCards();
    Player player = PlayerWithCardsHand();
    Turn turn = new Turn(whoPlays, lastPlayerToHaveClaimedCards, player, view, tableCards);
    return turn;
  }
  
  public Player PlayerWithCardsHand() {
    CardsCollection cardsCollection = CardsCollection();
    Player player = new Player(0);
    player.DrawCards(3, cardsCollection);
    return player;
  }

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

  public CardsCollection CardsCollection() {
    CardsCollection cardsCollection = new CardsCollection();
    cardsCollection.AppendCardList(new List<Card>() { 
      new Card(Suit.Oro, Value.Rey),
      new Card(Suit.Oro, Value.Siete),
      new Card(Suit.Oro, Value.Uno) 
    });
    return cardsCollection;
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

    public List<Card> Cards(int value1, int value2, int value3) {
      List<Card> cards = new List<Card>() {
        new Card(Suit.Oro, (Value)value1),
        new Card(Suit.Oro, (Value)value2),
        new Card(Suit.Oro, (Value)value3),
      };
      return cards;
    }

}
