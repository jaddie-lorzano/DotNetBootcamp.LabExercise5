# DotNetBootcamp.LabExercise5

1. Create a C# program that requests three names of people from the user and stores them in an array of objects of type Person. To do this, first create a Person class that has a `Name` property of type string and override the `ToString()` method.

    End the program by reading people and executing the `ToString()` method on the screen.

2. Create a new C# project with three classes plus another class to test the logic in your code. The main classes of the program are the following classes:
    - `Person`
    - `Student`
    - `Professor`

    The `Student` and `Teacher` classes inherit from the `Person` class.
The `Student` class will include a public `Study()` method that will write I'm studying on the screen.
The `Person` class must have two public methods `Greet()` and `SetAge(int age)` that will assign the age of the person.

    The `Teacher` class will include a public `Explain()` method that will write I'm explaining on the screen. 
    
    Also create a public method `ShowAge()` in the `Student` class that writes `My age is: x years old` on the screen.

    You must create another test class called `StudentProfessorTest` with a `Main` method to do the following:
      - Create a `new Person` and make him say hello
      - Create a `new Student`, set an age, say hello, and display her age on the screen.
      - Create a `new Teacher`, set an age, say hello and start the explanation.

3. Create a C# program that prompts the user for three names of people and stores them in an array of Person-type objects. There will be two people of the `Student` type and one person of the `Teacher` type.

    To do this, create a `Person` class that has a `Name` property of type string, a constructor that receives the name as a parameter and overrides the `ToString()` method.

    Then create two more classes that inherit from the `Person` class, they will be called `Student` and `Teacher`. The `Student` class has a `Study()` method that writes by console that the student is studying. The `Teacher` class will have an `Explain()` method that writes to the console that the teacher is explaining. 
    
    Remember to also create two constructors on the child classes that call the parent constructor of the `Person` class.
    
    End the program by reading the people (the teacher and the students) and execute the `Explain()` and `Study()` methods.

4. Create a C# program that implements an `IVehicle` interface with two methods, one for `Drive()` of type void and another for `Refuel()` of type bool that has a parameter of type integer with the amount of gasoline to refuel. Then create a `Car` class with a builder that receives a parameter with the car's starting gasoline amount and implements the `Drive()` and `Refuel()` methods of the car.

    The `Drive()` method will print on the screen that the car is Driving, if the gasoline is greater than 0. 
    The `Refuel()` method will increase the gasoline of the car and return true.
    
    To carry out the tests, create an object of type `Car` with 0 of gasoline in the Main of the program and ask the user for an amount of gasoline to refuel, finally execute the `Drive()` method of the car.

5. Create a C# program that implements an abstract class `Animal` that has a `Name` property of type text and three methods `SetName(string name)`, `GetName()` and `Eat()`. The `Eat()` method will be an abstract method of type void.

    You will also need to create a `Dog` class that implements the above `Animal` class and the `Eat()` method that says the dog is Eating.

    To test the program ask the user for a dog name and create a `new Dog` type object from the `Main` of the program, give the `Dog` object a name, and then execute the `GetName()` and `Eat()` methods.


