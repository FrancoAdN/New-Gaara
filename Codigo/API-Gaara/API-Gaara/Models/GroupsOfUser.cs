using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Gaara.Models
{
    [BsonIgnoreExtraElements]
    public class GroupsOfUser
    {
        [BsonElement("g_id")]
        public int g_id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }

    }
}
