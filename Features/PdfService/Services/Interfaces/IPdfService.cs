using DocumentService.Features.DocumentService.Models;

namespace DocumentService.Features.PdfService.Services.Interfaces
{
    public interface IPdfService
    {
        Task<byte[]> GeneratePdfAsync(DocumentModel model);
    }
}
