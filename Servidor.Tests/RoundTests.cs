using Xunit;
using Servidor;

namespace Servidor.Tests;

public class RoundTests {
  private InstanceGenerator _instanceGenerator = new InstanceGenerator();

  [Fact]
  public void PlayRound_MustRunWithoutErrors(){

    Round round = _instanceGenerator.Round();

    round.PlayRound();

  }

}