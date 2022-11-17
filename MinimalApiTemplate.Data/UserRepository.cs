using MinimalApiTemplate.Data.Interfaces;
using MinimalApiTemplate.Domain;

namespace MinimalApiTemplate.Data;

public class UserRepository : IUserRepository
{
    public async Task<IList<User>> GetUsersAsync()
    {
        return await Task.FromResult(FakeUsers());
    }

    public async Task<User?> GetUserByCodeAsync(string code)
    {
        var allUsers = await GetUsersAsync();
        foreach (var user in allUsers)
        {
            if (user.Code.ToString().Equals(code, StringComparison.OrdinalIgnoreCase))
            {
                return user;
            }
        }

        return null;
    }

    private List<User> FakeUsers()
    {
        var listToReturn = new List<User>();
        listToReturn.Add(FakeUser(1, "Liam", "Grossmann"));
        listToReturn.Add(FakeUser(2, "Michelle", "Smith"));
        listToReturn.Add(FakeUser(3, "Victor", "Monroe"));
        return listToReturn;
    }

    private User FakeUser(int id, string firstname, string lastname)
    {
        var valueToReturn = new User();
        valueToReturn.Id = id;
        valueToReturn.Code = Guid.NewGuid();
        valueToReturn.Firstname = firstname;
        valueToReturn.Lastname = lastname;
        valueToReturn.EmailAddress = string.Concat(firstname, ".", lastname, "@gmail.com");
        valueToReturn.CreatedDate = DateTime.Now;
        valueToReturn.LastUpdatedDate = DateTime.Now;
        return valueToReturn;
    }
}