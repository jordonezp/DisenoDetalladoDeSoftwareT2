namespace Escoba;

public class PointsAssigner { 
  private View _view;
  
  public PointsAssigner() {
    _view = new View();
  }

  public List<Player> AssignPointsAtRoundEnd(List<Player> players) {
    _view.PrintSeparator();
    players = AssignSevenOfGoldPoint(players);
    players = AssignMostSevensPoint(players);
    players = AssignMostCardsPoint(players);
    players = AssignMostGoldsPoint(players);
    return players;
  }
  public List<Player> AssignSevenOfGoldPoint(List<Player> players) {
    foreach(Player player in players) {
      if (player.HasSevenOfGold()) {
        player.AddPoints(1);
        _view.PrintSevenOfGoldPoint(player);
      }
    } 
    return players;
  }
  public List<Player> AssignMostSevensPoint(List<Player> players) {
    int Player0SevensCount = players[0].CountNumberOfSevens();
    int Player1SevensCount = players[1].CountNumberOfSevens();
    if(Player0SevensCount >= Player1SevensCount) {
      players[0].AddPoints(1);
      _view.PrintMostSevensPoint(players[0]);
    }
    if (Player1SevensCount >= Player0SevensCount) {
      players[1].AddPoints(1);
      _view.PrintMostSevensPoint(players[1]);
    }
    return players;
  }
  public List<Player> AssignMostCardsPoint(List<Player> players) {
    int Player0CardsCount = players[0].CountCardsClaimedRound();
    int Player1CardsCount = players[1].CountCardsClaimedRound();
    if(Player0CardsCount >= Player1CardsCount) {
      players[0].AddPoints(1);
      _view.PrintMostCardsPoint(players[0]);
    }
    if (Player1CardsCount >= Player0CardsCount) {
      players[1].AddPoints(1);
      _view.PrintMostCardsPoint(players[1]);
    }
    return players;
  }
  public List<Player> AssignMostGoldsPoint(List<Player> players) {
    int Player0GoldsCount = players[0].CountNumberOfGolds();
    int Player1GoldsCount = players[1].CountNumberOfGolds();
    if(Player0GoldsCount >= Player1GoldsCount) {
      players[0].AddPoints(1);
      _view.PrintMostGoldPoint(players[0]);
    }
    if (Player1GoldsCount >= Player0GoldsCount) {
      players[1].AddPoints(1);
      _view.PrintMostGoldPoint(players[1]);
    }
    return players;
  }

}