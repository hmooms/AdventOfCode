using System;


namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            
            // program.PartOne();
            program.PartTwo();
        }

        public void PartOne()
        {
            int lengthOfInputData = InputData.data.Count;

            int previousMeasurement = 0;
            int measurementsLargerThanPreviousMeasurement = 0;
            for (int i = 0; i < lengthOfInputData; i++)
            {
                if (i != 0)
                {
                    if (InputData.data[i] > previousMeasurement)
                    {
                        measurementsLargerThanPreviousMeasurement++;
                    }  
                }
                
                previousMeasurement = InputData.data[i];
            }
            
            Console.WriteLine(measurementsLargerThanPreviousMeasurement);
        }

        public void PartTwo()
        {
            var data = InputData.data;
            int lengthOfInputData = data.Count;

            int previousMeasurements = 0;
            int measurementsLargerThanPreviousMeasurements = 0;

            for (int i = 0; i < lengthOfInputData - 2; i++)
            {
                int sumOfThreeMeasurements = data[i] + data[(i + 1)] + data[(i + 2)];
                if (i != 0)
                {
                    if (sumOfThreeMeasurements > previousMeasurements)
                    {
                        measurementsLargerThanPreviousMeasurements++;
                    }
                }

                previousMeasurements = sumOfThreeMeasurements;
            }
            
            Console.WriteLine(measurementsLargerThanPreviousMeasurements);
        }
    }
}