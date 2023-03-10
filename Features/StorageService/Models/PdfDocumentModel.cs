using MongoDB.Bson.Serialization.Attributes;

namespace DocumentService.Features.StorageService.Models
{
    [BsonIgnoreExtraElements]
    public class DocumentStorageModel
    {
        [BsonId]
        public string DocumentNumber { get; set; }
        public byte[] FileContent { get; set; }
        public string FileType { get; set; }

    }
}