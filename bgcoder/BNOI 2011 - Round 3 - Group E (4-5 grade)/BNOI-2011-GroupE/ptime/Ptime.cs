using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Ptime
{
    //    Автор: Кинка Кирилова-Лупанова
    //Пекар смята, че за да получи
    //великденският козунак идеална симетрична
    //форма, трябва да бъде изваден от фурната,
    //когато часовникът показва „палиндромно
    //време” – което се чете еднакво отляво
    //надясно и отдясно наляво.
    //Напишете програма ptime, която по
    //времето на поставяне на козунака във
    //фурната, определя времето, в което е
    //подходящо да бъде изваден от фурната.
    //Вход
    //От първия ред на стандартния вход се въвежда времето на поставяне на козунака
    //във фурната във формат HH:MM.
    //Изход
    //На един ред на стандартния изход програмата трябва да изведе най-близкото
    //„палиндромно време” във формат HH:MM.
    //Ограничения
    //00 ≤ HH ≤ 23
    //00 ≤ MM ≤ 59
    //Пример 1
    //Вход
    //00:00
    //Изход
    //01:10
    //Пример 2
    //Вход
    //12:34
    //Изход
    //13:31
    //Пример 3
    //Вход
    //23:59
    //Изход
    //00:00
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] arr = input.Split(':');
        int hour = int.Parse(arr[0]);
        int minutes = int.Parse(arr[1]);

        string strHour = "";
        string strMinutes = "";


        for (int i = 0; i < 24; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                if(i < 10){
                    strHour = "0"+i;
                }else{
                    strHour = i+"";
                }

                if(j < 10){
                    strMinutes = "0"+j;
                }else{
                    strMinutes = j+"";
                }

                if ((i == hour && j > minutes) || i>hour || (hour == 23 && i == 0))
                {
                    if (IsPalindromTime(strHour, strMinutes))
                    {
                        Console.WriteLine("{0}:{1}", strHour, strMinutes);
                        return;
                    }
   

                }


                
            }
        }
    }

    public static bool IsPalindromTime(string hour, string minutes)
    {
        if (hour == ReverseString(minutes))
        {
            return true;
        }

        return false;
    }

    public static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}