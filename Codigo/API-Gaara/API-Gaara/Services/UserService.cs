using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using API_Gaara.Models;
using MongoDB.Bson;

namespace API_Gaara.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(IUsersDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>(settings.UsersCollectionName);
        }
        public List<User> Get() =>
            _user.Find(user => true).ToList();

        public User Get(string id) =>
            _user.Find<User>(user => user.id == id).FirstOrDefault();

        public User Get(string email, string pwd) =>
            _user.Find<User>(user => user.email == email && user.pwd == pwd).FirstOrDefault();
            

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _user.ReplaceOne(user => user.id == id, userIn);

        public void Remove(User userIn) =>
            _user.DeleteOne(user => user.id == userIn.id);

        public void Remove(string id) =>
            _user.DeleteOne(user => user.id == id);
    }
}
