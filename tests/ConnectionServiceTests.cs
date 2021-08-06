using Xunit;
using FluentAssertions;
using Artportable.API.Services;
using Artportable.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Artportable.API.Entities.Models;
using EntityFrameworkCoreMock;
using Artportable.API.DTOs;

namespace Artportable.ImageApi.Tests
{
  public class ConnectionServiceTests
  {
    DbContextMock<APContext> _contextMock;
    DbContextOptions<APContext> CtxOptions { get; } = new DbContextOptionsBuilder<APContext>().Options;


    public ConnectionServiceTests()
    {
      _contextMock = new DbContextMock<APContext>(CtxOptions);
      _contextMock.CreateDbSetMock(x => x.Users, GetInitialUserEntities());
      _contextMock.CreateDbSetMock(x => x.Connections, GetInitialConnectionEntities());
    }

    [Fact]
    public void GetRecommendationsTest()
    {
      //Arrange
      var myUsername = "knatte";
      var connectionService = new ConnectionService(_contextMock.Object);
      var expected = new List<RecommendationDTO> {
        new RecommendationDTO {
          Username = "tjatte",
          Location = "Stockholm",
          ProfilePicture = "96ac2c93-a7c5-4ac8-aa66-2ed1d1c59745.jpg"
        }
      };

      //Act
      List<RecommendationDTO> act = connectionService.GetRecommendations(myUsername);

      //Assert
      act.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void FollowTest()
    {
      //Arrange
      var username = "tjatte";
      var myUsername = "knatte";
      var connectionService = new ConnectionService(_contextMock.Object);

      //Act
      bool act = connectionService.Follow(username, myUsername);

      //Assert
      act.Should().Be(true);
    }

    [Fact]
    public void FollowithoutUsernameTest()
    {
      //Arrange
      var username = "tjatte";
      var connectionService = new ConnectionService(_contextMock.Object);

      //Act
      bool act = connectionService.Follow(username, null);

      //Assert
      act.Should().Be(false);
    }

    [Fact]
    public void UnfollowTest()
    {
      //Arrange
      var username = "tjatte";
      var myUsername = "knatte";
      var connectionService = new ConnectionService(_contextMock.Object);

      //Act&Assert
      connectionService.Unfollow(username, myUsername);
    }



    private List<User> GetInitialUserEntities()
    {
      return new List<User> {
        new User {
          Id = 1,
          Username = "knatte",
        },
        new User {
          Id = 2,
          Username = "tjatte",
          UserProfile = new UserProfile {
            Location = "Stockholm"
          },
          File = new File {
            Name = "96ac2c93-a7c5-4ac8-aa66-2ed1d1c59745.jpg"
          }
        }
      };
    }

    private List<Connection> GetInitialConnectionEntities()
    {
      return new List<Connection> {
        new Connection {
          Id = 1,
          Followee = new User {
            Id = 1,
            Username = "knatte",
          },
          Follower = new User {
            Id = 2,
            Username = "tjatte"
          }
        }
      };
    }
  }
}
