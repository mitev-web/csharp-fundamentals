using System;

class DogMeeting
{
	static void Main()
	{
		Console.WriteLine("Enter first dog's name: ");
        string dogName = Console.ReadLine();
        Console.WriteLine("Enter first dog's breed: ");
        string dogBreed = Console.ReadLine();
        
        // Use constructor to set the name and breed
        Dog firstDog = new Dog(dogName, dogBreed);

        // Create new dog using the parameterless constructor
        Dog secondDog = new Dog();

		// Use properties to set name and breed
		Console.WriteLine("Enter second dog's name: ");
        secondDog.Name = Console.ReadLine(); 
        Console.WriteLine("Enter second dog's breed: ");
        secondDog.Breed = Console.ReadLine(); 

		// Create a Dog with default name and breed
		Dog thirdDog = new Dog();

		// Save the dogs in an array
		Dog[] dogs = new Dog[] { firstDog, secondDog, thirdDog };

		// Ask each of the dogs to bark
		foreach(Dog dog in dogs)
		{ 
			dog.SayBau(); 
		}
	}
}