using DocumentService.Features.StorageService.Models;

namespace DocumentService.Features.StorageService.Services.Interfaces
{
    public interface IDocumentServiceStorage
    {
        Task StorePdfDocument(DocumentStorageModel pdfDocuments);

    }
}
