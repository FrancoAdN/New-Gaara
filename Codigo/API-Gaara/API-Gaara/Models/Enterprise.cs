using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Gaara.Models
{
    public class Enterprise
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string name { get; set; }

        public int cuit { get; set; }

        public string pais { get; set; }

        public List<Project> proyectos { get; set; }

        public List<Group> groups { get; set; }
    }
}
