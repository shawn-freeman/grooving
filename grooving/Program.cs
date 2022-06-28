// See https://aka.ms/new-console-template for more information
using grooving;

Console.WriteLine("Hello, World!");

var isRunning = true;
DbProvider _dbProvider;

while (isRunning)
{
    _dbProvider = new DbProvider(@"./Dal/database.txt");
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

    //determine option
    switch (menuSelection)
    {
        case 1:
            _dbProvider.Output();
            break;
        case 2:

            break;
        case 3:

            break;
        case 4:

            break;
    }
}

bool IsValidMenuSelection(int selection)
{
    return (selection < 1 || selection > 4);
}