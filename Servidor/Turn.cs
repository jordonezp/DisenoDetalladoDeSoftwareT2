namespace Servidor;

public class Turn {
  private View _view;
  private Player _player;
  private int _whoPlays;
  private int _lastPlayerToHaveClaimedCards;
  private TableCards _tableCards;

  public Turn(int whoPlays, int lastPlayerToHaveClaimedCards, Player player, View view, TableCards tableCards) {
    _player = player;
    _view = view;
    _whoPlays = whoPlays;
    _tableCards = tableCards;
    _lastPlayerToHaveClaimedCards = lastPlayerToHaveClaimedCards;
  }

  public int PlayTurn() {
    int choice = _view.PrintBeginTurn(_player, _tableCards);
    EscobaVerifier escobaVerifier = PlayCard(choice);
    ClaimCards(escobaVerifier);
    _view.PrintSeparator();
    return _lastPlayerToHaveClaimedCards;
  }

  private EscobaVerifier PlayCard(int choice) {
    Card cardChosen = _player.TakeCardFromHand(choice);
    _tableCards.AppendCard(cardChosen);
    List<List<Card>> subsetsThatAddUpTo15 = _tableCards.GetCardSubsetsThatAddUpTo15();
    EscobaVerifier escobaVerifier = new EscobaVerifier(subsetsThatAddUpTo15);
    return escobaVerifier;
  }

  private void ClaimCards(EscobaVerifier escobaVerifier) {
    List<List<Card>> cardSubsets = escobaVerifier.GetCardSubsets();
    if (escobaVerifier.HasCardSubsetsThatAddUpTo15()){
      IsEscoba(escobaVerifier, cardSubsets);
    } else {
      _view.PrintNoCardsClaimed();
    }
  }
  private void IsEscoba(EscobaVerifier escobaVerifier, List<List<Card>> cardSubsets) {
    if (escobaVerifier.HasMultipleCardSubsetsThatAddUpTo15()) {
        ChoseSubsetThatAddsUpTo15(cardSubsets);
    } else {
      ClaimCards(cardSubsets);
    }
  }
  private void ChoseSubsetThatAddsUpTo15(List<List<Card>> subsetsThatAddUpTo15) {
    int choice = _view.PrintChoseValidSubset(subsetsThatAddUpTo15);
    List<List<Card>> cardsClaimed = new List<List<Card>>() { subsetsThatAddUpTo15[choice] };
    ClaimCards(cardsClaimed);
  }
  private void ClaimCards(List<List<Card>> cardSubsets) {
    Point point = EscobaVerifier.DetermineTurnPoints(_tableCards, cardSubsets);
    CardsClaimer cardsClaimer = new CardsClaimer(point, _player, _tableCards, cardSubsets);
    UpdateCardsData(cardsClaimer);
    ChangeLastPlayerToHaveClaimedCards();
  }
  private void UpdateCardsData(CardsClaimer cardsClaimer) {
    _player = cardsClaimer.ClaimCardSubsets(); 
    _tableCards = cardsClaimer.RemoveCardSubsets();
  } 
  private void ChangeLastPlayerToHaveClaimedCards() {
    _lastPlayerToHaveClaimedCards = _player.GetId();
  }

}
