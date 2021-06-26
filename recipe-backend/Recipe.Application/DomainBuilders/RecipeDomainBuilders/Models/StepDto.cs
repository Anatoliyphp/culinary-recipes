using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class StepDto
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "desc")]
		public string Desc { get; set; }
	}
}
