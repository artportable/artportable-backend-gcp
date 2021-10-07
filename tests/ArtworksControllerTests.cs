using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Artportable.API.Controllers;
using Artportable.API.DTOs;
using Artportable.API.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Artportable.ImageApi.Tests
{
  public class ArtworksControllerTests
  {
    Mock<IArtworkService> _artworksServiceMock;
    Mock<IActivityService> _activityServiceMock;

    public ArtworksControllerTests()
    {
      _artworksServiceMock = new Mock<IArtworkService>();
      _activityServiceMock = new Mock<IActivityService>();
    }

    public class GetArtworkCases : IEnumerable<object[]>
    {
      private readonly List<object[]> _data = new List<object[]>
      {
          new object[] { Guid.NewGuid(), "test"},
          new object[] { Guid.NewGuid(), null},
      };

      public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class CreateArtWorkCases : IEnumerable<object[]>
    {
      private readonly List<object[]> _data = new List<object[]>
      {
          new object[]
          {
            new ArtworkForCreationDTO()
            {
              Description = "description",
              Title = "title",
              Price = new decimal(100),
              PrimaryFile = "test1",
              Tags = new List<string>(),
            },
            "test"
          },
          new object[]
          {
            new ArtworkForCreationDTO()
            {
              Description = "description",
              Title = "title",
              Price = new decimal(100),
              PrimaryFile = "test1",
              Tags = new List<string>(),
            },
            null
          }
      };

      public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UpdateArtWorkCases : IEnumerable<object[]>
    {
      private readonly List<object[]> _data = new List<object[]>
      {
          new object[]
          {
            new ArtworkForUpdateDTO()
            {
              Description = "description",
              Title = "title",
              Price = new decimal(100),
              PrimaryFile = "test1",
              Tags = new List<string>(),
            },
            Guid.NewGuid(),
            "test"
          },
          new object[]
          {
            new ArtworkForUpdateDTO()
            {
              Description = "description",
              Title = "title",
              Price = new decimal(100),
              PrimaryFile = "test1",
              Tags = new List<string>(),
            },
            Guid.NewGuid(),
            null
        }
      };

      public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }


    [Theory]
    [InlineData(null, "test")]
    [InlineData("test", null)]
    [InlineData(null, null)]
    public void GetArtworksTest(string owner, string myUsername)
    {
      _artworksServiceMock.Setup(x => x.Get(It.IsAny<string>(), It.IsAny<string>())).Returns(new List<ArtworkDTO>());
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.Get(owner, myUsername);

      //Assert
      var objectResult = result.Result as ObjectResult;
      objectResult.Value.As<List<ArtworkDTO>>().Should().BeEmpty("moq setup was configured to return a empty result");
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.OK, "expected result to be successful");
    }

    [Theory]
    [InlineData(null, "test")]
    [InlineData("test", null)]
    [InlineData(null, null)]
    public void GetArtworksExceptionTest(string owner, string myUsername)
    {
      _artworksServiceMock.Setup(x => x.Get(It.IsAny<string>(), It.IsAny<string>())).Throws(new Exception());
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.Get(owner, myUsername);

      //Assert
      var objectResult = result.Result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError, "expected result to be unsuccessful");
    }

    [Theory]
    [ClassData(typeof(GetArtworkCases))]
    public void GetArtworkTest(Guid id, string myUsername)
    {
      var expected = new ArtworkDTO()
      {
        Id = id,
        Description = "description",
        Owner = new OwnerDTO()
        {
          Username = "test",
          ProfilePicture = "test",
          Location = "test"
        },
        Title = "title",
        Published = DateTime.Now,
        Price = new decimal(100),
        PrimaryFile = new FileDTO()
        {
          Name = "test",
          Width = 1,
          Height = 1
        },
        Tags = new List<string>(),
        Likes = 0,
        LikedByMe = false
      };
      _artworksServiceMock.Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<string>())).Returns(expected);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.GetArtwork(id, myUsername);

      //Assert
      var objectResult = result.Result as ObjectResult;
      objectResult.Value.As<ArtworkDTO>()
      .Should()
      .NotBeNull("moq setup was configured to return a result")
      .And
      .BeEquivalentTo(expected, "no there should not be any changes to the expected object");
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.OK, "expected result to be successful");
    }

    [Theory]
    [ClassData(typeof(GetArtworkCases))]
    public void GetArtworkNotFoundTest(Guid id, string myUsername)
    {
      _artworksServiceMock.Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<string>())).Returns<ArtworkDTO>(null);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.GetArtwork(id, myUsername);

      //Assert
      var objectResult = result.Result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.NotFound, "expected result to be not found");
    }

    [Theory]
    [ClassData(typeof(GetArtworkCases))]
    public void GetArtworkExceptionTest(Guid id, string myUsername)
    {
      _artworksServiceMock.Setup(x => x.Get(It.IsAny<Guid>(), It.IsAny<string>())).Throws(new Exception());
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.GetArtwork(id, myUsername);

      //Assert
      var objectResult = result.Result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError, "expected result to be unsuccessful");
    }
    
    [Theory]
    [ClassData(typeof(CreateArtWorkCases))]
    public async void CreateArtworkTest(ArtworkForCreationDTO artwork, Guid mySocialId)
    {
      var expected = new ArtworkDTO()
      {
        Id = Guid.NewGuid(),
        Description = artwork.Description,
        Title = artwork.Title,
        Tags = artwork.Tags,
        Price = artwork.Price,
        PrimaryFile = new FileDTO()
        {
          Name = artwork.PrimaryFile
        },
        SecondaryFile = string.IsNullOrWhiteSpace(artwork.SecondaryFile) ? null : new FileDTO()
        {
          Name = artwork.SecondaryFile
        },
        TertiaryFile = string.IsNullOrWhiteSpace(artwork.TertiaryFile) ? null : new FileDTO()
        {
          Name = artwork.TertiaryFile
        },
        LikedByMe = false,
        Likes = 0,
        Owner = new OwnerDTO()
        {
          SocialId = mySocialId,
          ProfilePicture = "test",
          Location = "test"
        }
      };
      _artworksServiceMock.Setup(x => x.Create(It.IsAny<ArtworkForCreationDTO>(), It.IsAny<Guid>())).Returns(expected);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = await artworksController.CreateArtwork(artwork, mySocialId);

      //Assert
      var objectResult = result.Result as ObjectResult;
      var artworkDto = objectResult.Value.As<ArtworkDTO>();
      artworkDto.Should()
      .NotBeNull("setup was configured to return a result")
      .And
      .BeEquivalentTo(artwork, options =>
          options
          .Excluding(a => a.PrimaryFile)
          .Excluding(a => a.SecondaryFile)
          .Excluding(a => a.TertiaryFile)
        ,
        "resulting artwork should have same values as incomming value");
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.OK, "expected result to be successful");
    }

    [Theory]
    [ClassData(typeof(CreateArtWorkCases))]
    public async void CreateArtworkBadRequestTest(ArtworkForCreationDTO artwork, Guid mySocialId)
    {
      _artworksServiceMock.Setup(x => x.Create(It.IsAny<ArtworkForCreationDTO>(), It.IsAny<Guid>())).Returns<ArtworkDTO>(null);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = await artworksController.CreateArtwork(artwork, mySocialId);

      //Assert
      var objectResult = result.Result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.BadRequest, "expected result to be bad request");
    }

    [Theory]
    [ClassData(typeof(CreateArtWorkCases))]
    public async void CreateArtworkExceptionTest(ArtworkForCreationDTO artwork, Guid mySocialId)
    {
      _artworksServiceMock.Setup(x => x.Create(It.IsAny<ArtworkForCreationDTO>(), It.IsAny<Guid>())).Throws(new Exception());
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = await artworksController.CreateArtwork(artwork, mySocialId);

      //Assert
      var objectResult = result.Result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError, "expected result to be unsuccessful");
    }

    [Theory]
    [ClassData(typeof(UpdateArtWorkCases))]
    public async void UpdateArtworkTest(ArtworkForUpdateDTO artwork, Guid id, Guid mySocialId)
    {
      var expected = new ArtworkDTO()
      {
        Id = id,
        Description = artwork.Description,
        Title = artwork.Title,
        Tags = artwork.Tags,
        Price = artwork.Price,
        PrimaryFile = new FileDTO()
        {
          Name = artwork.PrimaryFile
        },
        SecondaryFile = string.IsNullOrWhiteSpace(artwork.SecondaryFile) ? null : new FileDTO()
        {
          Name = artwork.SecondaryFile
        },
        TertiaryFile = string.IsNullOrWhiteSpace(artwork.TertiaryFile) ? null : new FileDTO()
        {
          Name = artwork.TertiaryFile
        },
        LikedByMe = false,
        Likes = 0,
        Owner = new OwnerDTO()
        {
          Username = "test",
          ProfilePicture = "test",
          Location = "test"
        }
      };
      _artworksServiceMock.Setup(x => x.Update(It.IsAny<ArtworkForUpdateDTO>(), It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(expected);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = await artworksController.UpdateArtwork(artwork, id, mySocialId);

      //Assert
      var objectResult = result.Result as ObjectResult;
      var artworkDto = objectResult.Value.As<ArtworkDTO>();
      artworkDto.Should()
      .NotBeNull("setup was configured to return a result")
      .And
      .BeEquivalentTo(artwork, options =>
          options
          .Excluding(a => a.PrimaryFile)
          .Excluding(a => a.SecondaryFile)
          .Excluding(a => a.TertiaryFile)
        ,
        "resulting artwork should have same values as incomming value");
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.OK, "expected result to be successful");
    }

    [Theory]
    [ClassData(typeof(UpdateArtWorkCases))]
    public async void UpdateArtworkNotFoundTest(ArtworkForUpdateDTO artwork, Guid id, Guid mySocialId)
    {
      _artworksServiceMock.Setup(x => x.Update(It.IsAny<ArtworkForUpdateDTO>(), It.IsAny<Guid>(), It.IsAny<Guid>())).Returns<ArtworkDTO>(null);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = await artworksController.UpdateArtwork(artwork, id, mySocialId);

      //Assert
      var objectResult = result.Result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.NotFound, "expected result to be not found");
    }

    [Theory]
    [ClassData(typeof(UpdateArtWorkCases))]
    public async void UpdateArtworkExceptionTest(ArtworkForUpdateDTO artwork, Guid id, Guid mySocialId)
    {
      _artworksServiceMock.Setup(x => x.Update(It.IsAny<ArtworkForUpdateDTO>(), It.IsAny<Guid>(), It.IsAny<Guid>())).Throws(new Exception());
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = await artworksController.UpdateArtwork(artwork, id, mySocialId);

      //Assert
      var objectResult = result.Result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError, "expected result to be unsuccessful");
    }

    [Fact]
    public void GetTagsForArtworkTest()
    {
      var expected = new List<TagDTO>(){
        new TagDTO(){
          Tag = "test"
        }
      };

      _artworksServiceMock.Setup(x => x.GetTags(It.IsAny<Guid>())).Returns(expected);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.GetTags(Guid.NewGuid());

      //Assert
      var objectResult = result.Result as ObjectResult;
      objectResult.Value.As<List<TagDTO>>().Should()
      .NotBeEmpty("setup was configured to return a result");
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.OK, "expected result to be successful");
    }

    [Fact]
    public void GetTagsForArtworkNotFoundTest()
    {
      _artworksServiceMock.Setup(x => x.GetTags(It.IsAny<Guid>())).Returns<List<TagDTO>>(null);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.GetTags(Guid.NewGuid());

      //Assert
      var objectResult = result.Result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.NotFound, "expected result to be not found");

    }

    [Fact]
    public void GetTagsForArtworkExceptionTest()
    {
      _artworksServiceMock.Setup(x => x.GetTags(It.IsAny<Guid>())).Throws(new Exception());
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.GetTags(Guid.NewGuid());

      //Assert
      var objectResult = result.Result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError, "expected result to be unsuccessful");
    }

    [Fact]
    public void GetTagsTest()
    {
      var expected = new List<string>(){
          "test"
      };

      _artworksServiceMock.Setup(x => x.GetTags()).Returns(expected);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.GetTags();

      //Assert
      var objectResult = result.Result as ObjectResult;
      objectResult.Value.As<List<string>>().Should()
      .NotBeEmpty("setup was configured to return a result");
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.OK, "expected result to be successful");
    }

    [Fact]
    public void GetTagsExceptionTest()
    {
      _artworksServiceMock.Setup(x => x.GetTags()).Throws(new Exception());
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.GetTags();

      //Assert
      var objectResult = result.Result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError, "expected result to be unsuccessful");
    }

    [Fact]
    public void LikeArtworkTest()
    {
      var randomString = default(Guid);
      _artworksServiceMock.Setup(x => x.Like(It.IsAny<Guid>(), It.IsAny<Guid>(), out randomString)).Returns(true);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.Like(Guid.NewGuid(), Guid.NewGuid());

      //Assert
      var objectResult = result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.OK, "expected result to be successful");
    }

    [Fact]
    public void LikeArtworkNotFoundTest()
    {
      var randomString = default(Guid);
      _artworksServiceMock.Setup(x => x.Like(It.IsAny<Guid>(), It.IsAny<Guid>(), out randomString)).Returns(false);
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.Like(Guid.NewGuid(), Guid.NewGuid());

      //Assert
      var objectResult = result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.NotFound, "expected result to be not found");

    }

    [Fact]
    public void LikeArtworkExceptionTest()
    {
      var randomString = default(Guid);
      _artworksServiceMock.Setup(x => x.Like(It.IsAny<Guid>(), It.IsAny<Guid>(), out randomString)).Throws(new Exception());
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.Like(Guid.NewGuid(), Guid.NewGuid());

      //Assert
      var objectResult = result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError, "expected result to be unsuccessful");
    }

    [Fact]
    public void UnlikeArtworkTest()
    {
      //Arrange
      Guid randomString;
      _artworksServiceMock.Setup(x => x.Unlike(It.IsAny<Guid>(), It.IsAny<Guid>(), out randomString)).Returns(true);
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.Unlike(Guid.NewGuid(), Guid.NewGuid());

      //Assert
      var objectResult = result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.OK, "expected result to be successful");
    }

    [Fact]
    public void UnlikeArtworkExceptionTest()
    {
      Guid randomString = default(Guid);
      _artworksServiceMock.Setup(x => x.Unlike(It.IsAny<Guid>(), It.IsAny<Guid>(), out randomString)).Throws(new Exception());
      //Arrange
      var artworksController = new ArtworksController(_artworksServiceMock.Object, _activityServiceMock.Object);
      //Act
      var result = artworksController.Unlike(Guid.NewGuid(), Guid.NewGuid());

      //Assert
      var objectResult = result as StatusCodeResult;
      objectResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError, "expected result to be unsuccessful");
    }
  }
}