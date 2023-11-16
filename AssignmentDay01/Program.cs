using Assignment;

Console.WriteLine("= = = = = Console App to Get Fibonacci Series = = = = =\n");

// reading the number of terms
Console.Write("Enter the Number of Terms in the Fibonacci Series: ");
string? str_terms = Console.ReadLine();
if (int.TryParse(str_terms, out int int_terms))
{
    if (int_terms <  1) Console.WriteLine("\nERROR: Number of Terms must be 1 or greater.");
    else 
    if (int_terms > 90) Console.WriteLine("\nERROR: Number of Terms not supported, the value informed overload the results.");
    else
    {
        // getting the Fibonacci Series
        var fibonacci = new Fibonacci();
        var fibseries = fibonacci.GetSeries(int_terms);

        // printing the resulting series
        bool firstPrinted = false;
        Console.Write("\nFibonacci series up to 10 terms: ");
        foreach (var i in fibseries)
        {
            if (firstPrinted)
            {
                Console.Write(", {0}", i);
            }
            else
            {
                Console.Write("{0}", i);
                firstPrinted = true;
            }
        }
        Console.WriteLine();
    }
} 
else
{
    Console.WriteLine("\nERROR: Number of Terms must be integer.");
}

Console.WriteLine("\n= = = = = Execution Finished = = = = =\n");