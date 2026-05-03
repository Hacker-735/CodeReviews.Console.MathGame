using static System.Net.Mime.MediaTypeNames;

string? op;
int gameCount = 0;

List<string> games = ["", "", "", "", ""];

Console.WriteLine("Welcome to Spencer's Math Quiz!");
Console.ReadLine();
Console.WriteLine("First choose what operation type you wish to solve! \n(Use numpad to choose)");
Console.ReadLine();

do
{
    do
    {
        Console.WriteLine("1. Addition\r\n2. Subtraction\r\n3. Multiplication\r\n4. Division\r\n5. View previous games\r\n6. Exit");
        op = Console.ReadLine();
        Console.Clear();
        switch (op)
        {
            case "1":
                Console.WriteLine("Addition");
                op = "+";
                break;
            case "2":
                Console.WriteLine("Subtraction");
                op = "-";
                break;
            case "3":
                Console.WriteLine("Multiplication");
                op = "*";
                break;
            case "4":
                Console.WriteLine("Division");
                op = "/";
                break;
            case "5":
                Console.WriteLine("View previous games\n");
                break;
            case "6":
                Console.WriteLine("Exit");
                Environment.Exit(0);
                break;
            default:
                {
                    Console.WriteLine("Thats not an answer, try again.");
                    op = null;
                }
                break;
        }
    } while (op == null);

    if (gameCount >= 5)
    {
        Console.WriteLine("That is your 5th game bye bye!");
        Console.ReadLine();
        Environment.Exit(0);
    }

    else if (op != "6" && op != "5")
    {
        MathGame();
        gameCount++;
    }

    else if (op == "5")
    {
        foreach (string game in games)
        {
            Console.WriteLine(game);
        }
        Console.ReadLine();
    }

} while (op != "6");

void MathGame()
{
    Random rnd1 = new Random();
    Random rnd2 = new Random();

    bool validCalculation = false;

    decimal num1 = rnd1.Next(1, 101);
    decimal num2 = rnd2.Next(1, 101);

    decimal result = op switch
    {
        "+" => num1 + num2,
        "-" => num1 - num2,
        "*" => num1 * num2,
        "/" => num1 / num2,
        _ => throw new Exception("Invalid operator")
    };


    if (op == "/")
    {
        while (validCalculation == false)
        {
            if (num1 % num2 == 0)
            {
                result = num1 / num2;

                Console.WriteLine("Whole number calculation found");
                validCalculation = true;
            }
            else
            {
                num1 = rnd1.Next(1, 101);
                num2 = rnd2.Next(1, 101);
            }
        }
    }

    Console.WriteLine($"Guess the answer! of {num1}{op}{num2}");
    games[gameCount] += ($"Guess the answer! of {num1}{op}{num2}\n\n");

    string? answer = Console.ReadLine();

    if (int.TryParse(answer, out int number) && number == result)
    {
        Console.WriteLine($"You typed the number {number}...and the answer was {result} Correct!");
        games[gameCount] += ($"You typed the number {number}...and the answer was {result} Correct!\n\n");
    }
    else
    {
        Console.WriteLine($"u a bum... You typed the number {number}...and the answer was {result}...");
        games[gameCount] += ($"u a bum... You typed the number {number}...and the answer was {result}...\n\n");
    }
}