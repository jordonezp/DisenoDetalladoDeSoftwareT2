namespace Escoba;

public class Input { 
  public bool IsValid;
  private int _value;

  public Input() {
    IsValid = false;
  }

  public static Input VerifyValidity(int max) {
    Input input = new Input();
    input.IsValid = int.TryParse(Console.ReadLine(), out input._value);
    if(!input.IsValid || input._value < 0 || input._value >= max) {
      View.PrintInputError();
      input.IsValid = false;
    } else {
      input.IsValid = true;
    }
    return input;
  }

  public int GetValue() {
    return _value;
  }

}