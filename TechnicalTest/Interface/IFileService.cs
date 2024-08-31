namespace TechnicalTest.Interface
{
    public interface IFileService
    {
        Task<MemoryStream> CreateFileFromJsonAsync<T>(T data, string fileName);
    }
}
