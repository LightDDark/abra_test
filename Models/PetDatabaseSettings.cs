namespace abra_test.Models
{
    public class PetDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PetsCollectionName { get; set; } = null!;

    }
}
