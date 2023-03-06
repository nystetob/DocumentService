namespace DocumentService.Features.StorageService.MongoDbClient
{
    public static class DocumentServiceCosmosDbSettings
    {
        public static string ConnectionString { get; private set; }
        public static string Database { get; private set; }
        public static string DocumentStorageCollection { get; private set; }

        public static void Init(IConfiguration configuration)
        {
            if (string.IsNullOrEmpty(ConnectionString)) ConnectionString = configuration["DocumentServiceStorage:ConnectionString"];
            if (string.IsNullOrEmpty(Database)) Database = configuration["DocumentServiceStorage:DatabaseName"];
            if (string.IsNullOrEmpty(DocumentStorageCollection)) DocumentStorageCollection = configuration["DocumentServiceStorage:DocumentStorageCollectionName"];
        }
    }
}
