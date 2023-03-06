using DocumentService.Features.DocumentService.Models;

namespace DocumentService.Features.PdfService.Services.Interfaces
{
    public interface IPdfService
    {
        byte[] GeneratePdf(DocumentModel model);
    }
}
