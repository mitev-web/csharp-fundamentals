using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class FighterJet
{
    static void Main(string[] args)
    {
        int px1, px2, py1, py2, fx, fy, d;
        px1 = int.Parse(Console.ReadLine());
        py1 = int.Parse(Console.ReadLine());
        px2 = int.Parse(Console.ReadLine());
        py2 = int.Parse(Console.ReadLine());
        fx = int.Parse(Console.ReadLine());
        fy = int.Parse(Console.ReadLine());
        d = int.Parse(Console.ReadLine());


        int xTarget = fx + d;
        int yTarget = fy;


        if (px1 > px2)
        {
            int swapValue = px1;
            px1 = px2;
            px2 = swapValue;
        }
        if (py1 > py2)
        {
            int swapValue = py1;
            py1 = py2;
            py2 = swapValue;
        }
        int damage = 0;
        if (xTarget >= px1 && xTarget <= px2 && yTarget >= py1 && yTarget <= py2)
        {
            damage += 100;
        }
        if (xTarget + 1 >= px1 && xTarget + 1 <= px2 && yTarget >= py1 && yTarget <= py2)
        {
            damage += 75;
        }
        if (xTarget >= px1 && xTarget <= px2 && yTarget + 1 >= py1 && yTarget + 1 <= py2)
        {
            damage += 50;
        }
        if (xTarget >= px1 && xTarget <= px2 && yTarget - 1 >= py1 && yTarget - 1 <= py2)
        {
            damage += 50;
        }
        Console.WriteLine(damage + "%");

    }
}

