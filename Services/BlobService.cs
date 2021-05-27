using System;
using System.IO;
using System.Threading.Tasks;
using Artportable.API.Services;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Services
{
  public class BlobService : IUploadService
  {
    private readonly BlobContainerClient _blobContainerClient;
    private readonly BlobUploadOptions _blobUploadOptions = new BlobUploadOptions{ 
      HttpHeaders = new BlobHttpHeaders { ContentType = "image/jpeg" }};
    public BlobService(BlobContainerClient blobContainerClient)
    {
      _blobContainerClient = blobContainerClient;
    }
    public async Task DeleteAsync(string fileName)
    {
      if (string.IsNullOrWhiteSpace(fileName))
      {
        throw new ArgumentException("Provided filename is either null or empty");
      }

      try
      {
        var blob = _blobContainerClient.GetBlobClient(fileName);
        var response = await blob.DeleteIfExistsAsync();
      }
      catch (RequestFailedException rfe)
      {
        //Add logging
        throw new Exception($"Failed to delete file with nane {fileName}", rfe);
      }
      catch (Exception e)
      {
        //Add logging
        throw new Exception($"Unknown error when trying to delete file with name {fileName}", e);
      }
    }

    public async Task UploadAsync(Stream file, string fileName)
    {
      if (string.IsNullOrWhiteSpace(fileName))
      {
        throw new ArgumentException("Provided filename is either null or empty");
      }
      if (file == null || file.Length == 0)
      {
        throw new ArgumentException("Provided file is empty or null");
      }

      try
      {
        var blob = _blobContainerClient.GetBlobClient($"images/{fileName}");
        await blob.UploadAsync(file, _blobUploadOptions);
      }
      catch (RequestFailedException rfe)
      {
        //Add logging
        throw new Exception($"Failed to upload file with nane {fileName}", rfe);
      }
      catch (Exception e)
      {
        //Add logging
        throw new Exception($"Unknown error when trying to upload file with name {fileName}", e);
      }
    }
  }
}