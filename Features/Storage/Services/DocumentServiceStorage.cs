using DocumentService.Features.Storage.Models;
using DocumentService.Features.Storage.MongoDbClient;
using DocumentService.Features.Storage.Services.Interfaces;
using MongoDB.Driver;
using System.Linq;

namespace DocumentService.Features.Storage.Services
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
