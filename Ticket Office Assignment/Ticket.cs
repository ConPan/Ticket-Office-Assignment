using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ticket_Office_Assignment.Ticket;

namespace Ticket_Office_Assignment
{
    public class Ticket
    {
        public int Age { get; set; }
        public Ticket_Office_Assignment.Place Choice { get; set; }
        public int Number { get; set; }

       
        // public Ticket myConstructor = new Ticket(24, Ticket_Office_Assignment.Place.Seated);

        // Constructor with int Age and enum Place
        public Ticket(int age, Ticket_Office_Assignment.Place choice)
        {
            Age = age;
            Choice = choice;
            Number = Ticket_Office_Assignment.App.TicketNumberGenerator();
        }


        public int Price()
        {
            if (Age <= 11 && Choice == Place.Seated)
            {
                int price = 50;
                return price;
            }
            else if (Age <= 11 && Choice == Place.Standing)
            {
                int price = 25;
                return price;
            }
            else if (Age >= 12 && Age <= 64 && Choice == Place.Seated)
            {
                int price = 170;
                return price;
            }
            else if (Age >= 12 && Age <= 64 && Choice == Place.Standing)
            {
                int price = 110;
                return price;
            }
            if (Age >= 65 && Choice == Place.Seated)
            {
                int price = 100;
                return price;
            }
            if (Age >= 65 && Choice == Place.Standing)
            {
                int price = 60;
                return price;
            }
            else
            {
                return 0;
            }
        } // public int Price()

        public decimal Tax()
        {

            int answerFromPrice = Price();

            decimal tax = Math.Round((decimal)((1 - 1/1.06) * answerFromPrice));
            return tax;
        }



    }

}