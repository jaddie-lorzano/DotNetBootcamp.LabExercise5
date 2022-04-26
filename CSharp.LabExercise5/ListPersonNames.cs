using System;

namespace CSharp.LabExercise5.Solution1
{
    static class UserInputValidator
    {
        public static string ValidateUserInput(string firstOrLastName)
        {
            string userFirstNameInput;

            while (true)
            {
                PersonArrayRenderer.GenerateImage();
                Console.Write($"\n  Enter {firstOrLastName}: ");
                userFirstNameInput = Console.ReadLine();

                if (int.TryParse(userFirstNameInput, out _) 
                    || userFirstNameInput == null 
                    || userFirstNameInput.Trim().Equals(""))
                {
                    Console.WriteLine($"  Invalid input. Please enter {firstOrLastName}.\n");
                    continue;
                }
                break;
            }

            return userFirstNameInput;
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }

    class PersonArrayRenderer
    {
        IPersonArrayCreator personArrayCreator;

        public static void GenerateImage()
        {
            Console.Clear();
            string people = @"
                                   .                                  
        .@@@@@@&             .@@@@@@@@@@@.             &@@@@@@.       
      @@@@@@@@@@@@          @@@@@@@@@@@@@@@          @@@@@@@@@@@@     
     %@@@@@@@@@@@@@        (@@@@@@@@@@@@@@@#        @@@@@@@@@@@@@&    
     *@@@@@@@@@@@@@         @@@@@@@@@@@@@@@.        @@@@@@@@@@@@@/    
      .@@@@@@@@@@@           @@@@@@@@@@@@@           @@@@@@@@@@@,     
          %@@@*                /@@@@@@@(                *@@@%         
   @@@@@@&,  ./@@@@@@.    @@@@           @@@@    .@@@@@@/.  ,&@@@@@@  
  @@@@@@@@@@@@@@@@@@    @@@@@@@@@@@@@@@@@@@@@@@    @@@@@@@@@@@@@@@@@@ 
 @@@@@@@@@@@@@@@@@@*   @@@@@@@@@@@@@@@@@@@@@@@@@   *@@@@@@@@@@@@@@@@@@
 @@@@@@@@@@@@@@@@@@   (@@@@@@@@@@@@@@@@@@@@@@@@@/   @@@@@@@@@@@@@@@@@@
 @@@@@@@@@@@@@@@@@@   @@@@@@@@@@@@@@@@@@@@@@@@@@@   @@@@@@@@@@@@@@@@@@
 @@@@@@@@@@@@@@@@@%   @@@@@@@@@@@@@@@@@@@@@@@@@@@   %@@@@@@@@@@@@@@@@@
 @@@@@@@@@@@@@@@@@/   @@@@@@@@@@@@@@@@@@@@@@@@@@@   #@@@@@@@@@@@@@@@@@
  ,@@@@@@@@@@@@@@@*   @@@@@@@@@@@@@@@@@@@@@@@@@@@   (@@@@@@@@@@@@@@@* 
                      #@@@@@@@@@@@@@@@@@@@@@@@@@%                                                                          
            ";
            Console.WriteLine(people);
        }

        public PersonArrayRenderer(IPersonArrayCreator personArrayCreator)
        {
            this.personArrayCreator = personArrayCreator;
        }

        public void RenderPersonArray()
        {
            GenerateImage();
            Person[] person = personArrayCreator.CreateArray();
            Console.WriteLine("\n  Names List:\n");
            for (int i = 0; i < personArrayCreator.NumberOfArrayEntries; i++)
            {
                Console.WriteLine("  {0}.  {1}", (i + 1), person[i].ToString());
            }
        }
    }

    interface IPersonArrayCreator
    {
        public int NumberOfArrayEntries { get; set; }
        public Person[] CreateArray();
    }

    class DefaultPersonArrayCreator : IPersonArrayCreator
    {
        public int NumberOfArrayEntries { get; set; }

        public DefaultPersonArrayCreator(int numberOfArrayEntries)
        {
            this.NumberOfArrayEntries = numberOfArrayEntries;
        }

        public Person[] CreateArray()
        {
            Person[] person = new Person[this.NumberOfArrayEntries];

            for (int i = 0; i < this.NumberOfArrayEntries; i++)
            {
                string firstName = UserInputValidator.ValidateUserInput("first name");
                string lastName = UserInputValidator.ValidateUserInput("last name");
                Console.Clear();

                person[i] = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                };
            }
            return person;
        }
    }

    class ListPersonNames
    {
        public ListPersonNames()
        {
            IPersonArrayCreator defaultPersonArrayCreator = new DefaultPersonArrayCreator(3); // length of array = 3
            PersonArrayRenderer personArrayRenderer = new PersonArrayRenderer(defaultPersonArrayCreator);
            personArrayRenderer.RenderPersonArray();

            Console.Write("\nPress any key to return...");
            Console.ReadKey();

            MainMenu myMainMenu = new MainMenu();
            myMainMenu.Start();
        }
    }
}
