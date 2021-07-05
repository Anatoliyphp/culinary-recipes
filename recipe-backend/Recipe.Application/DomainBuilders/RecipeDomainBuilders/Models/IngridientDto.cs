using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class IngridientDto
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "list")]
		public string List { get; set; }
	}
}
