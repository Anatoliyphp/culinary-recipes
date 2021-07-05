using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class LoginDto
	{
		[DataMember(Name = "login")]
		public string Login { get; set; }

		[DataMember(Name = "password")]
		public string Password { get; set; }
	}
}
