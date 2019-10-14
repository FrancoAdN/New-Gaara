using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Gaara.Models
{
    [BsonIgnoreExtraElements]
    public class Task
    {
        public int id { get; set;}

        public string name { get; set;}

        public string desc { get; set; }

        public int state { get; set; }

        public int hours { get; set; }

        public int group { get; set; }

        public int? prec { get; set; }

        public bool done { get; set; }



    }
}
