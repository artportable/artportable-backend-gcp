using Moq;
using Xunit;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure;
using System.Threading;
using Services;
using System;
using FluentAssertions;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Azure.Storage;
using System.Text;
using Xunit.Extensions;

namespace Artportable.ImageApi.Tests.csproj
{
  public class BlobServiceTests
  {
    Mock<BlobContainerClient> _blobServiceClientMock;
    Mock<BlobClient> _blobClientMock;
    Mock<Response> _responseMock;

    public BlobServiceTests()
    {
      _blobClientMock = new Mock<BlobClient>()
      {
        Name = "My CLIENT"
      };
      _blobServiceClientMock = new Mock<BlobContainerClient>();
      _responseMock = new Mock<Response>();
    }

    private Stream GetImageStream()
    {
      string image = "iVBORw0KGgoAAAANSUhEUgAAASwAAAEsBAMAAACLU5NGAAAAG1BMVEXMzMyWlpacnJyqqqrFxcWxsbGjo6O3t7e+vr6He3KoAAAACXBIWXMAAA7EAAAOxAGVKw4bAAAD90lEQVR4nO3cwW+bSBQH4AcGw5HnJDhHaN3dHO1su9ojNGnPtrUb7dFuIiVHnEo5263Uv3vfGwab1myVA5DV6vcpgeD35HmeGYbJxUQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD/zOb3N5BRexlu9/Jo+NCQFl/HbWrRK7s6Amcdy3jCfaftyOT/OmsnLxSFqkzu04Ns1Z+RxPOMtUc63fH6U5HP8O5/uo1Vyh9IJhTylwSjz0pV0y4Tex0dJ7iij3ck+WiV3J9RPvVhRLgO5O5V+KOSl7MesnXSRH++jNrlDAWurEW0i6ZOz8jI9mlwaDXkftckd8nXEdgnNVjI2sf6Q+VvLSMiMHJnupHC0j9rkrmlL87Lhs7JK86oM1fowVFq0jdrkjn2QKbMuTEvD8aGsfCQ9th9PbzHeR21yt1KWkUq3et+Tq4tDHpnXfZ67+7Zdltu1itrkbrEuRWVLWdmwHbl0shlXSQ7LLVtFbXLXZUmLphHOHK3IsWVtTg6Lk6PFV1Gb3G1Z9I1Xjb015NpSHq7jfntL7reoaW7JhD+pJQ2537llVuyGO1Em17iWJMt7f3ei/zeZcdGlKLDr1saW5XPV9F9bM2pV1CZ3yDxDZFx0HZcF0z+s8rpwVcuWPo5k1KqoTe7QwD58mp6Js/PUTn4tVEatx2ei3lAzu4M4t3uErQl5PN3YOb84NR+gitrkDnl8J51QNO23hjLH7SqQxxnp0trbfotmo9t0RE27U9k9hFw2PuBfLnVD0d/u9KMs8hNq2svrxFqXJXprZtmg9riXp5v0jTRI4afyn5lv1X8+gRaQ22XA/zT6sxatkgEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD65tjf/5gXLYtHb/8l8kNZkVw5zEwjIjei8ru7rtJ7/YqcO3ISorTFsiLvt+eXZY7xlp5sWd6b7KscrpeZ80DBus2y6D1dviY3C+QP/9WUnGWkp8GrhZa1fE3DQiK1ssYrurdlDeblwZ86TzTctFuWf/dxPihy+kw31+/IuTOnm2v98I6EwoTe1cuKLsLEluVm5cFLHHf7pc2JKIPoZl4STpfFHzSRfnEyc5pQrmVJiO7l13yRHpdlPQ0LW5ZTHSInWN23WZZMedMJycUq0aa1FT1F1dyK6MugoHpvuY903Fv0a9Jqb+n7apesHlY0KSvRU6233CV9V5Z/RsdzixbzlsvSuUXL4nFOT9mVtq2nw9yiYPx9WebCHGt3IrW7yOnby51IuyzPKEgv9M31dLgTKUgayioH+oqrdavlsp5hWPTb3jM9vnQBjZyLl64AAP43/gHVSaMe2vmdiAAAAABJRU5ErkJggg==";
      byte[] byteArray = Convert.FromBase64String(image);
      MemoryStream stream = new MemoryStream(byteArray);
      return stream;
    }

    [Fact]
    public async void DeleteAsyncTest()
    {
      //Arrange
      _blobServiceClientMock.Setup(x => x.GetBlobClient(It.IsAny<string>())).Returns(_blobClientMock.Object);
      _blobClientMock.Setup(x => x.DeleteIfExistsAsync(It.IsAny<DeleteSnapshotsOption>(), It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()))
      .ReturnsAsync(Response.FromValue<bool>(true, _responseMock.Object));
      var blobService = new BlobService(_blobServiceClientMock.Object);

      //Act
      Func<Task> act = blobService.Awaiting(x => x.DeleteAsync("filename"));

      //Assert
      await act.Should().NotThrowAsync("execution to be successful");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async void DeleteAsyncInvalidFileNameTest(string fileName)
    {
      //Arrange
      var blobService = new BlobService(_blobServiceClientMock.Object);

      //Act
      Func<Task> act = blobService.Awaiting(x => x.DeleteAsync(fileName));

      //Assert
      await act.Should().ThrowAsync<ArgumentException>("null or empty filename is not a valid parameter");
    }

    [Fact]
    public async void DeleteAsyncBlobExceptionTest()
    {
      //Arrange
      _blobServiceClientMock.Setup(x => x.GetBlobClient(It.IsAny<string>())).Returns(_blobClientMock.Object);
      _blobClientMock.Setup(x => x.DeleteIfExistsAsync(It.IsAny<DeleteSnapshotsOption>(), It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()))
      .ThrowsAsync(new RequestFailedException(""));
      var blobService = new BlobService(_blobServiceClientMock.Object);

      //Act
      Func<Task> act = blobService.Awaiting(x => x.DeleteAsync("filename"));

      //Assert
      var result = await act.Should().ThrowAsync<Exception>("expected exception to be thrown");
      result.And.InnerException.Should().BeOfType<RequestFailedException>("expected exception to be thrown by BlobClient");
    }

    [Fact]
    public async void DeleteAsyncUnknownExceptionTest()
    {
      //Arrange
      _blobServiceClientMock.Setup(x => x.GetBlobClient(It.IsAny<string>())).Returns(_blobClientMock.Object);
      _blobClientMock.Setup(x => x.DeleteIfExistsAsync(It.IsAny<DeleteSnapshotsOption>(), It.IsAny<BlobRequestConditions>(), It.IsAny<CancellationToken>()))
      .ThrowsAsync(new Exception(""));
      var blobService = new BlobService(_blobServiceClientMock.Object);

      //Act
      Func<Task> act = blobService.Awaiting(x => x.DeleteAsync("filename"));

      //Assert
      var result = await act.Should().ThrowAsync<Exception>("expected exception to be thrown");
      result.And.InnerException.Should().BeOfType<Exception>("expected unknown exception to be thrown");
    }

    [Fact]
    public async void UploadAsyncTest()
    {
      //Arrange
      _blobServiceClientMock.Setup(x => x.GetBlobClient(It.IsAny<string>())).Returns(_blobClientMock.Object);
      _blobClientMock.Setup(x => x.UploadAsync(
        It.IsAny<Stream>(),
        It.IsAny<BlobUploadOptions>(),
        It.IsAny<CancellationToken>()))
      .ReturnsAsync(
        Response.FromValue<BlobContentInfo>(
          BlobsModelFactory.BlobContentInfo(
            new ETag(),
            new DateTimeOffset(),
            new byte[1],
            "",
            "",
            "",
            1),
            _responseMock.Object));
      var blobService = new BlobService(_blobServiceClientMock.Object);
      var stream = GetImageStream();

      //Act
      Func<Task> act = blobService.Awaiting(x => x.UploadAsync(stream, "filename"));

      //Assert
      await act.Should().NotThrowAsync("execution to be successful");
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async void UploadAsyncInvalidStreamTest(bool useEmptyStream)
    {
      //Arrange
      Stream stream = null;
      if (useEmptyStream)
      {
        stream = new MemoryStream();
      }
      var blobService = new BlobService(_blobServiceClientMock.Object);

      //Act
      Func<Task> act = blobService.Awaiting(x => x.UploadAsync(stream, "filename"));

      //Assert
      await act.Should().ThrowAsync<ArgumentException>("null or empty file stream is not a valid parameter");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async void UploadAsyncInvalidFileNameTest(string fileName)
    {
      //Arrange
      string image = "iVBORw0KGgoAAAANSUhEUgAAASwAAAEsBAMAAACLU5NGAAAAG1BMVEXMzMyWlpacnJyqqqrFxcWxsbGjo6O3t7e+vr6He3KoAAAACXBIWXMAAA7EAAAOxAGVKw4bAAAD90lEQVR4nO3cwW+bSBQH4AcGw5HnJDhHaN3dHO1su9ojNGnPtrUb7dFuIiVHnEo5263Uv3vfGwab1myVA5DV6vcpgeD35HmeGYbJxUQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD/zOb3N5BRexlu9/Jo+NCQFl/HbWrRK7s6Amcdy3jCfaftyOT/OmsnLxSFqkzu04Ns1Z+RxPOMtUc63fH6U5HP8O5/uo1Vyh9IJhTylwSjz0pV0y4Tex0dJ7iij3ck+WiV3J9RPvVhRLgO5O5V+KOSl7MesnXSRH++jNrlDAWurEW0i6ZOz8jI9mlwaDXkftckd8nXEdgnNVjI2sf6Q+VvLSMiMHJnupHC0j9rkrmlL87Lhs7JK86oM1fowVFq0jdrkjn2QKbMuTEvD8aGsfCQ9th9PbzHeR21yt1KWkUq3et+Tq4tDHpnXfZ67+7Zdltu1itrkbrEuRWVLWdmwHbl0shlXSQ7LLVtFbXLXZUmLphHOHK3IsWVtTg6Lk6PFV1Gb3G1Z9I1Xjb015NpSHq7jfntL7reoaW7JhD+pJQ2537llVuyGO1Em17iWJMt7f3ei/zeZcdGlKLDr1saW5XPV9F9bM2pV1CZ3yDxDZFx0HZcF0z+s8rpwVcuWPo5k1KqoTe7QwD58mp6Js/PUTn4tVEatx2ei3lAzu4M4t3uErQl5PN3YOb84NR+gitrkDnl8J51QNO23hjLH7SqQxxnp0trbfotmo9t0RE27U9k9hFw2PuBfLnVD0d/u9KMs8hNq2svrxFqXJXprZtmg9riXp5v0jTRI4afyn5lv1X8+gRaQ22XA/zT6sxatkgEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAD65tjf/5gXLYtHb/8l8kNZkVw5zEwjIjei8ru7rtJ7/YqcO3ISorTFsiLvt+eXZY7xlp5sWd6b7KscrpeZ80DBus2y6D1dviY3C+QP/9WUnGWkp8GrhZa1fE3DQiK1ssYrurdlDeblwZ86TzTctFuWf/dxPihy+kw31+/IuTOnm2v98I6EwoTe1cuKLsLEluVm5cFLHHf7pc2JKIPoZl4STpfFHzSRfnEyc5pQrmVJiO7l13yRHpdlPQ0LW5ZTHSInWN23WZZMedMJycUq0aa1FT1F1dyK6MugoHpvuY903Fv0a9Jqb+n7apesHlY0KSvRU6233CV9V5Z/RsdzixbzlsvSuUXL4nFOT9mVtq2nw9yiYPx9WebCHGt3IrW7yOnby51IuyzPKEgv9M31dLgTKUgayioH+oqrdavlsp5hWPTb3jM9vnQBjZyLl64AAP43/gHVSaMe2vmdiAAAAABJRU5ErkJggg==";
      byte[] byteArray = Convert.FromBase64String(image);
      MemoryStream stream = new MemoryStream(byteArray);
      var blobService = new BlobService(_blobServiceClientMock.Object);

      //Act
      Func<Task> act = blobService.Awaiting(x => x.UploadAsync(stream, fileName));

      //Assert
      await act.Should().ThrowAsync<ArgumentException>("null or empty filename is not a valid parameter");
    }



    [Fact]
    public async void UploadAsyncBlobExceptionTest()
    {
      //Arrange
      _blobClientMock.Setup(x => x.UploadAsync(
        It.IsAny<Stream>(),
        It.IsAny<BlobUploadOptions>(),
        It.IsAny<CancellationToken>()))
        .ThrowsAsync(new RequestFailedException(""));
      _blobServiceClientMock.Setup(x => x.GetBlobClient(It.IsAny<string>())).Returns(_blobClientMock.Object);
      var blobService = new BlobService(_blobServiceClientMock.Object);
      var stream = GetImageStream();

      //Act
      Func<Task> act = blobService.Awaiting(x => x.UploadAsync((Stream)stream, "filename"));

      //Assert
      var result = await act.Should().ThrowAsync<Exception>("expected exception to be thrown");
      result.And.InnerException.Should().BeOfType<RequestFailedException>("expected exception to be thrown by BlobClient");
    }

    [Fact]
    public async void UploadAsyncUnknownExceptionTest()
    {
      //Arrange
      _blobServiceClientMock.Setup(x => x.GetBlobClient(It.IsAny<string>())).Returns(_blobClientMock.Object);
      _blobClientMock.Setup(x => x.UploadAsync(
        It.IsAny<Stream>(),
        It.IsAny<BlobUploadOptions>(),
        It.IsAny<CancellationToken>()))
        .ThrowsAsync(new Exception(""));
      var blobService = new BlobService(_blobServiceClientMock.Object);
      var stream = GetImageStream();

      //Act
      Func<Task> act = blobService.Awaiting(x => x.UploadAsync(stream, "filename"));

      //Assert
      var result = await act.Should().ThrowAsync<Exception>("expected exception to be thrown");
      result.And.InnerException.Should().BeOfType<Exception>("expected unknown exception to be thrown");
    }
  }
}
