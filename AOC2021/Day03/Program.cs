// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

string[] binaryReports = System.IO.File.ReadAllLines(@"Input.txt");
// string[] binaryReports = System.IO.File.ReadAllLines(@"TestInput.txt");
int binaryLength = binaryReports[0].Length;

PartOne();
PartTwo();

void PartOne()
{
    string gammaRate = "";
    string epsilonRate = "";

    for (int bitPosition = 0; bitPosition < binaryLength; bitPosition++)
    {
        int zeros = 0;
        int ones = 0;

        foreach (string report in binaryReports)
        {
            if (report[bitPosition] == '0')
            {
                zeros++;
            }
            else
            {
                ones++;
            }
        }

        if (zeros > ones)
        {
            gammaRate += "0";
            epsilonRate += "1";
        }
        else
        {
            gammaRate += "1";
            epsilonRate += "0";
        }
    }

    decimal gammaValue = Convert.ToInt32(gammaRate, 2);
    decimal epsilonValue = Convert.ToInt32(epsilonRate, 2);

    decimal powerConsumption = gammaValue * epsilonValue;

    Console.WriteLine($"Part one: {powerConsumption}");
}

void PartTwo()
{
    List<string> oxygenRatings = new List<string>();
    List<string> co2Ratings = new List<string>();

    oxygenRatings.AddRange(binaryReports);
    co2Ratings.AddRange(binaryReports);

    string oxygenRating = FindOxygenRating(oxygenRatings);
    string co2Rating = FindCo2Rating(co2Ratings);

    decimal oxygenValue = Convert.ToInt32(oxygenRating, 2);
    decimal co2Value = Convert.ToInt32(co2Rating, 2);

    decimal lifeSupportRating = oxygenValue * co2Value;

    Console.WriteLine($"Part two: {lifeSupportRating}");
}

string FindOxygenRating(List<string> oxygenRatings)
{
    while (oxygenRatings.Count > 1)
    {
        for (int bitPosition = 0; bitPosition < binaryLength; bitPosition++)
        {
            int zeros = 0;
            int ones = 0;
            char mostCommon;

            foreach (string report in oxygenRatings)
            {
                if (report[bitPosition] == '0')
                {
                    zeros++;
                }
                else
                {
                    ones++;
                }
            }

            if (zeros > ones)
            {
                mostCommon = '0';
            }
            else
            {
                mostCommon = '1';
            }

            foreach (string report in oxygenRatings.ToList())
            {
                if (report[bitPosition] != mostCommon)
                {
                    oxygenRatings.Remove(report);
                }
            }
        }
    }

    return oxygenRatings.First();
}

string FindCo2Rating(List<string> co2Ratings)
{
    for (int bitPosition = 0; bitPosition < binaryLength; bitPosition++)
    {
        if (co2Ratings.Count == 1)
        {
            return co2Ratings.First();
        }
        int zeros = 0;
        int ones = 0;
        char leastCommon;
        foreach (string report in co2Ratings)
        {
            if (report[bitPosition] == '0')
            {
                zeros++;
            }
            else
            {
                ones++;
            }
        }

        if (zeros < ones || zeros == ones)
        {
            leastCommon = '0';
        }
        else
        {
            leastCommon = '1';
        }

        foreach (string report in co2Ratings.ToList())
        {
            if (report[bitPosition] != leastCommon)
            {
                co2Ratings.Remove(report);
            }
        }
    }

    Console.WriteLine(co2Ratings.Count);
    return co2Ratings.First();
}