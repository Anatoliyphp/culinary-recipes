using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class TagDto
	{
		public TagDto(int id, string name)
		{
			Id = id;
			Name = name;
		}

		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}
