using System.IO;
using System.Threading.Tasks;

namespace Artportable.API.Services
{
  public interface IAwsS3Service
  {
    Task UploadAsync(Stream file, string filename);
  }
}
