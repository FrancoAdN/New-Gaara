using API_Gaara.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

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

        public Enterprise Get(string id) =>
            
            _enterprise.Find<Enterprise>(enterprise => enterprise.id == id).FirstOrDefault();

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
