using BookstoreSystem;
using System.Collections.Generic;
using System.Numerics;

// === === === === === === ===

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("= = = = = Welcome to the Online Bookstore = = = = =\n");

// reading the customer name
string CustomerName = AskUser("Enter Your Name (Customer Name): ");

Bookstore TheBookstore = new Bookstore();
Order     TheOrder     = new Order(CustomerName);
List<String> MenuOptions = DisplayMenu();
List<String> BookOptions = new List<String>();
while (true)
{
    string MenuOption = AskUser("Enter your menu choice: ", MenuOptions);
    if (MenuOption == MenuOptions.Last()) break;

    // if chosen option is Browse Books ...
    if (MenuOption == "1")
    {
        BookOptions.Add("0");
        BookOptions.AddRange(TheBookstore.DisplayInventory());
    }

    // if chosen option is Add Books to Cart ...
    if (MenuOption == "2")
    {
        if (BookOptions.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please browse books before to add one.");
        } 
        else
        {
            string OptionChosenStr = AskUser("Enter the book number to add to your cart (0 to go back): ", BookOptions);
            int    OptionChosenInt = int.Parse(OptionChosenStr);
            if (OptionChosenInt == 0)
            {
                Console.WriteLine("No book added to your cart.");
            }
            else
            {
                Book BookChosen = TheBookstore.FetchBook(OptionChosenInt);
                TheOrder.AddOrderedBook(BookChosen);
                Console.WriteLine($"Book \"{BookChosen.GetTitle()}\" added to your cart.");
            }
        }
    }

    // if chosen option is Apply Discounts ...
    if (MenuOption == "3")
    {
        if (!TheOrder.hasBooks())
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please add books to the cart before to apply discounts.");
        }
        else
        {
            string PreviousMessage = TheOrder.GetDiscout() == 0 ? string.Empty : "This entry will overwrite the previous discount.\n";
            List<String> DiscountOptions = new List<String>() { "0", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            string OptionChosenStr = AskUser(PreviousMessage+"Enter discount percentage (5 to 20, or 0 to cancel): ", DiscountOptions);
            int    OptionChosenInt = int.Parse(OptionChosenStr);
            TheOrder.SetDiscout(OptionChosenInt);
            Console.WriteLine(OptionChosenInt == 0 ? "No discount applied to your order." : $"Discount of {TheOrder.GetDiscout()}% applied to your order.");
        }
    }

    // if chosen option is View Order ...
    if (MenuOption == "4")
    {
        if (!TheOrder.hasBooks())
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please add books to the cart before to view order.");
        }
        else
        {
            TheOrder.DisplayOrderDetails();
        }
    }

    Console.WriteLine();
}

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"""

    = = = = = Exiting Online Bookstore = = = = ="
    = = = = = Thank you {CustomerName} for shopping with us = = = = =
    """);
Console.ForegroundColor = ConsoleColor.White;

// === === === === === === ===

List<String> DisplayMenu()
{
    Console.ForegroundColor = ConsoleColor.Red;
    string TextToWrite = """

                BOOKSTORE MENU
                1. Browse Books
                2. Add Books to Cart
                3. Apply Discounts
                4. View Order
                5. Exit

                """;
    Console.WriteLine(TextToWrite);
    return new List<String> { "1", "2", "3", "4", "5" };
}

string AskUser(string question, List<String>? AllowedValueList = null)
{
    string? input = String.Empty;
    while (String.IsNullOrEmpty(input))
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(question);
        Console.ForegroundColor = ConsoleColor.White;
        input = Console.ReadLine();
        if (String.IsNullOrEmpty(input))
        {
            Console.WriteLine("Please enter a valid value.");
        }
        else if ( AllowedValueList != null 
             &&  !AllowedValueList.Contains(input)) 
        {
            Console.WriteLine("Please enter a valid value.");
            input = null;
        }
    }
    return input.Trim();
}