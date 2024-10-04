namespace HomeWork4
{
    public enum Countries
    {
        Default = 0,
        Ukraine = 1,
        United_Kingdom = 2,
        USA = 3,
        Japan,
        Italy,
        France,
        Spain
    }

    public class City: IComparable<City>
    {
        public string Name { get; protected set; }
        public int Population { get; set; }
        public Countries Country { get; init; }

        private City() 
        { 
            Name = string.Empty;
            Country = 0;
            Population = 0;
        
        }

        public City(string name, int population, Countries country)
        {
            Name = name;
            Population = population;
            Country = country;
        }

        public static int operator + (City? city, int increaseValue)
        {
            if (city is null)
            {
                Console.WriteLine("Object has null reference");
                return 0;
            }
            else if (increaseValue >= 0)
            {
                return city.Population += increaseValue;
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        public static int operator - (City ?city, int decreaseValue)
        {
            if(city is null)
            {
                Console.WriteLine("Object has null reference");
                return 0;
            }
            else if (decreaseValue <= city.Population && decreaseValue >= 0)
            {
                return city.Population -= decreaseValue;
            }
            else
                throw new ArgumentOutOfRangeException();
                
        }

        public static bool operator > (City one, City other)
        {   
            if(one is not null && other is not null)
                return one.Population > other.Population;
            else
                return false;
        }
        public static bool operator < (City one, City other) => !(one.Population > other.Population);

        public static bool operator == (City one, City other)
        {
            if(one is not null && other is not null)
                return one.Population == other.Population;
            else
                return false;
        }

        public static bool operator != (City one, City other) => !(one == other); 

        public override bool Equals(object? obj)
        {
            if(obj is null) return false;

            var other = obj as City;

            return other?.Name == Name && other.Population == Population && other.Country == Country;
        }

        public override int GetHashCode()
        {
            if(this is not null)
                return Name.GetHashCode() + Population;
            else
                throw new NullReferenceException();
        }

        public override string ToString()
        {
            return $"City: {Name} Population: {Population}\n" +
                $"{Country}";
        }

        public int CompareTo(City? other) => this > other ? 1 : this < other ? -1 : 0;

    }

}
