using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace API_Gaara.Models
{
    [BsonIgnoreExtraElements]
    public class Project
    {
        [BsonElement("state")]
        public int state { get; set; }

        [BsonElement("name")]
        public string name { get; set; }
        [BsonElement("desc")]
        public string desc { get; set; }
        
        [BsonElement("start")]
        public string start { get; set; }
        [BsonElement("end")]
        public string end { get; set; }
        [BsonElement("id")]
        public int id { get; set; }
        [BsonElement("tasks")]
        public List<Task> tasks { get; set; }
    }
}
