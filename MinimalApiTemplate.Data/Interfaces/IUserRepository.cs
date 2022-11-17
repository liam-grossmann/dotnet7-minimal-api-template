using MinimalApiTemplate.Domain;

namespace MinimalApiTemplate.Data.Interfaces;

public interface IUserRepository
{

    Task<IList<User>> GetUsersAsync();
    Task<User?> GetUserByCodeAsync(string code);
}