using MongoDB.Bson;

namespace RemindMe.Application.IServices
{
    public interface IMongoService
    {
        Task<List<BsonDocument>> GetDataFromMongoDB();
    }

}