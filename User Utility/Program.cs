using UserContext;
using UserData;

Context context = new Context();
context.Database.EnsureCreated();

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
            CreatePosts();
            break;
        case "3":
            
            break;
        case "4":

            break;
        case "5":
            Console.WriteLine("Exiting the program...");
            return;
        default:
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3, or type '5' to exit.");
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

static void ReadLineAndClear()
{
    Console.WriteLine("Press ENTER to continue");
    Console.ReadLine();
    Console.Clear();
}

void CreateUsers()
{
    var userList = new List<User>
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
    ReadLineAndClear();
}

void CreatePosts()
{
    var userList = context.Users.ToList();
    var postList = new List<Post>
    {
        new Post { Title = "De Jong out for season, back for Euros", Description = "Frenkie de Jong will miss the last six games of Barcelona's season after sustaining another ankle injury in Sunday's 3-2 Clásico defeat against Real Madrid", PostingDate = new DateTime(2024, 4, 22), Author = userList[0]},
        new Post { Title = "Pochettino on Chelsea thrashing: 'We gave up'", Description = "Mauricio Pochettino admitted Chelsea gave up in Tuesday's 5-0 thrashing at Arsenal, but sought to defend his players by insisting some of the game's greats had similar off days", PostingDate = new DateTime(2024, 4, 23), Author = userList[0]},
        new Post { Title = "Leverkusen's unbeaten run reaches 45 games", Description = "Bayer Leverkusen's Josip Stanisic scored a stoppage-time goal for the champions to rescue a 1-1 Bundesliga draw at Borussia Dortmund", PostingDate = new DateTime(2024, 4, 21), Author = userList[1]},
        new Post { Title = "Verstappen eases to China win, Norris second ahead of Perez", Description = "Max Verstappen overcame two different Safety Car periods to record another easy win at the Chinese Grand Prix", PostingDate = new DateTime(2024, 4, 21), Author = userList[2]},
        new Post { Title = "LeBron sounds off on officiating, walks out of news conference", Description = "LeBron James complains about the officiating in Lakers vs. Nuggets and even mentions the 76ers-Knicks game", PostingDate = new DateTime(2024, 4, 23), Author = userList[3]}
    };

    context.Posts.AddRange(postList);
    context.SaveChanges();

    Console.WriteLine("Posts created \n");
    ReadLineAndClear();
}