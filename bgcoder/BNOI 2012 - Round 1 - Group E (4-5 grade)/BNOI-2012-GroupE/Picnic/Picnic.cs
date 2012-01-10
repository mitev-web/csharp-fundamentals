using System;
using System.Linq;

class Picnic
    {


        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string[] numbers = input.Split(new string[] { " " },
        StringSplitOptions.None);


            int k = int.Parse(numbers[0]);
            int l = int.Parse(numbers[1]);
            int ml = int.Parse(numbers[2]);


            if(k < 1 || k > 26 || l > 20 || l < 0 || ml < 0 || ml > 1000){
                return;
            }

            double val =  Convert.ToDouble(ml) / 1000;
            val += Convert.ToDouble(l);

            double answer = 0;
            answer = (Convert.ToDouble(k) * 0.4) / val;

            if (answer != Math.Round(answer))
            {
                answer = Math.Floor(answer) + 1;
            }

            Console.WriteLine(Convert.ToInt32(answer));
   
        }
    }
