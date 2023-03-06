namespace DocumentService.Features.DocumentService.Models
{
    public class DocumentModel
    {
        public Guid DocumentNumber { get; set; }
        public string CustomerNumber { get; set; }
        public string DocumentText { get; set; }
    }
}