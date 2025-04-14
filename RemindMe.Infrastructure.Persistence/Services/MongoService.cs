using MongoDB.Bson;
using MongoDB.Driver;
using RemindMe.Application.IServices;

namespace RemindMe.Infrastructure.Persistence.Services
{
    public class MongoService : IMongoService
    {
        public async Task<List<BsonDocument>> GetDataFromMongoDB()
        {
            var mongoDBclient = new MongoClient("mongodb://localhost:27017/RemindMeLogDB");
            var database = mongoDBclient.GetDatabase("RemindMeLogDB");
            var collection = database.GetCollection<BsonDocument>("RemindMeLogs");

            return await collection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
