// See https://aka.ms/new-console-template for more information

using System;
using System.IO;

string[] commands = System.IO.File.ReadAllLines(@"Input.txt");

PartOne();
PartTwo();

void PartOne()
{
    int depth = 0;
    int horizontal = 0;


    foreach (string command in commands)
    {
        string[] words = command.Split(' ');

        switch (words[0])
        {
            case "forward":
                horizontal += int.Parse(words[1]);
                break;
            
            case "up":
                depth -= int.Parse(words[1]);
                break;
            
            case "down":
                depth += int.Parse(words[1]);
                break;
        }
    }
    
    Console.WriteLine($"day one: {depth * horizontal}");
}

void PartTwo()
{
    int depth = 0;
    int horizontal = 0;
    int aim = 0;


    foreach (string command in commands)
    {
        string[] words = command.Split(' ');

        switch (words[0])
        {
            case "forward":
                horizontal += int.Parse(words[1]);
                depth += aim * int.Parse(words[1]);
                break;
            
            case "up":
                aim -= int.Parse(words[1]);
                break;
            
            case "down":
                aim += int.Parse(words[1]);
                break;
        }
    }
    
    Console.WriteLine($"day one: {depth * horizontal}");
}


