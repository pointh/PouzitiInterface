using System;
using System.Collections.Generic;

namespace PouzitiInterface
{
    class Car : IComparable<Car>
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Volume { get; set; }

        public int CompareTo(Car c)
        {
            if (Volume == c.Volume)
                return 0;

            return (Volume > c.Volume ? 1 : -1);
        }

        public int CompareByName(Car c)
        {
            return string.Compare(Name, c.Name);
        }

        public override string ToString()
        {
            return $"{Name}, {Brand}, {Volume}";
        }
    }

    class CompareByName : IComparer<Car>
    {
        public int Compare(Car c1, Car c2)
        {
            return string.Compare(c1.Name, c2.Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>() {
                new Car { Brand = "Škoda", Name = "Octavia", Volume = 2.1 },
                new Car { Brand = "VW", Name = "Passat", Volume = 1.9 },
                new Car { Brand = "Opel", Name = "Astra", Volume = 1.8 },
                new Car { Brand = "Honda", Name = "Civic", Volume = 1.6 },
            };

           

            cars.Sort();
            foreach (var c in cars)
                Console.WriteLine(c);

            Console.WriteLine();
            IComparer<Car> icc = new CompareByName();
            cars.Sort(icc);
            foreach (var c in cars)
                Console.WriteLine(c);
        }
    }
}
