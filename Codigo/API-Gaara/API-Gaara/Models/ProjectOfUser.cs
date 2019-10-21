using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Gaara.Models
{
    [BsonIgnoreExtraElements]
    public class ProjectOfUser
    {
        [BsonElement("p_id")]
        public int p_id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }

    }
}
