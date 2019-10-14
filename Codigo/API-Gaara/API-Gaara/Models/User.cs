using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Gaara.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string usr { get; set; }

        public string last { get; set; }

        public string email { get; set; }

        public string pwd { get; set; }

        public bool admin { get; set; }

        [BsonElement("ent_id")]
        public string ent { get; set; }
    }
}
