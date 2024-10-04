namespace HomeWork4
{
    public class Employee: IComparable<Employee>
    {
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public decimal Salary { get; protected set; }
        
        private Employee()
        {
            Id = 0;
            Name = string.Empty;
            LastName = string.Empty;
            Salary = 0M;
        }

        public Employee(int id, string name, string lastName, decimal salary) 
        { 
            Id = id;
            Name = name;
            LastName = lastName;
            Salary = salary;
        
        }

        public static decimal operator + (Employee employee, decimal addValue)
        {
            if (addValue >= 0)
            {
                return employee.Salary += addValue;
            }
            else
                throw new ArgumentOutOfRangeException("Value must be bigger than zero.");
        }

        public static decimal operator - (Employee employee, decimal subtractValue)
        {
            if (employee.Salary >= subtractValue)
                return employee.Salary -= subtractValue;
            else
                throw new ArgumentOutOfRangeException("Value must be less then or equal to salary.");
        }

        public static bool operator > (Employee first, Employee other)
        {
            if (first is not null && other is not null)
             return first.Salary > other.Salary;
            else
                return false;
        }
        public static bool operator < (Employee first, Employee other) => !(first > other);

        public static bool operator == (Employee first, Employee second)
        {
            if (first is not null && second is not null)
                return first.Salary == second.Salary;
            else
                return false;
        }

        public static bool operator !=(Employee first, Employee second) => !(first == second);

        public override bool Equals(object? obj)
        {
            if(obj is not null)
            {
                var compareObject = obj as Employee;
                return this.Id == compareObject?.Id;
            }
            else
                return false;
            
        }

        public override int GetHashCode()
        {
            return Id + LastName.GetHashCode();
        }

        public int CompareTo(Employee? other)
        {
            if (other is not null)
                return this > other ? 1 : this < other ? -1 : 0;
            else
                throw new NullReferenceException();
        }

        public override string ToString()
        {
            return $"{Id}: {LastName}, {Name}\n" +
                $"Salary: {Salary}\n";
        }
    }
}
