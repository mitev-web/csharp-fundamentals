using System;

class AbstractClasses
{
    static void Main()
    {
        Turtle turtle = new Turtle();
        Console.WriteLine("The {0} can go {1} km/h ", 
            turtle.GetName(), turtle.Speed);
        Cheetah cheetah = new Cheetah();
        Console.WriteLine("The {0} can go {1} km/h ", 
            cheetah.GetName(), cheetah.Speed);

        System.Collections.Generic.List<int> l;
        System.DateTime dt;
    }
}
