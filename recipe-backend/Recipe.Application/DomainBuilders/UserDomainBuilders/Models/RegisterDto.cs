using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class RegisterDto
	{
		public RegisterDto(
			string login,
			string password,
			string name
			)
		{
			Login = login;
			Password = password;
			Name = name;
		}

		[DataMember(Name = "login")]
		public string Login { get; set; }

		[DataMember(Name = "password")]
		public string Password { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}
