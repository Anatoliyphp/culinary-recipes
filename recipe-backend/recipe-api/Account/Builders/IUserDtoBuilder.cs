using System.Threading.Tasks;

namespace recipe_api.Account.Builders;

public interface IUserDtoBuilder
{
    Task<UserDto> CreateUserDto(int userId);
}
