using System.Collections.Generic;
using System.Threading.Tasks;

namespace recipe_domain;

public interface IUserRepository
{
    Task<User> AuthenticateUser(string login);

    Task<bool> RegisterUser(string login, string name, string password);

    Task<User> GetUser(int userId);

    Task<List<User>> SearchUsers(Filter filter, string name);

    Task<User> GetBestUser();

    void EditUser(User user);

    Task<List<User>> GetAllUsers(Filter filter);
}

