using API_Gaara.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System;
using MongoDB.Bson.Serialization;
using System.Diagnostics;

namespace API_Gaara.Services
{
    public class EnterpriseService
    {
        private readonly IMongoCollection<Enterprise> _enterprise;

        public EnterpriseService(IEnterprisesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _enterprise = database.GetCollection<Enterprise>(settings.EnterprisesCollectionName);
        }

        public List<Enterprise> Get() =>
            _enterprise.Find(enterprise => true).ToList();

        public List<GroupsOfUser> GetGroups(string id)
        {
            var agg = _enterprise.Aggregate()
                .Unwind("groups")
                .Match(new BsonDocument { { "groups.users", id} })
                .Project<GroupsOfUser>(new BsonDocument { { "_id", false }, { "g_id", "$groups.id" }, { "name", "$groups.name" } })
                .ToList();
            return agg;
        }

        public List<ProjectOfUser> GetProjectOfUsers(string id)
        {
            var agg = _enterprise.Aggregate()
                .Unwind("groups")
                .Match(new BsonDocument { { "groups.users", id } })
                .Project<GroupsOfUser>(new BsonDocument { { "_id", false }, { "g_id", "$groups.id" }, { "name", "$groups.name" } })
                .ToList();

            List<int> g_id = new List<int>();
            foreach (var gu in agg)
                g_id.Add(gu.g_id);
            return _enterprise.Aggregate()
                .Unwind("proyectos")
                .Match(new BsonDocument { { "proyectos.tasks.group", new BsonDocument { { "$in", new BsonArray(g_id) } } } })
                .Project<ProjectOfUser>(new BsonDocument { { "_id", false }, { "p_id", "$proyectos.id" }, { "name", "$proyectos.name" } })
                .ToList();
        }

        public List<Project> GetProject(string ent, int id)
        {
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", $"ObjectId({ent})");
            var proj = new BsonDocument { { "_id", false }, {"proyectos", new BsonDocument ("$elemMatch", new BsonDocument("id", id))} };
            //var find = _enterprise.Find(enterprise => enterprise.id == ent).Project<Project>(new BsonDocument { { "_id", false }, { "proyectos", new BsonDocument { { "$elemMatch", new BsonDocument { { "id", id } } } } } });
            //return find;
            return _enterprise.Find<Project>(enterprise => enterprise.id == ent).Project(proj);
       
            
        }

        public Enterprise Get(string id)
        {
            return _enterprise.Find<Enterprise>(enterprise => enterprise.id == id).FirstOrDefault();
        }
            

        public Enterprise Create(Enterprise enterprise)
        {
            _enterprise.InsertOne(enterprise);
            return enterprise;
        }

        public void Update(string id, Enterprise enterpriseIn) =>
            _enterprise.ReplaceOne(enterprise => enterprise.id == id, enterpriseIn);

        public void Remove(Enterprise enterpriseIn) =>
            _enterprise.DeleteOne(enterprise => enterprise.id == enterpriseIn.id);

        public void Remove(string id) =>
            _enterprise.DeleteOne(enterprise => enterprise.id == id);
    }
}
