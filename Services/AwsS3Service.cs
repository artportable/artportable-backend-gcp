using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace Artportable.API.Services
{
  public class AwsS3Service : IAwsS3Service
  {
    private AmazonS3Client _s3client;

    private const string bucketName = "artportable-images";
    private static readonly RegionEndpoint bucketRegion = RegionEndpoint.EUNorth1;

    public AwsS3Service()
    {
      _s3client = new AmazonS3Client(bucketRegion);
    }

    /// <summary>
    /// Upload image
    /// </summary>
    public async Task UploadAsync(Stream file, string filename)
    {
      var bytes = GetArrayBytes(file);
      if (bytes.Length <= 0)
      {
        throw new ArgumentException("No file provided.");
      }

      var req = new PutObjectRequest
      {
          BucketName = bucketName,
          Key = "Images/" + filename,
          ContentType = "image/jpeg",
          InputStream = new MemoryStream(bytes),

      };

      PutObjectResponse response = await _s3client.PutObjectAsync(req);
    }

    /// <summary>
    /// Delete image
    /// </summary>
    public async Task DeleteAsync(string filename)
    {
      var req = new DeleteObjectRequest
      {
          BucketName = bucketName,
          Key = "Images/" + filename
      };

      DeleteObjectResponse response = await _s3client.DeleteObjectAsync(req);
    }

    private byte[] GetArrayBytes(Stream input)
    {
      byte[] buffer = new byte[16 * 1024];
      using (MemoryStream ms = new MemoryStream())
      {
        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        {
          ms.Write(buffer, 0, read);
        }
        return ms.ToArray();
      }
    }
  }
}
