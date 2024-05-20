using abra_test.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace abra_test.Services
{
    public class PetService
    {
        private readonly IMongoCollection<Pet> _petsCollection;

        public PetService(
            IOptions<PetDatabaseSettings> petDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                petDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                petDatabaseSettings.Value.DatabaseName);

            _petsCollection = mongoDatabase.GetCollection<Pet>(
                petDatabaseSettings.Value.PetsCollectionName);
        }

        public async Task CreateAsync(Pet newPet)
        {
            newPet.Created_at = DateTime.Now;
            await _petsCollection.InsertOneAsync(newPet);
        }

        public async Task<Pet?> GetAsync(string id) =>
            await _petsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<List<Pet>> GetAsync() =>
            await _petsCollection.Find(_ => true).ToListAsync();
    }
}
