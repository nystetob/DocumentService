using DocumentService.Features.DocumentService.Models;
using DocumentService.Features.PdfService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Features.DocumentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentServiceController : Controller
    {
        private readonly IPdfService _pdfService;
        public DocumentServiceController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet(Name = "GetDocument")]
        public IActionResult Get([FromQuery] DocumentModel document)
        {
            var fileContent = _pdfService.GeneratePdf(document);

            return File(fileContent, "application/octet-stream", $"{document.DocumentNumber}.pdf");
        }
    }
}