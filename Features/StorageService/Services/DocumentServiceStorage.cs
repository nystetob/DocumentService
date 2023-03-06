using DocumentService.Features.StorageService.Models;
using DocumentService.Features.StorageService.MongoDbClient;
using DocumentService.Features.StorageService.Services.Interfaces;
using MongoDB.Driver;

namespace DocumentService.Features.StorageService.Services
{
    public class DocumentServiceStorage : IDocumentServiceStorage
    {
        public async Task InsertPdfDocumentItem(DocumentStorageModel pdfDocumentModel)
        {
            if (pdfDocumentModel == null) return;

            var filter = Builders<DocumentStorageModel>.Filter.Where(x => x.DocumentNumber == pdfDocumentModel.DocumentNumber);
            await DocumentServiceCosmosDbConnection.DocumentStorageCollection.ReplaceOneAsync(filter, pdfDocumentModel, new ReplaceOptions {  IsUpsert = true });

        }

    }
}
