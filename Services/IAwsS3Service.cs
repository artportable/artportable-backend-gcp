namespace Artportable.API.Services
{
  public interface IAwsS3Service
  {
    bool Upload(string file);
  }
}
