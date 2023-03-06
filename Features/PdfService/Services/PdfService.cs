using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using DocumentService.Features.DocumentService.Models;
using DocumentService.Features.PdfService.Services.Interfaces;

namespace DocumentService.Features.PdfService.Services
{
    public class PdfService : IPdfService
    {
        public byte[] GeneratePdf(DocumentModel documentModel)
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

            return fileContents;

        }
    }
}