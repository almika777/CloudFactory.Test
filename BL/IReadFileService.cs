using System.Threading.Tasks;

namespace BL
{
    public interface IReadFileService
    {
        Task<string> ReadFileContentAsync(string fileName);
    }
}
