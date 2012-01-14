﻿//    Комисар Боби получава съобщения от таен агент ХХ7. Той разчита кода, но
//ръчното дешифриране на съобщението е твърде дълго и досадно. Комисар Боби би
//желал да използва програма, която да дешифрира съобщенията бързо и точно.
//Напишете програма message, която по зададена кодова таблица, дешифрира
//получено съобщение.
//Вход
//От първия ред на стандартния вход се въвежда едно цяло число N – дължината
//на кодовата таблица. От следващите N реда се въвеждат по два символа, разделени с
//един интервал. Първият символ е от декодираното съобщение, а вторият – съответният
//му символ от кодираното съобщение. От последния ред се въвежда полученото
//съобщение.
//Изход
//На единствения ред на стандартния изход програмата трябва да изведе
//декодираното съобщение.
//Ограничения
//В съобщенията и кодовата таблица могат да участват само главни латински
//букви, цифри, интервали и знаците: равно (=), по-малко (<), по-голямо (>), точка (.),
//запетая (,) и удивителен знак (!).
//Дължината на полученото съобщение не надхвърля 80 символа.
//Пример
//Вход
//15
//A 5
//B B
//C 4
//D Q
//F
//I L
//J T
//K
//M 7
//E Z
//N 8
//5 >
//. X
//9 E
//O Y
//4Y7ZFL8
//Изход
//COME IN


using System;
using System.Collections.Generic;
using System.Linq;

class HiddenMessage
{

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());

        List<char> coded = new List<char>();
        List<char> uncoded = new List<char>();

        for (int i = 0; i < N; i++)
        {
            string input = Console.ReadLine();
            uncoded.Add(input[0]);
            coded.Add(input[2]);
        }

        string codedMessage = Console.ReadLine();

        foreach (char c in codedMessage)
        {
            Console.Write(uncoded[coded.IndexOf(c)]);
        }
    }
}