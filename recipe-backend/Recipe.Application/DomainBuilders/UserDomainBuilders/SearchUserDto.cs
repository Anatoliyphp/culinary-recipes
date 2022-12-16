using System.Runtime.Serialization;

namespace Application
{
    [DataContract]
    public class SearchUserDto
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}