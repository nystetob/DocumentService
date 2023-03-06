using DocumentService.Features.DocumentService.Models;
using DocumentService.Features.PdfService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Features.DocumentService.Controllers
{
    //TODO: AddSecurity
    [ApiController]
    [Route("[controller]")]
    public class DocumentServiceController : Controller
    {
        private readonly IPdfService _pdfService;
        public DocumentServiceController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        //TODO: Change to a function service that fetch signups from a que instead of using api controller
        [HttpGet(Name = "GetDocument")]
        public async Task<IActionResult> GetAsync([FromQuery]DocumentModel document)
        {
            
            var fileContent = await _pdfService.GeneratePdfAsync(document);
            return File(fileContent, "application/octet-stream", $"{document.DocumentNumber}.pdf");
          
        }

    }
}