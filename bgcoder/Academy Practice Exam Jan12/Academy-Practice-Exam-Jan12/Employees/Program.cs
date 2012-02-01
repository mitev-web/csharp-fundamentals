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
                string[] names = name.Split(' ');

                string fname = names[0];
                string lname = names[1];

                string position = words[1].Trim();


                employees.Add(new Employee(fname, lname, position));
            }


               
            
            //positions.Add(new Position("Trainee", 0));
            //positions.Add(new Position("Owner", 100));
            //positions.Add(new Position("CEO", 98));
            //positions.Add(new Position("Junior Developer", 30));
            //positions.Add(new Position("Unit Manager", 95));
            //positions.Add(new Position("Project Manager", 95));
            //positions.Add(new Position("Team Leader", 94));
            //positions.Add(new Position("Senior Developer", 50));
            //positions.Add(new Position("Developer", 40));
            //employees.Add(new Employee("Georgi","Georgiev", "Trainee"));
            //employees.Add(new Employee("Ademar","Júnior", "Unit Manager"));
            //employees.Add(new Employee("Dimitar","Dimitrov", "Owner"));
            //employees.Add(new Employee("Petar","Atanasov", "Project Manager"));
            //employees.Add(new Employee("Atanas","Georgiev", "Trainee"));
            //employees.Add(new Employee("Júnior","Moraes", "Trainee"));
            //employees.Add(new Employee("Ivan","Bandalovski", "Developer"));
            //employees.Add(new Employee("Apostol","Popov", "Developer"));
            //employees.Add(new Employee("Michel","Platini", "CEO"));
            //employees.Add(new Employee("Blagoy","Makendzhiev", "CEO"));

            List<Employee> emp = (from e in employees
                                  join p in positions
                                  on e.position equals p.name
                                  orderby p.priority descending, e.lastName ascending, e.firstName ascending
                                  select e).ToList();
            foreach (Employee e in emp)
            {
                Console.WriteLine(e.firstName + " " + e.lastName);
            }
        }
    }
}