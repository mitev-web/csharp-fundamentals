using System;

class DogMeeting
{
	static void Main()
	{
		Console.WriteLine("Enter first dog's name: ");
        string dogName = Console.ReadLine();
        Console.WriteLine("Enter first dog's breed: ");
        string dogBreed = Console.ReadLine();
        
        // Using constructor to set name and breed
        Dog firstDog = new Dog(dogName, dogBreed);

        // Create new dog using the parameterless constructor
        Dog secondDog = new Dog();
        
        Console.WriteLine("Enter second dog's name: ");
        dogName = Console.ReadLine(); 
        Console.WriteLine("Enter second dog's breed: ");
        dogBreed = Console.ReadLine(); 
        
        // Using properties to set name and breed
        secondDog.Name = dogName;
        secondDog.Breed = dogBreed;

        // Creating Dog with default name and breed
		Dog thirdDog = new Dog();

		Dog[] dogs = new Dog[] { firstDog, secondDog, thirdDog };

		foreach(Dog dog in dogs)
		{ 
			dog.SayBau(); 
		}
	}
}