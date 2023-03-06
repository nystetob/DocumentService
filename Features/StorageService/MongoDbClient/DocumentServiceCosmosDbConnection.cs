using DocumentService.Features.StorageService.Models;
using MongoDB.Driver;
using System.Security.Authentication;

namespace DocumentService.Features.StorageService.MongoDbClient
{
        public static class DocumentServiceCosmosDbConnection
        {
            private static IMongoClient _internalMongoClient;
            private static IMongoDatabase _internalMongoDatabase;

            private static string ConnectionString => DocumentServiceCosmosDbSettings.ConnectionString;

            private static IMongoCollection<DocumentStorageModel> _documentStorageCollection;

            private static IMongoClient GetClient
            {
                get
                {
                    if (_internalMongoClient != null) return _internalMongoClient;

                    var settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
                    _internalMongoClient = new MongoClient(settings);

                    return _internalMongoClient;
                }
            }

            public static IMongoDatabase GetDatabase
            {
                get
                {
                    if (_internalMongoDatabase != null) return _internalMongoDatabase;
                    _internalMongoDatabase = GetClient.GetDatabase(DocumentServiceCosmosDbSettings.Database);
                    return _internalMongoDatabase;
                }
            }

            public static IMongoCollection<DocumentStorageModel> DocumentStorageCollection
            {
                get
                {
                    if (_documentStorageCollection != null) return _documentStorageCollection;
                    _documentStorageCollection = GetDatabase.GetCollection<DocumentStorageModel>(DocumentServiceCosmosDbSettings.DocumentStorageCollection);
                    return _documentStorageCollection;
                }
            }
         
        }
    }
