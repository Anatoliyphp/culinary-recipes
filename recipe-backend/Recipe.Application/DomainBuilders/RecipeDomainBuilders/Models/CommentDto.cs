using System.Runtime.Serialization;

namespace Application
{
    [DataContract]
    public class CommentDto
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
        
        [DataMember(Name = "userId")]
        public int UserId { get; set; }
    
        [DataMember(Name = "author")]
        public string Author { get; set; }
        
        [DataMember(Name = "text")]
        public string Text { get; set; }
        
        [DataMember(Name = "time")]
        public string Time { get; set; }
    }
}