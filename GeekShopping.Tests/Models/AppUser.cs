namespace GeekShopping.Tests.Models;

public class AppUser
{
    public AppUser()
    {
        Random rand = new();
        FirstName = firstNames[rand.Next(1, firstNames.Count)]; 
        LastName = lastNames[rand.Next(1, lastNames.Count)];
        UserName = userNames[rand.Next(1, lastNames.Count)] + rand.Next(22, 7600);
        Email = $"{UserName}@test.com";
        Password = "Test@r123";
    }

    List<string> userNames = new() { "Rock", "Great", "Pretty", "Fire", "Personal", "Fast" };
    List<string> firstNames = new() { "Alex", "Erick", "Lisa", "Sun", "Lee", "Jennifer" };
    List<string> lastNames = new() { "C.", "Alpaccinno", "Gonzales", "B. J.", "Luccas", "Richard" };

    public static AppUser GenerateUser()
    {
        return new();
    }

    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
}
