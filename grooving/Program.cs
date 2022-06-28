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
            OnOutput();
            break;
        case 2:
            OnInsert();
            break;
        case 3:
            OnUpdate();
            break;
        case 4:
            OnDelete();            
            break;
    }
}

bool IsValidMenuSelection(int selection)
{
    return (selection < 1 || selection > 4);
}

void OnOutput()
{
    Console.WriteLine();
    var employees = _dbProvider.GetEmployeeRecords();
    foreach (var employee in employees)
    {
        Console.WriteLine($"{employee.Id} {employee.Name} {employee.JobTitle}");
    }

    Console.WriteLine();
}

void OnInsert()
{
    Console.Write("Enter employee's name: ");
    var name = Console.ReadLine();
    Console.Write("Enter employee's job title: ");
    var title = Console.ReadLine();

    _dbProvider.Insert(name, title);

    Console.WriteLine("New Employee Inserted.");
}

void OnUpdate()
{
    Console.Write("Enter the ID of the employee to update: ");
    int id = 0;
    while (!Int32.TryParse(Console.ReadLine(), out id))
    {
        Console.Write("Enter the ID of the employee to update: ");
    }

    Console.Write("Enter employee's name: ");
    var name = Console.ReadLine();
    Console.Write("Enter employee's job title: ");
    var title = Console.ReadLine();

    _dbProvider.Update(id, name, title);

    Console.WriteLine($"Employee Updated.\r");
}

void OnDelete()
{
    Console.Write("Enter the ID of the employee to delete: ");
    int deleteId = 0;
    while (!Int32.TryParse(Console.ReadLine(), out deleteId))
    {
        Console.Write("Enter the ID of the employee to delete: ");
    }

    _dbProvider.Delete(deleteId);

    Console.WriteLine($"Employee Deleted.\r");
}