using System;

class Dog
{
    private string name;
    private string breed;

    public Dog()
    { 
        this.name = "Balkan";
        this.breed = "Street excellent";	 
    }

    public Dog(string name, string breed)
    { 
        this.name = name;
        this.breed = breed; 
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    public void SayBau()
    {
        Console.WriteLine("{0} said: Bauuuuuu!", name);
    }
} 
