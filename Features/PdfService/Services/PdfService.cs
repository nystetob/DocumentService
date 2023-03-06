using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using DocumentService.Features.DocumentService.Models;
using DocumentService.Features.PdfService.Services.Interfaces;
using DocumentService.Features.StorageService.Services.Interfaces;
using DocumentService.Features.StorageService.Models;

namespace DocumentService.Features.PdfService.Services
{
    public class PdfService : IPdfService
    {
        private readonly IDocumentServiceStorage _documentServiceStorage;

        public PdfService(IDocumentServiceStorage documentServiceStorage)
        {
            _documentServiceStorage = documentServiceStorage;
        }
        public async Task<byte[]> GeneratePdfAsync(DocumentModel documentModel)
        {
            var document = new PdfDocument();
            document.Info.Title = "GeneratedPdf";
            var page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            gfx.DrawString($"{documentModel.CustomerNumber} {documentModel.DocumentText}", new XFont("Arial", 10), XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            byte[] fileContents = null;
            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream, true);
                fileContents = stream.ToArray();
            }

            await _documentServiceStorage.InsertPdfDocumentItem(new DocumentStorageModel
            {
                DocumentNumber = documentModel.DocumentNumber.ToString(),
                FileType = "pdf",
                FileContent = fileContents
            });

            return fileContents;

        }


    }
}