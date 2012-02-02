using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiveDigitNumbers
{
    
//Разглеждаме множеството S от всички петцифрени числа със свойството, 
//    че втората и четвъртата им цифра са равни на сбора на съседните 
//    си цифри. Такива числа са, например, 13264, 45110, 58396 и 77011. 
//    Подреждаме числата от множеството S по големина в нарастващ ред 
//    и ги номерираме с последователни номера 1, 2, 3, ... .
//Напишете програма  number,  която по дадено число от множеството 
//    определя неговия номер. 
//От стандартния вход се въвежда петцифрено число. На стандартния 
//    изход да се изведе номерът на числото. Ако въведеното число 
//    не е от множеството S, като номер да се изведе 0.  


//ПРИМЕРИ

//Вход
//13264  	Вход
//77011	Вход
//16352
//Изход
//24	Изход
//276	Изход
//0

    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            IsPartOfSet(number);
        }
  
        private static int IsPartOfSet(string number)
        {
            int firstDigit = int.Parse(number[0].ToString());
            int secondtDigit = int.Parse(number[1].ToString());
            int thirdDigit = int.Parse(number[2].ToString());
            int fourthDigit = int.Parse(number[3].ToString());
            int fithDigit = int.Parse(number[4].ToString());

            if (secondtDigit == (firstDigit + thirdDigit) && fourthDigit == (thirdDigit + fithDigit))
            {
            	
            }else
            {
                return 0;
            }
        }
    }
}
