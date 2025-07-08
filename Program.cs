namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // further ideas: classes / difficulty settings / GUI

            Console.WriteLine("Welcome,\nthis little game will test your ability to guess a random number from 1 to 100. Enjoy!\n");

            string exit = "";
           
            while (exit != "exit")
            {
                Random rnd = new Random();
                int number = rnd.Next(1, 100);

                Console.ReadKey();
                Console.Clear();
                Console.Write("Type 'play' to start or 'exit' to close the game: ");
                exit = Console.ReadLine().ToLower();

                if (exit == "play")
                {
                    int attemptChosen;
                    bool validAttempt = false;
                    
                    do
                    {
                        Console.Write("\nPlease choose how many attempts you want to have (max. 20): ");
                        attemptChosen = int.Parse(Console.ReadLine());

                        if (attemptChosen < 1 || attemptChosen > 20)
                        {
                            Console.WriteLine("\nInvalid number of attempts.\n");
                        }
                        else
                        {
                            validAttempt = true;
                        }
                            
                    } while (!validAttempt);

                    int maxAttempt = 20;
                    int maxHighscore = 100;

                    int numberInput = 0;

                    float highScore = maxHighscore * ((maxAttempt) / attemptChosen);

                    while (numberInput != number && attemptChosen != 0)
                    {
                        Console.Write("\nPlease enter a number (1 to 100): ");
                        numberInput = int.Parse(Console.ReadLine());

                        Console.WriteLine($"\nYou have {attemptChosen - 1} attempts left.\n");
                        highScore -= 10;

                        if (numberInput < 0 || numberInput > 100)
                        {
                            Console.WriteLine("Invalid number.\n");
                            attemptChosen--;
                        }
                        else if (numberInput < number)
                        {
                            Console.WriteLine("The random number is bigger.\n");
                            attemptChosen--;
                        }
                        else if (numberInput > number)
                        {
                            Console.WriteLine("The random number is smaller.\n");
                            attemptChosen--;
                        }
                        else if (numberInput == number)
                        {
                            Console.Write($"Congratulations, you found the number. Your highscore is: {highScore}\nPlease type in your name: ");
                            string playerName = Console.ReadLine().ToUpper();

                            ScoreBoard.AddScore(highScore, playerName);
                            ScoreBoard.ShowScore();
                        }
                        if (attemptChosen == 0)
                        {
                            Console.WriteLine("You are out of attempts. GAME OVER!");
                        }
                    }
                }
                else if (exit == "exit")
                {
                    Console.WriteLine("Goodbye!");
                }
            }
        }
    }
}
