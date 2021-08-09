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
      _contextMock.CreateDbSetMock(x => x.Likes, GetInitialLikesEntities());

    }

    [Fact]
    public void GetRecommendationsTest()
    {
      //Arrange
      var myUsername = "knatte";
      var connectionService = new ConnectionService(_contextMock.Object);
      var expected = new List<RecommendationDTO> {
        new RecommendationDTO {
          Username = "fnatte",
          Location = "Stockholm",
          ProfilePicture = "eb52120a-43b5-40e0-a7c0-f5f8042f8e77.jpg"
        },
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
          Artworks = new List<Artwork> ()
        },
        new User {
          Id = 2,
          Username = "tjatte",
          UserProfile = new UserProfile {
            Location = "Stockholm"
          },
          File = new File {
            Name = "96ac2c93-a7c5-4ac8-aa66-2ed1d1c59745.jpg"
          },
          Artworks = new List<Artwork> ()
        },
        new User {
          Id = 3,
          Username = "fnatte",
          UserProfile = new UserProfile {
            Location = "Stockholm"
          },
          File = new File {
            Name = "eb52120a-43b5-40e0-a7c0-f5f8042f8e77.jpg"
          },
          Artworks = new List<Artwork> {
            new Artwork {
              Id = 2,
              User = new User {
                        Id = 3,
                        Username = "fnatte",
              },
              Tags = new List<Tag> {
                new Tag {
                  Id = 1,
                  Title = "Tag1"
                }
              }
            }
          }
        },
        new User {
          Id = 4,
          Username = "kalle",
          UserProfile = new UserProfile {
            Location = "Stockholm"
          },
          File = new File {
            Name = "eb52120a-43b5-40e0-a7c0-f5f8042f8e77.jpg"
          },
          Artworks = new List<Artwork> {
              new Artwork {
                Id = 3,
                User = new User {
                          Id = 4,
                          Username = "kalle",
                },
                Tags = new List<Tag> {
                  new Tag {
                    Id = 1,
                    Title = "Tag1"
                  }
                }
              }
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
            Username = "tjatte",
            }
          },
        new Connection {
          Id = 2,
          Followee = new User {
            Id = 4,
            Username = "kalle",
            Artworks = new List<Artwork> {
              new Artwork {
                Id = 3,
                User = new User {
                          Id = 3,
                          Username = "kalle",
                },
                Tags = new List<Tag> {
                  new Tag {
                    Id = 1,
                    Title = "Tag1"
                  }
                }
              }
            }
          },
          Follower = new User {
            Id = 1,
            Username = "knatte",
            },
          FollowerId = 1,
          FolloweeId = 4
          },
        };
    }

    private List<Like> GetInitialLikesEntities()
    {
      return new List<Like> {
        new Like {
          Id = 1,
          User = new User {
            Id = 1,
            Username = "knatte",
          },
          Artwork = new Artwork {
            Id = 1,
            User = new User {
                       Id = 2,
                       Username = "tjatte",
            },
            Tags = new List<Tag> {
              new Tag {
                Id = 1,
                Title = "Tag1"
              }
            }
          }
        }
      };
    }
  }
}
