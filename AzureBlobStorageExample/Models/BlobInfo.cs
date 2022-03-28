using System.IO;

namespace AzureBlobStorageExample.Models
{
    public class BlobInfo
    {
        public Stream Content { get; }
        public string ContentType { get; }

        public BlobInfo(Stream stream, string contentType)
        {
            Content = stream;
            ContentType = contentType;
        }
    }
}