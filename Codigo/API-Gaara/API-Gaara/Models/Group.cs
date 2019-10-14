using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Gaara.Models
{
    [BsonIgnoreExtraElements]
    public class Group
    {

        public int id { get; set;}

        public string name { get; set; }

        public List<string> users { get; set; }

    }
}
