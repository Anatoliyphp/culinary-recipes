using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class IngridientDto
	{
		public IngridientDto(
			string name,
			string list
			)
		{
			Name = name;
			List = list;
		}

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "list")]
		public string List { get; set; }
	}
}
