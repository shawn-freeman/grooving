// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var isRunning = true;

while (isRunning)
{
    
    Console.WriteLine("1. Output Employee Records");
    Console.WriteLine("2. Insert Employee Record");
    Console.WriteLine("3. Update Employee Record");
    Console.WriteLine("4. Delete Employee Record");
    Console.Write("Enter Number Selection: ");


    int menuSelection = 0;

    while (IsValidMenuSelection(menuSelection))
    {
        var validSelection = Int32.TryParse(Console.ReadLine(), out menuSelection);

        if (!validSelection || IsValidMenuSelection(menuSelection))
        {
            Console.Write("Enter Number Selection: ");
        }
    }

    Console.WriteLine($"Selected {menuSelection}");
}

bool IsValidMenuSelection(int selection)
{
    return (selection < 1 || selection > 4);
}