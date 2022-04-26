using System;
using System.Threading;

namespace CSharp.LabExercise5.Solution4
{
    internal class DriveVehicle
    {
        public void Start()
        {
            RunMainMenu();
            Drive();
            Console.ReadLine();
        }
        private static void RunMainMenu()
        {
            string prompt = @"

________       _____                                  
___  __ \_________(_)__   ______                      
__  / / /_  ___/_  /__ | / /  _ \                     
_  /_/ /_  /   _  / __ |/ //  __/                     
/_____/ /_/    /_/  _____/ \___/                      
                                                      
            ___    __    ______ _____      ______     
______ _    __ |  / /_______  /____(_)________  /____ 
_  __ `/    __ | / /_  _ \_  __ \_  /_  ___/_  /_  _ \
/ /_/ /     __ |/ / /  __/  / / /  / / /__ _  / /  __/
\__,_/      _____/  \___//_/ /_//_/  \___/ /_/  \___/ 
                                                      
";
            string[] options = { "Drive", "Exit Program" };
            Menu mainMenu = new Menu(prompt, options);
            int SelectedIndex = mainMenu.Run();


            switch (SelectedIndex)
            {
                case 0:
                    Car car = new Car();
                    break;
                case 1:
                    MainMenu myMainMenu = new MainMenu();
                    myMainMenu.Start();
                    break;
            }
            Console.ReadKey();
            DriveVehicle driveVehicle = new DriveVehicle();
            driveVehicle.Start();
        }
        public static void Drive()
        {
            _ = new Car();
        }
    }
    interface IVehicle
    {
        void Drive();
        bool Refuel(int amount);
    }

    public class Car : IVehicle
    {
        public int Fuel { get; set; }
        public Car()
        {
            Drive();
        }
        public Car(int fuel)
        {
            this.Fuel = fuel;
        }
        public void Drive()
        {
            if (this.Fuel == 0)
            {
                AskToGetFuel();
                Drive();
            }
            if (Fuel > 0)
            {
                while(Fuel > 0)
                {
                    Console.Clear();
                    Console.WriteLine(@"                                     
                                       ,&@&&&&&&&&@&/                           
                                 &&&                      *&&&&                 
                           /&&,                                     .#%.        
                 /@&%(                                   .#@%,                  
           ,%&.  (@&&@,                             &@.     /@&&@*        /     
        @&    &,        @%                      %&.      @(        #@     %     
     /%      @            &                             &            &  .,%     
      %     /#            &*,***,***************,,**,,**@            @,         
             &/          &,                             %%          &(          
               &@,    #&*                                 %&/    (&#            
                                                                      
");
                    Console.WriteLine("The car is driving");
                    Fuel--;
                    Console.WriteLine($"The fuel amount is {Fuel}");
                    Thread.Sleep(1000);
                }
                Drive();
            }
        }
        public bool Refuel(int amount)
        {
            this.Fuel += amount;
            Console.WriteLine(
                $"Refueled {amount}. " +
                $"Your fuel now is {this.Fuel}. " +
                $"You may now proceed driving..\n");
            Console.ReadKey();
            Drive();
            if (this.Fuel >= 0) return true;
            return false;
        }
        public void AskToGetFuel()
        {
            Console.WriteLine("You are out of fuel.");
            Console.WriteLine("Would you like to Refuel? [y/n]");
            string answer = Console.ReadLine();
            while (true)
            {
                if (answer.ToLower() == "y")
                {
                    int fuelAmount = EnterFuelAmount();
                    Refuel(fuelAmount);
                    Drive();
                }
                if (answer.ToLower() == "n")
                {
                    DriveVehicle driveVehicle = new DriveVehicle();
                    driveVehicle.Start();
                }
            }
        }
        public static int EnterFuelAmount()
        {
            Console.Write("Enter the amount of Fuel: ");
            int fuelAmount = Convert.ToInt32(Console.ReadLine());
            return fuelAmount;
        }
    }
}
