using System.Threading.Tasks;

namespace Artportable.API.Services
{
  public interface IUploadService
  {
    Task UploadAsync(System.IO.Stream file, string fileName);
    Task DeleteAsync(string fileName);
  }
}
