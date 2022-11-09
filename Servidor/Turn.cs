namespace Escoba;

public class Turn {
  private View _view;
  private Player _player;
  private int _whoPlays;
  private int _lastPlayerToHaveClaimedCards;
  private CardsOnTableCenter _cardsOnTableCenter;

  public Turn(int whoPlays, int lastPlayerToHaveClaimedCards, Player player, CardsOnTableCenter cardsOnTableCenter) {
    _player = player;
    _view = new View();
    _whoPlays = whoPlays;
    _cardsOnTableCenter = cardsOnTableCenter;
    _lastPlayerToHaveClaimedCards = lastPlayerToHaveClaimedCards;
  }

  public int PlayTurn() {
    int choice = _view.PrintBeginTurn(_player, _cardsOnTableCenter);
    EscobaVerifier escobaVerifier = PlayCard(choice);
    ClaimCards(escobaVerifier);
    _view.PrintSeparator();
    return _lastPlayerToHaveClaimedCards;
  }

  public EscobaVerifier PlayCard(int choice) {
    Card cardChosen = _player.TakeCard(choice);
    _cardsOnTableCenter.AppendCard(cardChosen);
    List<List<Card>> subsetsThatAddUpTo15 = _cardsOnTableCenter.GetCardSubsetsThatAddUpTo15();
    EscobaVerifier escobaVerifier = new EscobaVerifier(subsetsThatAddUpTo15);
    return escobaVerifier;
  }

  public void ClaimCards(EscobaVerifier escobaVerifier) {
    List<List<Card>> cardSubsets = escobaVerifier.GetCardSubsets();
    if (escobaVerifier.HasCardSubsetsThatAddUpTo15()){
      IsEscoba(escobaVerifier, cardSubsets);
    } else {
      _view.PrintNoCardsClaimed();
    }
  }
  public void IsEscoba(EscobaVerifier escobaVerifier, List<List<Card>> cardSubsets) {
    if (escobaVerifier.HasMultipleCardSubsetsThatAddUpTo15()) {
        ChoseSubsetThatAddsUpTo15(cardSubsets);
    } else {
      ClaimCards(cardSubsets);
    }
  }
  public void ChoseSubsetThatAddsUpTo15(List<List<Card>> subsetsThatAddUpTo15) {
    int choice = _view.PrintChoseValidSubset(subsetsThatAddUpTo15);
    List<List<Card>> cardsClaimed = new List<List<Card>>() { subsetsThatAddUpTo15[choice] };
    ClaimCards(cardsClaimed);
  }
  public void ClaimCards(List<List<Card>> cardSubsets) {
    Point point = EscobaVerifier.DetermineTurnPoints(_cardsOnTableCenter, cardSubsets);
    CardsClaimer cardsClaimer = new CardsClaimer(point, _player, _cardsOnTableCenter, cardSubsets);
    UpdateCardsData(cardsClaimer);
    ChangeLastPlayerToHaveClaimedCards();
  }
  public void UpdateCardsData(CardsClaimer cardsClaimer) {
    _player = cardsClaimer.ClaimCardSubsets(); 
    _cardsOnTableCenter = cardsClaimer.RemoveCardSubsets();
  } 
  public void ChangeLastPlayerToHaveClaimedCards() {
    _lastPlayerToHaveClaimedCards = _player.GetNumber();
  }

}
