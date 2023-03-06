using DocumentService.Features.StorageService.Models;

namespace DocumentService.Features.StorageService.Services.Interfaces
{
    public interface IDocumentServiceStorage
    {
        Task InsertPdfDocumentItem(DocumentStorageModel pdfDocuments);

    }
}
