// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Xml.Linq;

Console.WriteLine("Hello, customer!");
Console.WriteLine("What is your age, please?");
string customerAge = Console.ReadLine();

Console.WriteLine("If you want a standing ticket, please type standing, " +
    "else, if you want a seated ticket, please type seated");
string place = Console.ReadLine();
Console.WriteLine($"You are  {customerAge} years old and you want to buy a {place} ticket");

int age = Convert.ToInt32(customerAge);


// Return from PriceSetter(age, place):
int ticketPrice = PriceSetter(age, place);
Console.WriteLine($"Ticket price: " + ticketPrice + "SEK");

// Return from TaxCalculator(ticketPrice):
decimal ticketTax = TaxCalculator(ticketPrice);
Console.WriteLine($"Ticket tax: " + ticketTax);

// Return from TicketNumberGenerator():
int ticketNumber = TicketNumberGenerator();
Console.WriteLine($"Ticket number: " + ticketNumber);


    

// Second way of receiving the return from PriceSetter(age, place) (You can not see the Return here, but it is inside the caller!):
// Console.WriteLine(PriceSetter(age, place));
// Second way of receiving the return from PriceSetter(age, place)
// Console.WriteLine(TaxCalculator(ticketPrice));


static int PriceSetter(int age, string place)
{
    if (age <= 11 && place == "seated")
    {
        int price = 50;
        return price;
    }
    else if (age <= 11 && place == "standing")
    {
        int price = 25;
        return price;
    }
    else if (age >= 12 && age <= 64 && place == "seated")
    {
        int price = 170;
        return price;
    }
    else if (age >= 12 && age <= 64 && place == "standing")
    {
        int price = 110;
        return price;
    }
    if (age >= 65 && place == "seated")
    {
        int price = 100;
        return price;
    }
    if (age >= 65 && place == "standing")
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
    decimal tax = (decimal)((1 - 1/1.06) * ticketPrice);
    return tax;
}

static int TicketNumberGenerator() 
{
    Random random = new Random();
    int randomNumber = random.Next(0, 8000);
    return randomNumber;
}