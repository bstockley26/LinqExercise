using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine("Sum of Numbers:");
            var sumOfNumbers = numbers.Sum(x => x);

            Console.WriteLine(sumOfNumbers);

            //TODO: Print the Average of numbers
            Console.WriteLine("Average of Numbers:");
            var averageOfNumbers = numbers.Average(x => x);
            Console.WriteLine(averageOfNumbers);
            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Ascending Order:");
            var ascendingOrder = numbers.OrderBy(x => x);
            foreach (var number in ascendingOrder)
            {
                Console.WriteLine(number);
            }
            //TODO: Order numbers in descending order and print to the console

            Console.WriteLine("Descending order:");
            var descendingOrder = numbers.OrderByDescending(x => x);
            foreach (var number in descendingOrder)
            {
                Console.WriteLine(number);
            }
            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine(" Numbers greater then 6:");
            var numGreaterThenSix = numbers.Where(x => x > 6);
            foreach (var number in numGreaterThenSix)
            {
                Console.WriteLine(number);
            }
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Four numbers ascending:");
            var ascendingFour = numbers.OrderBy(x=>x);
            var firstFour = ascendingFour.Take(4);
            foreach ( var number in firstFour)
            {
                Console.WriteLine(number);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("My age and descending:");
            int myAge = 25;

            var indexedAge = numbers.Select((x, Index) => Index == 4 ? myAge : x);
            var myAgePlusDescending = indexedAge.OrderByDescending(n => n);

            foreach (var number in myAgePlusDescending)
            {
                Console.WriteLine(number);
            }
                // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Name starts with C or S:");
            var firstNameCandS = employees.Where(employees => employees.FirstName.StartsWith("C") || employees.FirstName.StartsWith("S"))
                .OrderBy(employees => employees.FirstName)
                .Select(employees => employees.FullName);

            foreach (var fullname in firstNameCandS)
            {
                Console.WriteLine(fullname);
            }
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Name and Age");

            var nameAndAge = employees.Where(employees => employees.Age > 26)
            .OrderBy(employees => employees.Age).ThenBy(employees=>employees.FirstName)
           .Select(employees => new { employees.Age, employees.FullName });
            
            foreach (var fullname in nameAndAge)
            {
                Console.WriteLine(fullname);
            }
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var ageAndYOE = employees.Where(employees => employees.YearsOfExperience <= 10 && employees.Age > 35).Sum(employees => employees.YearsOfExperience);
            Console.WriteLine(ageAndYOE);
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var averageYOE = employees.Where(employees => employees.YearsOfExperience <= 10 && employees.Age > 35).Average(employees => employees.YearsOfExperience);
            Console.WriteLine(averageYOE);
            //TODO: Add an employee to the end of the list without using employees.Add()
            Employee brooks = new Employee()
            {

                FirstName = "Brooks",
                LastName = "Stockley",
                Age = 25,
                YearsOfExperience = 0,

            };

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
