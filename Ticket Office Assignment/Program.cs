﻿// See https://aka.ms/new-console-template for more information
using System.Linq;
using Ticket_Office_Assignment;
string placeList = "";

int placesAvailable = 8000;
while (placesAvailable <= 8000)
{
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("New client:");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.WriteLine("Hello customer!\nIf you want to buy a ticket, please enter your age!");
    string? customerAge = Console.ReadLine();
    Console.WriteLine("Do you want a standing ticket or a seated ticket?");


    bool placeChoise = true;
    string userInput = Console.ReadLine().ToLower();
    if (userInput == "seated")
    {
        placeChoise = false;
    }
    else if (userInput == "standing") 
    {
        placeChoise = true;
    }
    
    Place standingOrSeated = placeChoise ? Place.Standing : Place.Seated;
    

    // Convert string customerAge to int age:
    int age = Convert.ToInt32(customerAge);

    // Return from PriceSetter(age, place):
    int ticketPrice = PriceSetter(age, standingOrSeated);

    // Return from TaxCalculator(ticketPrice):
    decimal ticketTax = TaxCalculator(ticketPrice);

    // Return from TicketNumberGenerator():
    int ticketNumber = TicketNumberGenerator();

    // Convert ticketNumber from int to string:
    string placeNumber = Convert.ToString(ticketNumber);

    // Check if place is available:
    bool checkedTicketNumber = CheckPlaceAvailability(placeList, ticketNumber);

    while (!checkedTicketNumber)
    {
        ticketNumber = TicketNumberGenerator();
        placeNumber = Convert.ToString(ticketNumber);
        checkedTicketNumber = CheckPlaceAvailability(placeList, ticketNumber);
    }
    if (checkedTicketNumber)
    {
        Console.WriteLine($"You are {customerAge} years old and you want to buy a {standingOrSeated} ticket.");
        Console.WriteLine($"Ticket price: " + ticketPrice + " SEK.");
        Console.WriteLine($"Ticket tax: " + ticketTax + ".");
        Console.WriteLine($"Your place number is: " + placeNumber + ".");
        placeList = AddPlace(placeList, placeNumber);
        Console.WriteLine($"Sold places: " + placeList + ".");
    }

    static int PriceSetter(int age, Place standingOrSeated)
    {
        if (age <= 11 &&  standingOrSeated == Place.Seated)
        {
            int price = 50;
            return price;
        }
        else if (age <= 11 && standingOrSeated == Place.Standing)
        {
            int price = 25;
            return price;
        }
        else if (age >= 12 && age <= 64 && standingOrSeated == Place.Seated)
        {
            int price = 170;
            return price;
        }
        else if (age >= 12 && age <= 64 && standingOrSeated == Place.Standing)
        {
            int price = 110;
            return price;
        }
        if (age >= 65 && standingOrSeated == Place.Seated)
        {
            int price = 100;
            return price;
        }
        if (age >= 65 && standingOrSeated == Place.Standing)
        {
            int price = 60;
            return price;
        }
        else
        {
            return 0;
        }
    }

    static decimal TaxCalculator(int ticketPrice)
    {
        decimal tax = Math.Round((decimal)((1 - 1/1.06) * ticketPrice));
        return tax;
    }

    static int TicketNumberGenerator()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 8000);
        return randomNumber;
    }

    static bool CheckPlaceAvailability(string placeList, int ticketNumber)
    {
        return !placeList.Contains((char)ticketNumber);
    }

    static string AddPlace(string placeList, string placeNumber)
    {
        bool a = string.IsNullOrEmpty(placeList);

        if (a)
        {
            string newplaceList = placeNumber;
            return newplaceList;
        }
        else
        {
            string newplaceList = (placeList + ", " + placeNumber);
            return newplaceList;
        }
    }
}