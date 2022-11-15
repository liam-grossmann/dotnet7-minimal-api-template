using MinimalApiTemplate.Domain;

namespace MinimalApiTemplate.Data.Interfaces;

public interface IUserRepository
{
    IList<User> GetUsers();
}