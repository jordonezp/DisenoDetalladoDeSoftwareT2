namespace Servidor;

public static class RandomNumbersGenerator {
  // RandomSeed = 48: two Escobas at initial deal
  // RandomSeed = 60: one Escoba at initial deal
  private const int RandomSeed = 2343;
  private static Random rng = new Random(RandomSeed);
  public static double Generate() => rng.Next();
}