using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	public class StepDto
	{
		public StepDto(
			string name,
			string desc
			)
		{
			Name = name;
			Desc = desc;
		}

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "desc")]
		public string Desc { get; set; }
	}
}
