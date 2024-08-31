using System.IO.Compression;
using System.Text.Json;
using TechnicalTest.Interface;

namespace TechnicalTest.Services
{
    public class FileService : IFileService
    {
        public async Task<MemoryStream> CreateFileFromJsonAsync<T>(T data, string fileName)
        {
            var jsonMemoryStream = new MemoryStream();

            await using (var jsonWriter = new Utf8JsonWriter(jsonMemoryStream))
            {
                JsonSerializer.Serialize(jsonWriter, data);
                await jsonWriter.FlushAsync();
            }

            // Compress the file to make it more smaller
            jsonMemoryStream.Position = 0;
            var compressedMemoryStream = new MemoryStream();
            await using (var gzipStream = new GZipStream(compressedMemoryStream, CompressionLevel.Optimal, leaveOpen: true))
            {
                await jsonMemoryStream.CopyToAsync(gzipStream);
            }

            compressedMemoryStream.Position = 0;
            return compressedMemoryStream;
        }
    }
}
