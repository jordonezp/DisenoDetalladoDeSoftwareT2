using Xunit;
using Servidor;

namespace Servidor.Tests;

public class PlayerTests {
  
  private InstanceGenerator _instanceGenerator = new InstanceGenerator();

  [Fact]
  public void CountCardsClaimedRound_ReturnsCorrectNumberOfCardsClaimedByPlayer(){

    int expectedCount = 4;

    Player player = _instanceGenerator.PlayerWithCardsClaimed();
    int cardsClaimedCount = player.CountCardsClaimedRound();

    Assert.Equal(expectedCount, cardsClaimedCount);

  }

  [Fact]  
  public void CountGoldsClaimedRound_ReturnsCorrectNumberOfGoldsClaimedByPlayer(){

    int expectedCount = 3;

    Player player = _instanceGenerator.PlayerWithCardsClaimed();
    int goldsClaimedCount = player.CountGoldsClaimedRound();

    Assert.Equal(expectedCount, goldsClaimedCount);

  } 

  [Fact]  
  public void CountSevensClaimedRound_ReturnsCorrectNumberOfSevensClaimedByPlayer(){

    int expectedCount = 2;

    Player player = _instanceGenerator.PlayerWithCardsClaimed();
    int sevensClaimedCount = player.CountSevensClaimedRound();

    Assert.Equal(expectedCount, sevensClaimedCount);

  } 

  [Fact]  
  public void HasSevenOfGold_ReturnsWhetherSevenOfGoldWasClaimedByPlayer(){

    bool expectedEvaluation = true;

    Player player = _instanceGenerator.PlayerWithCardsClaimed();
    bool hasSevenOfGold = player.HasSevenOfGold();

    Assert.Equal(expectedEvaluation, hasSevenOfGold);

  } 

  [Fact]  
  public void CountCardsHand_ReturnsCorrectNumberOfCardsInHandForPlayer(){

    int expectedCount = 3;

    Player player = _instanceGenerator.PlayerWithCardsHand();
    int cardsHandCount = player.CountCardsHand();

    Assert.Equal(expectedCount, cardsHandCount);

  }

  [Fact]  
  public void ClearCardsClaimedRound_ReturnsThatPlayerHasNoCardsClaimedThisRound(){

    int expectedCount = 0;

    Player player = _instanceGenerator.PlayerWithCardsClaimed();
    player.ClearCardsClaimedRound();
    int cardsClaimedCount = player.CountCardsClaimedRound();

    Assert.Equal(expectedCount, cardsClaimedCount);

  }

  [Theory]
  [InlineData(0, Point.Zero)]  
  [InlineData(1, Point.One)]
  [InlineData(2, Point.Two)]
  public void GetPoints_ReturnsCorrectNumberOfPoints(int expectedPoints, Point points){

    Player player = _instanceGenerator.PlayerWithCardsClaimed();
    player.AddPoints(points);
    int playerPoints = player.GetPoints();

    Assert.Equal(expectedPoints, playerPoints);

  }

  [Fact]  
  public void HasRunOutOfCards_ReturnsThatPlayerHasRunOutOfCardsInHand(){

    bool expectedEvaluation = true;

    Player player = _instanceGenerator.PlayerWithCardsHand();
    player.TakeCardFromHand(0);
    player.TakeCardFromHand(0);
    player.TakeCardFromHand(0);
    bool hasCardsLeftHand = player.HasRunOutOfCardsInHand();

    Assert.Equal(expectedEvaluation, hasCardsLeftHand);

  } 

  [Fact]  
  public void HasWon_ReturnsThatPlayerHasWon(){

    bool expectedEvaluation = true;

    Player player = _instanceGenerator.PlayerWithCardsClaimed();
    for (int i = 0; i < 8; i++) {
      player.AddPoints(Point.Two);
    }
    bool hasWon = player.HasWon();

    Assert.Equal(expectedEvaluation, hasWon);

  } 

  [Fact]
  public void GetId_ReturnsCorrectPlayerId(){

    int expectedId = 0;

    Player player = _instanceGenerator.PlayerWithCardsClaimed();
    int playerId = player.GetId();

    Assert.Equal(expectedId, playerId);

  }

}