using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using DocumentService.Features.DocumentService.Models;
using DocumentService.Features.PdfService.Services.Interfaces;
using DocumentService.Features.StorageService.Services.Interfaces;
using DocumentService.Features.StorageService.Models;
using Microsoft.AspNetCore.Mvc;

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
            ValidateModel(documentModel);

            var fileContent = GenereratePdf(documentModel);

            await _documentServiceStorage.StorePdfDocument(new DocumentStorageModel
            {
                DocumentNumber = documentModel.DocumentNumber.ToString(),
                FileType = "pdf",
                FileContent = fileContent
            });

            return fileContent;

        }

        private void ValidateModel(DocumentModel documentModel)
        {
            if (documentModel == null) throw new Exception("DocumentModel is null");
            if (documentModel.DocumentNumber == Guid.Empty) throw new Exception("DocumentNumber is missing");
            if (string.IsNullOrEmpty(documentModel.CustomerNumber)) throw new Exception("CustomerNumber is missing");

            return;
        }

        private byte[] GenereratePdf(DocumentModel documentModel)
        {
            try
            {
                var document = new PdfDocument();
                var page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                //TODO: Create a HTML PDF template
                gfx.DrawString($"{documentModel.CustomerNumber} {documentModel.DocumentText}", new XFont("Arial", 10), XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

                byte[] fileContent = null;
                using (MemoryStream stream = new MemoryStream())
                {
                    document.Save(stream, true);
                    fileContent = stream.ToArray();
                }

                return fileContent;
            }
            catch
            {
                throw new Exception($"Failed to generate PDF for DocumentNumber: {documentModel.DocumentNumber}");
            }
        }


    }
}