using DocumentService.Features.Storage.Models;
using DocumentService.Features.Storage.MongoDbClient;
using DocumentService.Features.Storage.Services.Interfaces;

namespace DocumentService.Features.Storage.Services
{
    public class DocumentServiceStorage : IDocumentServiceStorage
    {
        public async Task InsertPdfDocumentItem(DocumentStorageModel pdfDocumentModel)
        {
            if (pdfDocumentModel == null) return;

            await DocumentServiceCosmosDbConnection.DocumentStorageCollection.InsertOneAsync(pdfDocumentModel);
            
        }

    }
}
