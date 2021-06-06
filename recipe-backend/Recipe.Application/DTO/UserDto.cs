using System.Runtime.Serialization;

namespace Recipe.Application.DTO
{
	[DataContract]
	public class UserDto
	{
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
