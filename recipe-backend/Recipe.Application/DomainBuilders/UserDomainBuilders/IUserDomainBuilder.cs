using recipe_domain;

namespace Application
{
	public interface IUserDomainBuilder
	{
		User CreateUser(UserDto userDto);
	}
}
