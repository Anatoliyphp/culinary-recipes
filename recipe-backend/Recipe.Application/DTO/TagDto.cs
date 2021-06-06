using System.Runtime.Serialization;

namespace Recipe.Application.DTO
{
	[DataContract]
	public class TagDto
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}
