// Zack Olsen
// This will simulate the odds of how many times a number is rolled when rolling 2 die

class DiceSimulator
{
    static void Main()
    {
        // Here is the beginning of the code that will ask how many rolls will be made
        System.Console.Write("Welcome to the dice throwing simulator!\n\n");
        System.Console.Write("Enter the number of times you want to roll the dice: ");

        // This IF/ELSE checks that the number is a positive number and also that it is an integer
        if (int.TryParse(System.Console.ReadLine(), out int numberOfRolls) && numberOfRolls > 0)
        {
            DiceRoller diceRoller = new DiceRoller();
            int[] results = diceRoller.SimulateRolls(numberOfRolls);

            System.Console.WriteLine("\nResults:");
            PrintHistogram(results, numberOfRolls);
        }
        else
        {
            System.Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    static void PrintHistogram(int[] results, int totalRolls)
    {
        // This here creates the output based on the sum of the numbers after each roll and adds 
        // a "*" based on the percentage
        for (int i = 2; i <= 12; i++)
        {
            // Equation to find the percentage of rolls landed on that int
            int percentage = results[i - 2] * 100 / totalRolls;

            // I added this to add an extra space after the int for nums 2-9 so the output lines up
            if (i >= 2 && i <= 9)
            {
                System.Console.Write($"{i} : {new string('*', percentage)} ({percentage}%)");
                System.Console.WriteLine();
            }
            else
            {
                System.Console.Write($"{i}: {new string('*', percentage)} ({percentage}%)");
                System.Console.WriteLine();
            }

        }

        // Last comment after the results
        System.Console.WriteLine("\nThanks for using the dice throwing simulator. Goodbye!");
    }
}

class DiceRoller
{
    private System.Random random = new System.Random();

    // this is the method that will randomly select the number rolled on the dice
    public int[] SimulateRolls(int numberOfRolls)
    {
        int[] results = new int[11];

        for (int i = 0; i < numberOfRolls; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;
            results[sum - 2]++;
        }

        return results;
    }
}