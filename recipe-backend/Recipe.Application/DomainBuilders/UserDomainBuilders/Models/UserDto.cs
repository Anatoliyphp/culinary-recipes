using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class UserDto
	{
		public UserDto(
			int id,
			string login,
			string password,
			string name,
			string about
			)
		{
			Id = id;
			Login = login;
			Password = password;
			Name = name;
			About = about;
		}

		[DataMember( Name= "id")]
		public int Id { get; set; }

		[DataMember( Name = "login" )]
		public string Login { get; set; }

		[DataMember(Name = "password")]
		public string Password { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "about")]
		public string About { get; set; }
	}
}
