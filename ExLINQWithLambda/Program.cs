using ExLINQWithLambda.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExLINQWithLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            Console.Write("ENTER THE FILE PATH: ");
            string path = Console.ReadLine();
            Console.Write("ENTER SALARY: ");
            double n = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while(!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        string email = line[1];
                        double salary = double.Parse(line[2], CultureInfo.InvariantCulture);
                        list.Add(new Employee(name, email, salary));
                    }
                    var r1 = list.Where(p => p.Salary > n).OrderBy(p => p.Email).Select(p => p.Email);
                    var r2 = list.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
                    Console.WriteLine("Email of people whose salary is more than " + n.ToString("F2", CultureInfo.InvariantCulture));
                    foreach (string email in r1)
                    {
                        Console.WriteLine(email);
                    }
                    Console.WriteLine("Sum of salary of people whose name starts with 'M': " + r2.ToString("F2", CultureInfo.InvariantCulture));
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
