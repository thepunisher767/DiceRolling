using System;

namespace DiceRolling
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueFlag = true;
            Console.WriteLine("Welcome to the Grand Circus Casino!");
            Console.Write("How many sides should each die have?: ");
            int dieSides = IntValidation(Console.ReadLine());
            int rollCount = 1;
            int[] rolls = new int[2];

            while (continueFlag)
            {
                Console.WriteLine();
                Console.WriteLine($"Roll {rollCount}: ");
                RollDice(dieSides, rolls);
                Console.WriteLine($"You rolled a {rolls[0]} and a {rolls[1]}. ({rolls[0]+rolls[1]} total)");
                CheckCombo(dieSides, rolls);

                Console.Write("Roll again? (y/n): ");
                string userContinue = YesOrNo(Console.ReadLine());
                if (userContinue == "n")
                {
                    continueFlag = false;
                }
                rollCount++;;
            }
            Console.WriteLine($"\n\nThanks for playing!!!!!!!!!!!!!!!!! AHHHHHHHHHHHHHHHHH!!!!!!!!!!!!");
        }

        public static void CheckCombo(int dieSides, int[] rolls)
        {
            if (dieSides == 6)
            {
                if (rolls[0] == 1 && rolls[1] == 1)
                {
                    Console.WriteLine("Snake Eyes!!!");
                    Console.WriteLine("Craps!!!");
                }
                else if ((rolls[0] == 1 && rolls[1] == 2) || (rolls[0] == 2 && rolls[1] == 1))
                {
                    Console.WriteLine("Ace Duece!!!");
                    Console.WriteLine("Craps!!!");
                }
                else if (rolls[0] == 6 && rolls[1] == 6)
                {
                    Console.WriteLine("Box Cars!!!");
                    Console.WriteLine("Craps!!!");
                }
                else if ((rolls[0] + rolls[1] == 7) || (rolls[0] + rolls[1] == 11))
                {
                    Console.WriteLine("Win!!!");
                }
                else if (rolls[0] + rolls[1] == 12)
                {
                    Console.WriteLine("Craps!!!");
                }
            }
        }

        public static int[] RollDice(int dieSides, int[] rolls) //Generate random rolls
        {
            Random number = new Random();
            rolls.SetValue(number.Next(1, dieSides + 1), 0);
            rolls.SetValue(number.Next(1, dieSides + 1), 1);
            return rolls;
        }

        public static int IntValidation(string input)   //Check for valid input
        {
            int validIntOutput;
            while (!int.TryParse(input, out validIntOutput))
            {
                Console.Write($"Please a valid integer: ");
                input = Console.ReadLine();
            }
            return validIntOutput;
        }

        public static string YesOrNo(string answer) //method to check (y/n)
        {
            answer = answer.ToLower();
            while (answer != "y" && answer != "n")
            {
                Console.Write("Please enter valid input (y/n): ");
                answer = Console.ReadLine();
                answer = answer.ToLower();
                Console.WriteLine();
            }
            return answer;
        }



    }
}
