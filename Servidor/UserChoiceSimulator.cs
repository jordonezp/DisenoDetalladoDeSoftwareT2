namespace Servidor;

public class UserInputSimulator {

  public static int Simulate(int max) {
    Random random = new Random();
    return random.Next(0, max);
  }

}