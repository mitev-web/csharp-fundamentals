using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task11
{
    class Program
    {

     //* Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
    //0 ? "Zero"
    //273 ? "Two hundred seventy three"
    //400 ? "Four hundred"
    //501 ? "Five hundred and one"
    //711 ? "Severn hundred and eleven"


      static void Main(string[] args)
        {
            int number;
            Start:
            Console.Write("enter a number between 0 and 999: ");
            string line = Console.ReadLine();
            int.TryParse(line, out number);

            if (number < 0 || number > 999)
            {
                Console.WriteLine("number not within range");
                goto Start;
            }
            else
            {
                SpellNumber(number);
            }

        }

      public static void SpellNumber(int number)
      {
          bool isTeen = false;
          if (number == 0) Console.WriteLine("zero");

          switch (number / 100)
          {
              case 1: Console.Write("one hundred "); break;
              case 2: Console.Write("two hundred "); break;
              case 3: Console.Write("three hundred "); break;
              case 4: Console.Write("four hundred "); break;
              case 5: Console.Write("five hundred "); break;
              case 6: Console.Write("six hundred "); break;
              case 7: Console.Write("seven hundred "); break;
              case 8: Console.Write("eight hundred "); break;
              case 9: Console.Write("nine hundred "); break;
          }


          switch (number % 100 / 10)
          {
              case 1:
                  isTeen = true;
                  switch (number % 10)
                  {
                      case 0: Console.WriteLine("ten"); break;
                      case 1: Console.WriteLine("eleven"); break;
                      case 2: Console.WriteLine("twelve"); break;
                      case 3: Console.WriteLine("thirteen"); break;
                      case 4: Console.WriteLine("fourteen"); break;
                      case 5: Console.WriteLine("fifteen"); break;
                      case 6: Console.WriteLine("sixteen"); break;
                      case 7: Console.WriteLine("seventeen"); break;
                      case 8: Console.WriteLine("eighteen"); break;
                      case 9: Console.WriteLine("nineteen"); break;
                  }
                  break;
              case 2: Console.Write("and twenty "); break;
              case 3: Console.Write("and thirty "); break;
              case 4: Console.Write("and forty "); break;
              case 5: Console.Write("and fifty "); break;
              case 6: Console.Write("and sixty "); break;
              case 7: Console.Write("and seventy "); break;
              case 8: Console.Write("and eighty "); break;
              case 9: Console.Write("and ninety "); break;
          }

          if (!isTeen)
          {
              switch (number % 10)
              {
                  case 1: Console.WriteLine("one"); break;
                  case 2: Console.WriteLine("two"); break;
                  case 3: Console.WriteLine("three"); break;
                  case 4: Console.WriteLine("four"); break;
                  case 5: Console.WriteLine("five"); break;
                  case 6: Console.WriteLine("six"); break;
                  case 7: Console.WriteLine("seven"); break;
                  case 8: Console.WriteLine("eight"); break;
                  case 9: Console.WriteLine("nine"); break;
              }
          }

      }
    }
 }

