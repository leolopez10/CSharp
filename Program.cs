using System;
using System.Collections.Generic;

namespace Catworx.BadgeMaker
{
    class Program
    {
        // PHASE 3
        // This is our employee-getting code
        static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            while (true)
            {
                Console.WriteLine("Please enter First Name: ");

                string firstName = Console.ReadLine();

                if (firstName == "")
                {
                    break;
                }

                Console.WriteLine("Please enter your Last Name: ");

                string lastName = Console.ReadLine();

                Console.WriteLine("Please enter Employee ID: ");

                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter your avatar URL: ");

                string photoUrl = Console.ReadLine();




                // employees.Add(input);
                // Create new employee instances
                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);

                // employees.Add(currentEmployee.GetName());
                employees.Add(currentEmployee);
            }
            return employees;

        }

        static void printEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                string template = "{0,-10}\t{1,-20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetName(), employees[i].GetPhotoUrl()));
            }
        }

        static void Main(string[] args)
        {
            List<Employee> employees = GetEmployees();
            printEmployees(employees);
        }
    }
}

// // PHASE 2
// //Init new list of employees
// List<string> employees = new List<string>();

// // Add new employees to current list
// // employees.Add("barbara");
// // employees.Add("billy");

// // Create a while loop to take user input until complete
// while (true)
// {
//     Console.WriteLine("Please enter a name: (leave empty to exit)");

//     // Get a name from the console and assign it to a variable

//     string input = Console.ReadLine();

//     if (input == "")
//     {
//         break;
//     }
//     employees.Add(input);
// }

// for (int i = 0; i < employees.Count; i++)
// {
//     Console.WriteLine(employees[i]);
// }



// //  PHASE ONE
// // Hello World
// Console.WriteLine("Hello World!");

// // ============================================
// // Printing a string
// //=============================================
// Console.WriteLine("====================================== Print a String ======================");
// string greeting = "Hello";
// greeting = greeting + "World";

// //Interpolation of String Examples
// Console.WriteLine("greetings" + greeting);
// Console.WriteLine($"Greetings {greeting}");
// Console.WriteLine("greetings: {0}", greeting);


// // ================================================
// // Simple Math and variable change
// // ================================================
// Console.WriteLine("====================================== Simple Math ==============================");
// // Math is the same as JavaScript. % * + -, ++ -- += -= *= /=

// // Find the area of this circle
// int radius = 3;
// double pi = 3.14;

// // answer
// double area = pi * Math.Pow(radius, 2);
// Console.WriteLine($"Radius: {radius}");
// Console.WriteLine($"Pi: {pi}");
// Console.WriteLine($"Area of Circle pi(r^2): {area}");

// // Checking for type of variable
// Console.WriteLine($"Area is a {area.GetType()}"); // answer: System.Double

// // ===============================================================================
// // Data Types and Conversions
// // ================================================================================
// Console.WriteLine("====================================== Data Type Conversions ===========================");

// // converting string to a num
// string stringNum = "2";
// int num = Convert.ToInt32(stringNum); //Covert from system (using System)
// Console.WriteLine($"Int num: {num}");

// // =======================================
// // Dictionaries 
// // =======================================
// Console.WriteLine("=== Dictionarites ===");

// // Create dictionary
// Dictionary<string, int> myScoreBoard;
// // Init new dictionary
// myScoreBoard = new Dictionary<string, int>()
// {
//     {"firstInning", 0},
//     {"secondInning", 1},
//     {"thirdInning", 4}
// };
// // Add or populate the myScoreBoard dictionary
// myScoreBoard.Add("fourthInning", 2);
// myScoreBoard.Add("fifthInning", 3);

// Console.WriteLine("----------------");
// Console.WriteLine("  Scoreboard");
// Console.WriteLine("----------------");
// Console.WriteLine("Inning |  Score");
// Console.WriteLine($"  1   |     {myScoreBoard["firstInning"]}");
// Console.WriteLine($"  2   |     {myScoreBoard["secondInning"]}");
// Console.WriteLine($"  3   |     {myScoreBoard["thirdInning"]}");
// Console.WriteLine($"  4   |     {myScoreBoard["fourthInning"]}");
// Console.WriteLine($"  5   |     {myScoreBoard["fifthInning"]}");

// // ============================================
// // Arrays vs Lists
// // ============================================
// Console.WriteLine("=== Arrays ===");

// // Init array
// string[] favFoods = new string[3] { "pizza", "doughnuts", "icecream" };
// string firstFood = favFoods[0];
// string secondFood = favFoods[1];
// string thirdFood = favFoods[2];
// // Print Array
// Console.WriteLine($"I like {firstFood}, {secondFood}, and {thirdFood}");

// // Init List
// List<string> employees = new List<string>() { "adam", "amy" };
// employees.Add("barbara");
// employees.Add("billy");
// // Print List
// Console.WriteLine("My employees include {0}, {1}, {2}, {3}", employees[0], employees[1], employees[2], employees[3]);
// Console.WriteLine($"Employees again: {employees[0]}, {employees[1]}, {employees[2]} ,{employees[3]}");

// // ============================================
// // Loops
// // ============================================
// Console.WriteLine("=== Loops ===");

// // For loop
// Console.WriteLine("=== For Loop ===");
// for (int i = 0; i < employees.Count; i++)
// {
//     Console.WriteLine(employees[i]);
// }

// // Foreach Loop (designed for looping through arrays)
// Console.WriteLine("=== foreach Loop ===");
// foreach (string employee in employees)
// {
//     Console.WriteLine(employee);
// }

// // Foreach Loop dictionary
// Console.WriteLine("=== foreach dictionary ===");
// foreach (KeyValuePair<string, int> inning in myScoreBoard)
// {
//     Console.WriteLine(inning);
// }
