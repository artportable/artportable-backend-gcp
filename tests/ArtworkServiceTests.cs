using Moq;
using Xunit;
using System;
using FluentAssertions;
using Artportable.API.Services;
using Artportable.API.Entities;
using Artportable.API.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Artportable.API.Entities.Models;
using EntityFrameworkCoreMock;
using File = Artportable.API.Entities.Models.File;

namespace Artportable.ImageApi.Tests
{
  public class ArtworkServiceTests
  {
    DbContextMock<APContext> _contextMock;
    Mock<IMapper> _mapperMock;
    DbContextOptions<APContext> CtxOptions { get; } = new DbContextOptionsBuilder<APContext>().Options;


    public ArtworkServiceTests()
    {
      _contextMock = new DbContextMock<APContext>(CtxOptions);
      _contextMock.CreateDbSetMock(x => x.Artworks, GetInitialArtworkEntities());
      _contextMock.CreateDbSetMock(x => x.Users, GetInitialUserEntities());
      _contextMock.CreateDbSetMock(x => x.Files, GetInitialFileEntities());
      _contextMock.CreateDbSetMock(x => x.Tags, GetInitialTagEntities());
      _contextMock.CreateDbSetMock(x => x.Likes, GetInitialLikeEntities());

      _mapperMock = new Mock<IMapper>();
      _mapperMock.Setup(m => m.Map<ArtworkDTO>(It.IsAny<Artwork>())).Returns(GetMapperReturnValue());
    }


    [Fact]
    public void GetAllArtworksTest()
    {
      //Arrange
      var artworkService = new ArtworkService(_contextMock.Object, _mapperMock.Object);

      //Act
      List<ArtworkDTO> act = artworkService.Get(null, null);

      //Assert
      act.Should().HaveCount(1);
    }

    [Fact]
    public void GetSingleArtworkTest()
    {
      //Arrange
      Guid artworkId = new Guid("19459c8f-9b88-4c8f-b314-fb8cec67e225");
      var artworkService = new ArtworkService(_contextMock.Object, _mapperMock.Object);
      var expected = new ArtworkDTO {
        Description = "Lorem ipsum dolor sit amet",
        Id = new Guid("19459c8f-9b88-4c8f-b314-fb8cec67e225"),
        LikedByMe = false,
        Likes = 0,
        Owner = new OwnerDTO
        {
          Location = "Stockholm",
          ProfilePicture = "873c48f4-c353-4c75-b05d-f11167682187.jpg",
          Username = "knatte",
          SocialId = new Guid("5185fe67-a161-468f-ae16-575972553509")
        },
        Price = (decimal) 20000,
        PrimaryFile = new FileDTO
        {
            Height = 100,
            Name = "b4f3f751-2f0b-4c41-917c-64b159e4eb43.jpg",
            Width = 100
        },
        Published = new DateTime(2020, 2, 26, 13, 38, 45),
        SecondaryFile = null,
        Tags = new List<string>() { "summer" },
        TertiaryFile = null,
        Title = "Lorem ipsum"
      };

      //Act
      ArtworkDTO act = artworkService.Get(artworkId, null);

      //Assert
      act.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void CreateArtworkTest()
    {
      //Arrange
      var artworkToCreate = new ArtworkForCreationDTO {
        Description = "Föreställer en bil och en ananas",
        Title = "Ett nytt konstverk",
        Price = 9000,
        PrimaryFile = "a4d7cea7-1831-4fda-8267-4b395f8efc92.jpg",
        Tags = new List<string>()
      };
      var socialId = new Guid("5185fe67-a161-468f-ae16-575972553509");
      var artworkService = new ArtworkService(_contextMock.Object, _mapperMock.Object);
      var expected = new ArtworkDTO() {
        Description = "Föreställer en bil och en ananas",
        LikedByMe = false,
        Owner = null,
        Price = 9000,
        PrimaryFile = new FileDTO {
          Name = "a4d7cea7-1831-4fda-8267-4b395f8efc92.jpg",
        },
        SecondaryFile = null,
        TertiaryFile = null,
        Tags = new List<string>(),
        Title = "Ett nytt konstverk"
      };

      //Act
      ArtworkDTO act = artworkService.Create(artworkToCreate, socialId);

      //Assert
      act.Should().BeEquivalentTo(expected, options => options.Excluding(o => o.Id).Excluding(o => o.Published));
    }

    [Fact]
    public void CreateArtworkWithoutUsernameTest()
    {
      //Arrange
      var artworkToCreate = new ArtworkForCreationDTO {
        Description = "Föreställer en bil och en ananas",
        Title = "Ett nytt konstverk",
        Price = 9000,
        PrimaryFile = "a4d7cea7-1831-4fda-8267-4b395f8efc92.jpg",
        Tags = new List<string>()
      };
      var artworkService = new ArtworkService(_contextMock.Object, _mapperMock.Object);
      ArtworkDTO expected = null;

      //Act
      ArtworkDTO act = artworkService.Create(artworkToCreate, new Guid());

      //Assert
      act.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void UpdateArtworkTest()
    {
      //Arrange
      var artworkId = new Guid("19459c8f-9b88-4c8f-b314-fb8cec67e225");
      var artworkToUpdate = new ArtworkForUpdateDTO {
        Description = "Föreställer en bil och en ananas",
        Title = "Ett nytt konstverk",
        Price = 9000,
        Tags = new List<string>() { "summer" }
      };
      var mySocialId = new Guid("5185fe67-a161-468f-ae16-575972553509");
      var artworkService = new ArtworkService(_contextMock.Object, _mapperMock.Object);
      var expected = new ArtworkDTO() {
        Description = "Föreställer en bil och en ananas",
        LikedByMe = false,
        Owner = null,
        Price = 9000,
        PrimaryFile = new FileDTO {
          Name = "a4d7cea7-1831-4fda-8267-4b395f8efc92.jpg",
        },
        SecondaryFile = null,
        TertiaryFile = null,
        Tags = new List<string>(),
        Title = "Ett nytt konstverk"
      };

      //Act
      ArtworkDTO act = artworkService.Update(artworkToUpdate, artworkId, mySocialId);

      //Assert
      act.Should().BeEquivalentTo(expected, options => options.Excluding(o => o.Id).Excluding(o => o.Published));
    }

    [Fact]
    public void GetAllTagsTest()
    {
      //Arrange
      var artworkService = new ArtworkService(_contextMock.Object, _mapperMock.Object);

      //Act
      List<string> act = artworkService.GetTags();

      //Assert
      act.Should().HaveCount(4);
    }

    [Fact]
    public void GetTagsForArtworkTest()
    {
      //Arrange
      var artworkId = new Guid("19459c8f-9b88-4c8f-b314-fb8cec67e225");
      var artworkService = new ArtworkService(_contextMock.Object, _mapperMock.Object);
      var expected = new List<TagDTO> {
        new TagDTO {
          Tag = "summer"
        }
      };

      //Act
      List<TagDTO> act = artworkService.GetTags(artworkId);

      //Assert
      act.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void LikeTest()
    {
      //Arrange
      var artworkId = new Guid("19459c8f-9b88-4c8f-b314-fb8cec67e225");
      var socialId = new Guid("5185fe67-a161-468f-ae16-575972553509");
      var artworkService = new ArtworkService(_contextMock.Object, _mapperMock.Object);
      

      //Act
      Guid randomString;
      bool act = artworkService.Like(artworkId, socialId, out randomString);

      //Assert
      act.Should().Be(true);
    }

    [Fact]
    public void LikeWithoutUsernameTest()
    {
      //Arrange
      var artworkId = new Guid("19459c8f-9b88-4c8f-b314-fb8cec67e225");
      var artworkService = new ArtworkService(_contextMock.Object, _mapperMock.Object);

      //Act
      Guid randomString;
      bool act = artworkService.Like(artworkId, new Guid(), out randomString);

      //Assert
      act.Should().Be(false);
    }

    [Fact]
    public void UnlikeTest()
    {
      //Arrange
      var artworkId = new Guid("19459c8f-9b88-4c8f-b314-fb8cec67e225");
      var socialId = Guid.NewGuid();
      var artworkService = new ArtworkService(_contextMock.Object, _mapperMock.Object);

      //Act&Assert
      Guid owner;
      artworkService.Unlike(artworkId, socialId, out owner);
    }



    private List<Artwork> GetInitialArtworkEntities()
    {
      return new List<Artwork> {
        new Artwork {
          Id = 1,
          PublicId = new Guid("19459c8f-9b88-4c8f-b314-fb8cec67e225"),
          User = new User {
            Username = "knatte",
            SocialId = new Guid("5185fe67-a161-468f-ae16-575972553509"),
            File = new File {
              Name = "873c48f4-c353-4c75-b05d-f11167682187.jpg"
            },
            UserProfile = new UserProfile {
              Location = "Stockholm"
            }
          },
          PrimaryFileId = 1,
          PrimaryFile = new File {
            Name = "b4f3f751-2f0b-4c41-917c-64b159e4eb43.jpg",
            Width = 100,
            Height = 100
          },
          Title = "Lorem ipsum",
          Description = "Lorem ipsum dolor sit amet",
          Published = new DateTime(2020, 2, 26, 13, 38, 45),
          Price = 20000,
          Likes = new List<Like>(),
          Tags = new List<Tag>() {
            new Tag {
              Id = 1,
              Title = "summer"
            }
          }
        }
      };
    }

    private List<User> GetInitialUserEntities()
    {
      return new List<User> {
        new User {
          Id = 1,
          Username = "knatte",
          SocialId = new Guid("5185fe67-a161-468f-ae16-575972553509"),
        },
        new User {
          Id = 2,
          Username = "tjatte",
          SocialId = new Guid("7e776776-4f76-44c1-95cf-4a2e0fc2b156"),
        }
      };
    }

    private List<File> GetInitialFileEntities()
    {
      return new List<File> {
        new File {
          Id = 1,
          Name = "fa6251b7-e845-4e88-a1d7-ce8810c49b69.jpg",
          Width = 300,
          Height = 300
        }
      };
    }

    private List<Tag> GetInitialTagEntities()
    {
      return new List<Tag> {
        new Tag {
          Id = 1,
          Title = "summer",
          Artworks = new List<Artwork>()
        },
        new Tag {
          Id = 2,
          Title = "autumn",
          Artworks = new List<Artwork>()
        },
        new Tag {
          Id = 3,
          Title = "winter",
          Artworks = new List<Artwork>()
        },
        new Tag {
          Id = 4,
          Title = "spring",
          Artworks = new List<Artwork>()
        },
      };
    }

    private List<Like> GetInitialLikeEntities()
    {
      return new List<Like>();
    }

    private ArtworkDTO GetMapperReturnValue() {
      return new ArtworkDTO {
        Description = "Föreställer en bil och en ananas",
        Title = "Ett nytt konstverk",
        Price = 9000,
        PrimaryFile = new FileDTO {
          Name = "a4d7cea7-1831-4fda-8267-4b395f8efc92.jpg",
        },
        Tags = new List<string>()
      };
    }
  }
}
