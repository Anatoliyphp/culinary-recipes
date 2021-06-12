using Application;
using recipe_domain;
using System.Threading.Tasks;

namespace recipe_api.Account.Builders
{
	public class UserDtoBuilder : IUserDtoBuilder
	{
		private readonly IUserRepository _userRepository;

		public UserDtoBuilder(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<UserDto> CreateUserDto(int userId)
		{
			User user = await _userRepository.GetUser(userId);
			if (user != null)
			{
				return new UserDto(
					user.Id,
					user.Login,
					user.Password,
					user.Name,
					user.About
					);
			}
			return null;
		}
	}
}
