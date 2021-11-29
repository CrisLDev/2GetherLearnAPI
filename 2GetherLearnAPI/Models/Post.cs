using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _2GetherLearnAPI.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Title")]
        public string? TitlePost { get; set; }
        public string? Content { get; set; }
        public bool isDeleted { get; set; }
    }
}
