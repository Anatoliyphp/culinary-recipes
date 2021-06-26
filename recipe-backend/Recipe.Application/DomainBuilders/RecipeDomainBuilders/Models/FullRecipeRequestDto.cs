using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Application
{
	[DataContract]
	[KnownType(typeof(List<string>))]
	[KnownType(typeof(List<IngridientDto>))]
	[KnownType(typeof(List<StepDto>))]
	public class FullRecipeRequestDto
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "img")]
		public IFormFile Img { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "desc")]
		public string Description { get; set; }

		[DataMember(Name = "time")]
		public int Time { get; set; }

		[DataMember(Name = "persons")]
		public int Persons { get; set; }

		[DataMember(Name = "likes")]
		public int Likes { get; set; }

		[DataMember(Name = "isLike")]
		public bool IsLike { get; set; }

		[DataMember(Name = "favourites")]
		public int Favourites { get; set; }

		[DataMember(Name = "isFavourite")]
		public bool IsFavourite { get; set; }

		[DataMember(Name = "userId")]
		public int UserId { get; set; }

		[DataMember(Name = "tags")]
		public List<string> Tags { get; set; }

		[DataMember(Name = "steps")]
		public List<StepDto> Steps { get; set; }

		[DataMember(Name = "ingridients")]
		public List<IngridientDto> Ingridients { get; set; }

	}
}
