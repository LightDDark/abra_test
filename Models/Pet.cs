using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace abra_test.Models
{
    public class Pet
    {
        public enum PetType {
            Dog,
            Cat,
            Horse,
            Other
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string PetName { get; set; } = null!;

        [BsonRepresentation(BsonType.Int32)]
        [BsonElement("type")]
        public PetType Type { get; set; }


        [BsonElement("created_at")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Created_at { get; set; }

        [BsonElement("color")]
        public string Color { get; set; } = null!;

        [BsonElement("Age")]
        public int Age { get; set; }
    }
}
