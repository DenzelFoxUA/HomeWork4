using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    public static class Task1
    {
        public static void Run()
        {
            //creating, adding, printing
            var department = new Department();

            department.Add("Josef", "Knox", 1200M);
            department.Add("Mikel", "J.Fox", 1108M);
            department.Add("Catherine", "Jones", 1250M);
            department.Add("Carla", "Jones", 1250M);
            department.Add("Sam", "Green", 1450M);
            department.Add("Denzel", "Washington", 1550M);

            MyPrinter.Print<Department,Employee>(department, "Print before sorting and comparing");
            Console.Clear();
            //

            //remove employee
            int id = 9;
            Console.WriteLine($"Remove employee with id {id}. Result => {department.RemoveById(id)}"); 
            Console.ReadLine();
            Console.Clear();
            //

            //Sorting using IComparable and overloaded operators: <, >

            var sortedByDescending = SortedListOfEmploeesByDescending(department);
            MyPrinter.Print<Employee>(sortedByDescending, "Print after sorting and comparing");
            Console.Clear();
            //

            //Adding money to sallary - overloaded operator +

            decimal extraMoney = 100M;

            foreach (var individual in department)
            {
                var result = 0M;
                if (individual.Id != 0)
                {
                    result = individual + extraMoney;
                }

            }
            MyPrinter.Print<Department,Employee>(department, $"Print after adding extra cash = {extraMoney}");
            Console.Clear();
            //

            //Taking money from sallary - overloaded operator -

            decimal takeAwayMoney = 100M;

            foreach (var individual in department)
            {
                var result = 0M;
                if (individual.Id != 0)
                {
                    result = individual - takeAwayMoney;
                }
            }

            MyPrinter.Print<Department, Employee>(department, $"Print after taking back extra cash = {takeAwayMoney}");
            Console.Clear();
            //

            //comparing != or ==

            var _Carla = department.Where(x => x.Name == "Carla").First();
            var _Catherine = department.Where(x => x.Name == "Catherine").First();
            var _Denzel = department.Where(x => x.Name == "Denzel").First();

            Console.WriteLine($"Is {_Carla.Name} has the same salary as {_Catherine.Name} = " +
                $"{_Carla == _Catherine}");
            Console.WriteLine($"Is {_Denzel.Name} has the same salary as {_Catherine.Name} = " +
                $"{_Denzel == _Catherine}");

            Console.ReadLine();
            Console.Clear();
            //
        }

        private static List<Employee> SortedListOfEmploeesByDescending(Department employees)
        {
            if (employees is not null)
                return employees.OrderByDescending(x => x).ToList();
            else
                throw new NullReferenceException("Department has null reference.");
        }

        
    }
}