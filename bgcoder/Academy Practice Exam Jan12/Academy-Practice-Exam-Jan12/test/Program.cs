using System;
public class MyClass
{
    public static void TestRef(ref char i)
    {

        i = 'b';
    }

    public static void TestNoRef(char i){

        i = 'c';
    }


    public static void Main()
    {

        char i = 'a';
        TestRef(i);
        Console.WriteLine(i);



        //TestNoRef(i);
        //Console.WriteLine(i);
    }
}