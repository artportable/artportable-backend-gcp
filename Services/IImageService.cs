namespace Artportable.API.Services
{
  public interface IImageService
  {
    void Add(string filename, int width, int height);
    void Remove(string filename);
  }
}
