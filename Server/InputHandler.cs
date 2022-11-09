namespace Escoba;

public class InputHandler { 

  public int HandleInput(int max) {
    Input input;
    do {
      input = Input.VerifyValidity(max);
    } while(!input.IsValid);
    return input.GetValue();
  }

}