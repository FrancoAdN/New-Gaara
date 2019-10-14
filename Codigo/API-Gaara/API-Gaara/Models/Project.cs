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
        [DataMember]
        [BsonElement("id")]
        public int id { get; set; }

        public string name { get; set; }

        public string desc { get; set; }

        public int state { get; set; }
        
        public string start { get; set; }
        
        public string end { get; set; }
        
        public List<Task> tasks { get; set; }
    }
}
