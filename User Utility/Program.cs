using Microsoft.EntityFrameworkCore;
using UserContext;
using UserData;

Context context = new();

while (true)
{
    DisplayMenu();
    string input = Console.ReadLine();
    Console.Clear();

    switch (input)
    {
        case "1":
            CreateUsers();
            break;
        case "2":
            
            break;
        case "3":
            
            break;
        case "4":

            break;
        case "5":
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
                          "\n1. Create users" +
                          "\n2. Create posts" +
                          "\n3. Show users" +
                          "\n4. Show posts" +
                          "\n5. Exit" +
                          "\n\nEnter the corresponding number for your choice (1/2/3/4/5):");
}

void CreateUsers()
{
    List<User> userList = new List<User>
    {
        new User { FirstName = "William", LastName = "Turner", Role = Role.Admin },
        new User { FirstName = "Emma", LastName = "Thompson ", Role = Role.Moderator },
        new User { FirstName = "Lucas", LastName = "Harris", Role = Role.Editor},
        new User { FirstName = "Chloe", LastName = "White", Role = Role.Contributor},
        new User { FirstName = "Jacob", LastName = "Martin", Role = Role.Subscriber}
    };

    context.Users.AddRange(userList);
    context.SaveChanges();

    Console.WriteLine("Users created \n");
    Console.ReadLine();
    Console.Clear();
}