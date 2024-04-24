using Microsoft.EntityFrameworkCore;
using UserContext;
using UserData;

using (Context context = new Context())
{
    context.Database.EnsureCreated();
}

while (true)
{
    DisplayMenu();
    string input = Console.ReadLine();
    Console.Clear();

    switch (input)
    {
        case "1":
            CreateAndPrintUserArray();
            break;
        case "2":
            CreateAndPrintUserList();
            break;
        case "3":
            CreateAndPrintUserDictionary();
            break;
        case "4":
            Console.WriteLine("You entered four. Exiting the program...");
            return;
        default:
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3, or type '4' to quit.");
            break;
    }
}

static void DisplayMenu()
{
    Console.Out.WriteLine("Welcome to the Data Collection Tool!" +
                          "\n\nPlease choose an option:" +
                          "\n1. Create a list of users" +
                          "\n2. Create an array" +
                          "\n3. Create a dictionary" +
                          "\n4. Exit" +
                          "\n\nEnter the corresponding number for your choice (1/2/3/4):");
}

static void CreateAndPrintUserArray()
{
    InsertUsers(CreateUsersArray());
    PrintUsers(CreateUsersArray());
}

static void CreateAndPrintUserList()
{
    InsertUsers(CreateUsersList());
    PrintUsers(CreateUsersList());
}

static void CreateAndPrintUserDictionary()
{
    PrintUsersDictionary(CreateUsersDictionary());
}

static User[] CreateUsersArray()
{
    User[] usersArray = new User[5];

    usersArray[0] = new User { Id = 01, FirstName = "Emily", LastName = "Johnson", Role = Role.Barista };
    usersArray[1] = new User { Id = 02, FirstName = "Benjamin", LastName = "Smith", Role = Role.Dishwasher };
    usersArray[2] = new User { Id = 03, FirstName = "Olivia", LastName = "Williams", Role = Role.Cashier };
    usersArray[3] = new User { Id = 04, FirstName = "Ethan", LastName = "Brown", Role = Role.Chef };
    usersArray[4] = new User { Id = 05, FirstName = "Ava", LastName = "Davis", Role = Role.Server };

    Console.WriteLine("Users created \n");
    return usersArray;
}

static List<User> CreateUsersList()
{
    List<User> usersList = new List<User>
    {
                new User { Id = 05, FirstName = "William", LastName = "Turner", Role = Role.Barista },
                new User { Id = 06, FirstName = "Emma", LastName = "Thompson ", Role = Role.Dishwasher },
                new User{Id = 07, FirstName = "Lucas", LastName = "Harris", Role = Role.Cashier},
                new User{Id = 08, FirstName = "Chloe", LastName = "White", Role = Role.Chef},
                new User{Id = 09, FirstName = "Jacob", LastName = "Martin", Role = Role.Server}
            };

    Console.WriteLine("Users created \n");
    return usersList;
}

static Dictionary<string, User> CreateUsersDictionary()
{
    Dictionary<string, User> usersDictionary = new Dictionary<string, User>
    {
                { "01", new User { Id = 10, FirstName = "Sophia", LastName = "Robinson", Role = Role.Barista } },
                { "02", new User { Id = 11, FirstName = "Daniel", LastName = "Clarke", Role = Role.Dishwasher } },
                { "03", new User{Id = 12, FirstName = "Lily", LastName = "Taylor", Role = Role.Cashier} },
                { "04", new User{Id = 13, FirstName = "Noah", LastName = "Hall", Role = Role.Chef} },
                { "05", new User{Id = 14, FirstName = "Mia", LastName = "Mitchell", Role = Role.Server} }
            };

    Console.WriteLine("Users created \n");
    return usersDictionary;
}

static void PrintUsers<T>(IEnumerable<T> collection) where T : User
{
    foreach (var user in collection)
    {
        Console.WriteLine($"ID: {user.Id}, Name: {user.FirstName} {user.LastName}, Role: {user.Role}");
    }

    Console.ReadLine();
    Console.Clear();
}

static void PrintUsersDictionary(Dictionary<string, User> userDictionary)
{
    foreach (var kvp in userDictionary)
    {
        Console.WriteLine($"Key: {kvp.Key}, ID: {kvp.Value.Id}, Name: {kvp.Value.FirstName} {kvp.Value.LastName}, Role: {kvp.Value.Role}");
    }

    Console.ReadLine();
    Console.Clear();
}

static void InsertUsers<T>(IEnumerable<T> users) where T : User
{
    Context context = new Context();
    context.Users.AddRange(users);
    context.SaveChanges();
}