using System;

namespace RandomNumberGenerator
{
    interface IRandomisable
    {
        double GetRandomNum(double dUpperBound);
    }

    class RandomNumberGenerator : IRandomisable
    {
        public RandomNumberGenerator()
        {
            
        }

        public double GetRandomNum(double dUpperBound)
        {
            Random rnumGen = new Random();
            double seed = rnumGen.NextDouble();
            return seed * dUpperBound;
        }
        
        
    }
    
    class Program
    {
        static void Main(string[] args)
        
        {
            RandomNumberGenerator randomNumber = new RandomNumberGenerator();

            string userInput;
            do
            {
                Console.WriteLine("Enter a number for the upper bound: ");
                userInput = Console.ReadLine();
                int number;
                if (!Int32.TryParse(userInput, out number))
                {
                    Console.WriteLine("Please enter a number");
                }

                else
                {
                    Console.WriteLine(randomNumber.GetRandomNum(number));
                }
            } while (userInput != "exit");


        }
    }
}


//Enter a number for the upper bound:

//Random number between 0 and 20: 7.9989898

//If enter string that is not a number, nothing happens. Program exits with keyword exit.

//to do:
//Build console app to generate randome numbers
//user enters upper bound
//result is between 0 and upper bound
//no result if input is not a number
//Program exits with word exit

//implement IRadomizable interface
//one method: GetRandomNum
//Takes upper bound as parameter
//returns random number
//create class that implements this interface
