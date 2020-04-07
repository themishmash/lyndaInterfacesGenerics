using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenChallengeSolution
{
    public class ClassicCar
    {
        public string m_Make;
        public string m_Model;
        public int m_Year;
        public int m_Value;

        public ClassicCar(string make, string model, int year, int val) {
            m_Make = make;
            m_Model = model;
            m_Year = year;
            m_Value = val;
        }
    }

    class ClassicCarComparer : IComparer<ClassicCar>
    {
        public int Compare(ClassicCar x, ClassicCar y)
        {
            if (x.m_Value > y.m_Value)
                return 1;
            if (x.m_Value == y.m_Value)
                return 0;
            else
                return -1;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            List<ClassicCar> carList = new List<ClassicCar>();
            populateData(carList);

            // How many cars are in the collection? Use count property
            Console.WriteLine("Total number of cars is: {0}", carList.Count);

            // How many Fords are there?
            ClassicCar car = carList.Find(x => x.m_Make.Equals("Ford"));
            if (car != null)
            {
                Console.WriteLine("There are {0} Fords", car.m_Make.Length);
            }
            
            
            

            // What is the most valuable car?
           ClassicCarComparer carComparer = new ClassicCarComparer();
           carList.Sort(carComparer);

           foreach (ClassicCar c in carList)
           {
               
              // Console.WriteLine($"{c.m_Make} {c.m_Value}");
              if (c.m_Value == carList.Max(i => i.m_Value))
              {
                  Console.WriteLine($"{c.m_Make} {c.m_Value}");
              }

           }
           

            // What is the entire collection worth?
            carList.ForEach(TotalCollectionWorth);
            Console.WriteLine("Total collection worth is: {0}", total);

            // How many unique manufacturers are there?
            Dictionary<string, bool> makes = new Dictionary<string, bool>();

            foreach (ClassicCar c in carList)
            {
                try
                {
                    makes.Add(c.m_Make, true);
                }
                catch (Exception e)
                {
                    
                }

                ;
                

            }
            Console.WriteLine("The collection contains {0} unique manufacturers", makes.Keys.Count);


            Console.WriteLine("\nHit Enter key to continue...");
            Console.ReadLine();
        }

        static void populateData(List<ClassicCar> theList) {
            theList.Add(new ClassicCar("Alfa Romeo", "Spider Veloce", 1965, 15000));
            theList.Add(new ClassicCar("Alfa Romeo", "1750 Berlina", 1970, 20000));
            theList.Add(new ClassicCar("Alfa Romeo", "Giuletta", 1978, 45000));

            theList.Add(new ClassicCar("Ford", "Thunderbird", 1971, 35000));
            theList.Add(new ClassicCar("Ford", "Mustang", 1976, 29800));
            theList.Add(new ClassicCar("Ford", "Corsair", 1970, 17900));
            theList.Add(new ClassicCar("Ford", "LTD", 1969, 12000));

            theList.Add(new ClassicCar("Chevrolet", "Camaro", 1979, 7000));
            theList.Add(new ClassicCar("Chevrolet", "Corvette Stringray", 1966, 21000));
            theList.Add(new ClassicCar("Chevrolet", "Monte Carlo", 1984, 10000));

            theList.Add(new ClassicCar("Mercedes", "300SL Roadster", 1957, 19800));
            theList.Add(new ClassicCar("Mercedes", "SSKL", 1930, 14300));
            theList.Add(new ClassicCar("Mercedes", "130H", 1936, 18400));
            theList.Add(new ClassicCar("Mercedes", "250SL", 1968, 13200));
        }

        static int total = 0;

        static void TotalCollectionWorth(ClassicCar car)
        {
            total += car.m_Value;
        }


    }
}
