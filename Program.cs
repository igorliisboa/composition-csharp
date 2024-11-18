using System;
using composition1.Entities.enums;
using composition1.Entities;
using System.Globalization;

namespace composition1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter worker level: ");
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level =  Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.WriteLine("Enter the Base salary");
            Console.Write("Base salary:");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary,dept);

            Console.WriteLine("How many contracts for this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter the #{i} contract data:");
                Console.Write("Date (dd/MM/yyyy): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine() , CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours) ;
                worker.AddContract(contract);

            }

            Console.WriteLine();
            Console.WriteLine("Enter with month and year (MM/yyyy):");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departmewnt: " + worker.Department.Name);
            Console.WriteLine("Income for: " + monthAndYear + ":" + worker.Income(year, month));
        }
    }
}