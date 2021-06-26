using Application;
using recipe_api.Services;
using recipe_domain;
using System.Threading.Tasks;

namespace recipe_api.Account.Builders
{
	public class UserDtoBuilder : IUserDtoBuilder
	{
		private readonly IUserRepository _userRepository;
		private readonly IHashService _hashService;

		public UserDtoBuilder(
			IUserRepository userRepository,
			IHashService hashService
			)
		{
			_userRepository = userRepository;
			_hashService = hashService;
		}

		public async Task<UserDto> CreateUserDto(int userId)
		{
			User user = await _userRepository.GetUser(userId);
			string password = _hashService.DecryteString(user.Password);
			if (user != null)
			{
				return new UserDto(
					user.Id,
					user.Login,
					password,
					user.Name,
					user.About
					);
			}
			return null;
		}
	}
}
