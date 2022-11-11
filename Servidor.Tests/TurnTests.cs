using Xunit;
using Servidor;

namespace Servidor.Tests;

public class TurnTests {
  private InstanceGenerator _instanceGenerator = new InstanceGenerator();

  [Fact]
  public void PlayTurn_MustRunWithoutErrors() {

    Turn turn = _instanceGenerator.Turn();

    turn.PlayTurn();
  
  } 

}
