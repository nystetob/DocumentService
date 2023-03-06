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
        public async Task<IActionResult> GetAsync([FromQuery] DocumentModel document)
        {
            var fileContent = await _pdfService.GeneratePdfAsync(document);

            return File(fileContent, "application/octet-stream", $"{document.DocumentNumber}.pdf");
        }
    }
}