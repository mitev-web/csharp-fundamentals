﻿using System;
using System.Linq;

class Words
{
        //    Задача Е4. ДУМИ
        //Автор: Бистра Танева
        //Първокласниците вече са грамотни и могат да пишат думички с латински букви.
        //Госпожата им диктува думи и тяхната задача е да определят най-дългата дума. Вие
        //може да помогнете, като напишете програма words, която намира най-дългата дума и
        //броя на буквите в нея.
        //Ако има няколко най-дълги думи, програмата да изведе думата, чиято първа
        //буква е по-напред в азбуката. Ако и тези думи са няколко, програмата да изведе
        //първата от тях по реда на въвеждането им.
        //Вход
        //От единствения ред на стандартния вход се въвеждат думи, разделени с поне
        //един интервал.
        //Изход
        //Програмата извежда на единствения ред на стандартния изход броя на буквите
        //на най-дългата дума, както и самата дума, разделени с един интервал.
        //Ограничения
        //Думите се изписват само с малки латински букви.
        //Броят на зададените символи не надхвърля 100.
        //Пример
        //Вход
        //oko banan liniq more
        //Изход
        //5 banan


    static void Main(string[] args)
    {
        string[] words = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);


        string longest = "";

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > longest.Length)
            {
                longest = words[i];
            }
            else if (words[i].Length == longest.Length)
            {
                if (words[i].CompareTo(longest) < 0)
                {
                    longest = words[i];
                }
            }
        }

        Console.WriteLine("{0} {1}",longest.Count(),longest);
    }

    

}