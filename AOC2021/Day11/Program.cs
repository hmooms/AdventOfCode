
using System;

string[] inputData = System.IO.File.ReadAllLines("TestInput.txt");
// int[,] octopusGrid = SetGridFromInputData(inputData);
// Console.WriteLine($"{octopusGrid[0,0]} {octopusGrid[9,9]}");

int[] grid = new int[100];
char[] splitInput = inputData.ToCharArray();
for (int a = 0; a < splitInput.Length; a++)
{
    grid[a] = splitInput[a] - '0';
}

PartOne();

void PartOne()
{
    
    // add one to every number in the grid
    
    // check if number is zero
    // if zero check..
    // if index doesnt end on 0
    //  check -1
    // if index doesnt end on 9
    //  check +1 
    // if index is less than 90
    //  check +10
    // if index doesnt end on 9 and is less than 90
    //  check +11
    // if index doesnt end on 0 and is less than 90
    //  check +9
    // if index is more than 9
    //  check -10
    // if index doesnt end on 9 and is more than 9
    //  check -9
    // if index doesnt end on 0 and is more than 9
    //  check -11
    }
























int[,] SetGridFromInputData(string[] input)
{
    int[,] grid = new int[10,10];
    for (int i = 0; i < input.Length; i++)
    {
        char[] splitInput = inputData[i].ToCharArray();
        for (int a = 0; a < splitInput.Length; a++)
        {
            grid[i, a] = splitInput[a] - '0';
        }
    }

    return grid;
}