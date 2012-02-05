using System;
using System.Collections.Generic;
using System.Linq;

namespace Employees
{
    struct Position
    {
        public string name;
        public int priority;

        public Position(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }
    }
   
    struct Employee
    {
        public string firstName;
        public string lastName;
        public string position;

        public Employee(string firstName, string lastName, string position)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Position> positions = new List<Position>();
            List<Employee> employees = new List<Employee>();

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string text = Console.ReadLine();
                string[] words = text.Split('-');
                string name = words[0].Trim();

                string priority = words[1].Trim();
                positions.Add(new Position(name, int.Parse(priority)));
            }

            int M = int.Parse(Console.ReadLine());

            for (int i = 0; i < M; i++)
            {
                string text = Console.ReadLine();
                string[] words = text.Split('-');
                string name = words[0].Trim();
                string[] names = name.Split();

                string fname = names[0].Trim();
                string lname = names[1].Trim();

                string position = words[1].Trim();

                employees.Add(new Employee(fname, lname, position));
            }

            List<Employee> emp = (from e in employees
                                  join p in positions on e.position equals p.name
                                  orderby p.priority descending, e.lastName ascending, e.firstName ascending
                                  select e).ToList();
            foreach (Employee e in emp)
            {
                Console.WriteLine(e.firstName.Trim() + " " + e.lastName.Trim());
            }
        }
    }
}