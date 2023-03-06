using DocumentService.Features.Storage.Models;

namespace DocumentService.Features.Storage.Services.Interfaces
{
    public interface IDocumentServiceStorage
    {
        Task InsertPdfDocumentItem(DocumentStorageModel pdfDocuments);

    }
}
