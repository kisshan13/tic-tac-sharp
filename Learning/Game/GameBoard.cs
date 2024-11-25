namespace HelloWorld.Game;

public class GameBoard
{
    private Dictionary<int, string> boardInfo = new Dictionary<int, string>();

    private string playerOne = "null";
    private string playerTwo = "null";

    private readonly int[][] winningPatterns = new int[][]
    {
        new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 },
        new[] { 1, 4, 7 }, new[] { 2, 5, 8 }, new[] { 3, 6, 9 },
        new[] { 1, 5, 9 }, new[] { 3, 5, 7 }
    };

    public GameBoard()
    {
        for (int i = 1; i < 10; i++)
        {
            boardInfo.Add(i, "");
        }
    }

    public void SetPlayer(string player)
    {
        if (playerOne == "")
        {
            playerOne = player;
        }
        else
        {
            playerTwo = player;
        }
    }

    public string GetPlayerSymbol(int cell)
    {
        string boardPlayer = boardInfo[cell];

        if (boardPlayer == playerOne)
        {
            return "o";
        }
        else if (boardPlayer == playerTwo)
        {
            return "x";
        }
        else
        {
            return " ";
        }
    }

    public void DrawBoard()
    {
        Console.Clear();
        Console.WriteLine($"_____________\n" +
                          $"| {GetPlayerSymbol(1)} | {GetPlayerSymbol(2)} | {GetPlayerSymbol(3)} |\n" +
                          $"|___|___|___|\n" +
                          $"| {GetPlayerSymbol(4)} | {GetPlayerSymbol(5)} | {GetPlayerSymbol(6)} |\n" +
                          "|___|___|___|\n" +
                          $"| {GetPlayerSymbol(7)} | {GetPlayerSymbol(8)} | {GetPlayerSymbol(9)} |\n" +
                          "|___|___|___|\n");
    }

    public bool UpdateBoard(int position, string player)
    {
        string isPlayer = boardInfo[position];

        if (isPlayer == playerOne
            || isPlayer == playerTwo)
        {
            return false;
        }

        boardInfo[position] = player;
        return true;
    }

    public string CheckWinner()
    {
        foreach (var pattern in winningPatterns)
        {
            string player = boardInfo[pattern[0]];
            if (!string.IsNullOrEmpty(player) &&
                player == boardInfo[pattern[1]] &&
                player == boardInfo[pattern[2]])
            {
                return player;
            }
        }

        return "";
    }

    public void RunGameLoop()
    {
        Console.WriteLine("Welcome to Tic-Tac-Toe !!!!");
        Console.WriteLine("\n");

        Console.WriteLine("Enter Player One Name (o) :");
        this.playerOne = Console.ReadLine();

        Console.WriteLine("Enter Player Two Name (x):");
        this.playerTwo = Console.ReadLine();

        string currentPlayer = this.playerOne;
        string symbol = currentPlayer == this.playerOne ? "o" : "x";
        bool isCorrectInput = false;
        int spotsLeft = 9;

        while (true)
        {

            if (spotsLeft < 1)
            {
                Console.WriteLine("Match Draws No one wins.");
                break;
            }
            
            Console.WriteLine($"Please enter the input {currentPlayer.ToUpper()} [{symbol}]");
            int input = Convert.ToInt32(Console.ReadLine());

            if (input > 9)
            {
                Console.WriteLine("Invalid input please retry : (");
                continue;
            }

            bool isRightInput = UpdateBoard(input, currentPlayer);

            if (isRightInput)
            {
                currentPlayer = currentPlayer == playerOne ? playerTwo : playerOne;
                symbol = currentPlayer == playerOne ? "o" : "x";
                DrawBoard();
                string winner = CheckWinner();
                spotsLeft -= 1;
                
                if (winner != "")
                {
                    Console.WriteLine($"Congratulations! {winner} won!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input please retry : (");
            }
        }
    }
}