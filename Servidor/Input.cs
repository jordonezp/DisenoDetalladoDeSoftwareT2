namespace Servidor;

public class Input { 
  public bool IsValid;
  private int _value;

  public Input() {
    IsValid = false;
  }

  public static Input VerifyValidity(int max) {
    Input input = new Input();
    input.IsValid = int.TryParse(Console.ReadLine(), out input._value);
    if(input.IsValid && IsInRange(input._value, max)) {
      input.IsValid = true;
    } else {
      View.PrintInputError();
      input.IsValid = false;
    }
    return input;
  }
  private static bool IsInRange(int value, int max) {
    if (value < 0 || value >= max) {
      return false;
    } else {
      return true;
    }
  }

  public int GetValue() {
    return _value;
  }

}