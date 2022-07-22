using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        public static Random rng = new Random();
        public static bool cont = true;
        public static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! " +
                "\nWould you like to generate a random activity? yes/no: ");
            string userinput = Console.ReadLine();
            if (userinput.ToLower() == "yes")
            {
                cont = true;
            }
            else
            {
                cont = false;
                Environment.Exit(0);
            }
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            int userAge = 0;
            do
            {
                Console.Write("What is your age? ");
                _ = int.TryParse(Console.ReadLine(), out userAge);
                if (userAge >= 0)
                {
                    break;
                }
            } while (true);

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? sure/No thanks: ");
            string userSeeList = Console.ReadLine();
            bool seeList = false;
            if (userSeeList.ToLower() == "sure")
            {
                seeList = true;
            }
            else
            {
                seeList = false;

            }
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
            }
            Console.WriteLine();
            Console.Write("Would you like to add any activities before we generate one? yes/no: ");
            string userAddToList = Console.ReadLine();
            bool addToList = false;
            if (userAddToList.ToLower() == "yes")
            {
                addToList = true;
            }
            else
            {
                addToList = false;
            }
            Console.WriteLine();
            while (addToList == true)
            {
                Console.Write("What would you like to add? ");
                string userAddition = Console.ReadLine();
                activities.Add(userAddition);
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");

                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.WriteLine("Would you like to add more? yes/no: ");
                addToList = bool.Parse(Console.ReadLine());
            }


            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    cont = true;
                    continue;

                }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}!" +
                      $" Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                string userAnswer = (Console.ReadLine());
                if (userAnswer.ToLower() == "keep")
                {
                    cont = false;
                    Console.WriteLine(" Enjoy the activity!");
                }
                else if (userAnswer.ToLower() == "redo")
                {
                    cont = true;
                    {
                        Console.WriteLine("Choosing a new activity for you.");
                    }
                }
                else
                {
                    Console.WriteLine("I don't understand your input? Goodbye.");
                    cont = false;
                }
            }
        }
    }
}

