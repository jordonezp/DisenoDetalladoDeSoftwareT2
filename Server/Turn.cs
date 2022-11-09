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
    EndTurn(escobaVerifier);
    _view.PrintSeparator();
    return _lastPlayerToHaveClaimedCards;
  }

  public EscobaVerifier PlayCard(int choice) {
    Card cardChosen = _player.TakeCard(choice);
    _cardsOnTableCenter.AddCard(cardChosen);
    List<List<Card>> subsetsThatAddUpTo15 = _cardsOnTableCenter.GetCardSubsetsThatAddUpTo15();
    EscobaVerifier escobaVerifier = new EscobaVerifier(subsetsThatAddUpTo15);
    return escobaVerifier;
  }

  public void EndTurn(EscobaVerifier escobaVerifier) {
    if (escobaVerifier.HasCardSubsetsThatAddUpTo15()){
      if (escobaVerifier.HasMultipleCardSubsetsThatAddUpTo15()) {
        ChoseSubsetThatAddsUpTo15(escobaVerifier.GetCardSubsets());
      } else {
        ClaimCards(escobaVerifier.GetCardSubsets());
      }
    } else {
      _view.PrintNoCardsClaimed();
    }
  }
  public void ChoseSubsetThatAddsUpTo15(List<List<Card>> subsetsThatAddUpTo15) {
    int choice = _view.PrintChoseValidSubset(subsetsThatAddUpTo15);
    List<List<Card>> cardsClaimed = new List<List<Card>>() { subsetsThatAddUpTo15[choice] };
    ClaimCards(cardsClaimed);
  }
  public void ClaimCards(List<List<Card>> cardSubsets) {
    EscobaEvaluation escobaEvaluation;
    if (EscobaVerifier.IsEscoba(_cardsOnTableCenter, cardSubsets[0])) {
      escobaEvaluation = EscobaEvaluation.Single;
    } else {
      escobaEvaluation = EscobaEvaluation.None;
    }
    Game.ClaimSubsets(escobaEvaluation, _player, _cardsOnTableCenter, cardSubsets);
    ChangeLastPlayerToHaveClaimedCards();
  } 
  public void ChangeLastPlayerToHaveClaimedCards() {
    _lastPlayerToHaveClaimedCards = _player.GetNumber();
  }

}
