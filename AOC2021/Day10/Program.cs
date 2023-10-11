// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

string[] input = System.IO.File.ReadAllLines("Input.txt");
// string[] input = System.IO.File.ReadAllLines("TestInput.txt");
char[] openingBrackets = new char[] {'(', '[', '{', '<'};

int corruptedScore = 0;
List<Int64> correctedScores = new List<Int64>();

PartOne();


void PartOne()
{
    foreach (string line in input)
    {
        bool isCorrupted = false;
        Int64 correctedScore = 0;
        List<char> expectedClosingBrackets = new List<char>();
        foreach (char character in line)
        {
            if (openingBrackets.Contains(character))
            {
                switch (character)
                {
                    case '(':
                        expectedClosingBrackets.Add(')');
                        break;

                    case '[':
                        expectedClosingBrackets.Add(']');
                        break;

                    case '{':
                        expectedClosingBrackets.Add('}');
                        break;

                    case '<':
                        expectedClosingBrackets.Add('>');
                        break;
                }
            }
            else if (character != expectedClosingBrackets[expectedClosingBrackets.Count - 1])
            {
                Console.WriteLine(
                    $"- {line} - Expected {expectedClosingBrackets[expectedClosingBrackets.Count - 1]}, but found {character} instead");
                switch (character)
                {
                    case ')':
                        corruptedScore += 3;
                        break;

                    case ']':
                        corruptedScore += 57;
                        break;

                    case '}':
                        corruptedScore += 1197;
                        break;

                    case '>':
                        corruptedScore += 25137;
                        break;
                }

                isCorrupted = true;
                break;
            }
            else
            {
                expectedClosingBrackets.RemoveAt(expectedClosingBrackets.Count - 1);
            }

            
        }

        if (isCorrupted)
            continue;
        
        expectedClosingBrackets.Reverse();
        
        foreach (char expectedClosingBracket in expectedClosingBrackets)
        {
            correctedScore *= 5;
            switch (expectedClosingBracket)
            {
                case ')':
                    correctedScore += 1;
                    break;
                    
                case ']':
                    correctedScore += 2;
                    break;
                    
                case '}':
                    correctedScore += 3;
                    break;
                    
                case '>':
                    correctedScore += 4;
                    break;
            }
        }
        correctedScores.Add(correctedScore);
    }
    
    correctedScores.Sort();
    Console.WriteLine(correctedScores.Count/2);
    Console.WriteLine($"Final correctedScore is: {correctedScores[correctedScores.Count / 2]}");
    Console.WriteLine($"Final corruptedScore is: {corruptedScore}");

}