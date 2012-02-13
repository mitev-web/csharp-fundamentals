using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Numerics;



namespace _3Tubes
{

    class Tubes
    {

        static void Main(string[] args)
        {

            int tubesNumber = int.Parse(Console.ReadLine());

            int friends = int.Parse(Console.ReadLine());

            int[] tubes = new int[tubesNumber];

            for (int i = 0; i < tubesNumber; i++)
            {

                tubes[i] = int.Parse(Console.ReadLine());

            }



            BigInteger totalLenght = 0;

            for (int i = 0; i < tubesNumber; i++)
            {

                totalLenght = totalLenght + tubes[i];

            }

            if (friends != 0)
            {

                BigInteger bestLenght = totalLenght / friends;



                if (bestLenght != 0)
                {



                    BigInteger existingTubes = 0;



                    for (int i = 0; i < tubesNumber; i++)
                    {

                        existingTubes = existingTubes + tubes[i] / bestLenght;

                    }



                    while (existingTubes != friends)
                    {

                        existingTubes = 0;

                        bestLenght = bestLenght - 1;

                        for (int i = 0; i < tubesNumber; i++)
                        {

                            existingTubes = existingTubes + tubes[i] / bestLenght;

                        }

                    }



                    Console.WriteLine(bestLenght);

                }

                else
                {

                    Console.WriteLine(0);

                }

            }

            else
            {

                int longesttube = tubes.Max();

                Console.WriteLine(longesttube);

            }

        }

    }

}