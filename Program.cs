using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // Prints the welcome message and prompt.
        Console.WriteLine("Welcome to the dice throwing simulator!");
        Console.Write("How many dice rolls would you like to simulate? ");

        // Gets input for the numbers of times to throw the dice and converts to integer.
        int throwNum = Convert.ToInt32(Console.ReadLine());

        // Creates instance of the DiceSimulator class and passes throwNum to it to simulate rolls.
        DiceSimulator simulator = new DiceSimulator();
        int[] rollResults = simulator.SimulateRolls(throwNum);

        // Stores the total number of each roll in an array.
        int[] totals = new int[11];
        foreach (int roll in rollResults)
        {totals[roll - 2]++;}

        // Prints the simulation results
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("(Each \"*\" represents roughly 1% of the total number of rolls.)");
        Console.WriteLine("Total Number of Rolls = " + throwNum + "\n");

        // Prints the percentage occurrence of each roll as asterisks.
        for (int i = 0; i < totals.Length; i++)
        {
            int percent = (int)Math.Round(totals[i] * 100.0 / throwNum);
            string asterisks = new string('*', percent);
            Console.WriteLine($"{i + 2}: {asterisks}");
        }
    }
}

// Creates a new class to simulate dice rolls.
public class DiceSimulator
{
    // Uses an instance of the Random class to get random numbers
    private Random _random;
    public DiceSimulator()
    {_random = new Random();}

    // Simulates the rolls using the number of rolls specified as a parameter and puts the results in an array.
    public int[] SimulateRolls(int numberOfRolls)
    {
        int[] rolls = new int[numberOfRolls];

        for (int i = 0; i < numberOfRolls; i++)
        {rolls[i] = RollDice();}

        return rolls;
    }

    // Rolls the dice and returns the sum of the rolls.
    private int RollDice()
    {
        int dice1 = _random.Next(1, 7);
        int dice2 = _random.Next(1, 7);
        return dice1 + dice2;
    }
}
