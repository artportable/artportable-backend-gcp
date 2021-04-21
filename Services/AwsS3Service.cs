using System;
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
    public bool Upload(string filename)
    {
      try
      {
        var req = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = "Images/" + filename,
            FilePath = filename,
            ContentType = "image/jpeg"
        };
        PutObjectResponse response =  _s3client.PutObjectAsync(req).Result;
      }
      catch (AmazonS3Exception e)
      {
        Console.WriteLine("Error encountered ***. Message:'{0}' when writing an object", e.Message);
        return false;
      }
      catch (Exception e)
      {
        Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
        return false;
      }

      return true;
    }
  }
}
