using Xunit;
using Servidor;

namespace Servidor.Tests;

public class GameTests {

  [Fact]
  public void SimulateEscoba_MustRunWithoutErrors() {
    Game game = new Game();
    
    game.SimulateEscoba();
  }

}
