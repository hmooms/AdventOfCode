using System;
using System.Collections.Generic;
using System.Linq;

string[] input = System.IO.File.ReadAllLines(@"TestInput.txt");
// string[] input = System.IO.File.ReadAllLines(@"Input.txt");
List<string> numberDraws = new List<string>();
List<Board> boards = new List<Board>();

SplitDrawsFromBoards();

foreach (Board board in boards)
{
    Console.WriteLine(board.board);    
}

void SplitDrawsFromBoards()
{
    List<string> splitLines = new List<string>();
    foreach (string line in input)
    {
        splitLines.AddRange(line.Split(""));
    }
    numberDraws = SetNumberDraws(splitLines[0]);
    splitLines.RemoveRange(0, 2);
    string[][] numberBoard = new string[5][];
    int loop = 0;
    foreach (string line in splitLines)
    {
        if (line == "")
            continue;
        
        if (loop == 4)
        {
            boards.Add(new Board(numberBoard));
            numberBoard = new string[5][];
            loop = 0;
            continue; 
        }

        // numberBoard[loop] = System.Text.RegularExpressions.Regex.Split( line, @"\s{1,}");
        numberBoard[loop] = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        loop++;

    }
}

List<string> SetNumberDraws(string numbers)
{
    List<string> numberDraws = new List<string>();
    
    foreach (string number in numbers.Split(","))
    {
        numberDraws.Add(number);
    }
    
    return numberDraws;
}


class Board
{
    public string[][] board;
    private string[] correctNumbers; 
    public Board(string[][] board)
    {
        this.board = board;
    }

    private bool HasBingo()
    {
     // for each row and column check if it has 5 signednumbers
     // x 1,1 x1,2 
    }
    public bool HasNumber(string number)
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                if (Convert.ToString(x) == number || Convert.ToString(y) == number)
                {
                    
                    return true;
                }
            }
        }

        return false;
    }
}