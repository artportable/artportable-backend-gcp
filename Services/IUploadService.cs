using System.IO;
using System.Threading.Tasks;

namespace Artportable.API.Services
{
  public interface IUploadService
  {
    Task UploadAsync(Stream file, string fileName);
    Task DeleteAsync(string fileName);
  }
}
