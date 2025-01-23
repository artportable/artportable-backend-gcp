using System;
using System.Collections.Generic;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Artportable.API.Enums;
using Artportable.API.Services;
using EntityFrameworkCoreMock;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Artportable.ImageApi.Tests
{
    public class ConnectionServiceTests
    {
        DbContextMock<APContext> _contextMock;
        DbContextOptions<APContext> CtxOptions { get; } =
            new DbContextOptionsBuilder<APContext>().Options;

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
            var expected = new List<RecommendationDTO>
            {
                new RecommendationDTO
                {
                    Username = "fnatte",
                    SocialId = new Guid("35c07292-557d-4e67-8637-68cd9c0235a0"),
                    Location = "Stockholm",
                    ProfilePicture = "eb52120a-43b5-40e0-a7c0-f5f8042f8e77.jpg",
                },
                new RecommendationDTO
                {
                    Username = "tjatte",
                    SocialId = new Guid("e6ec400b-a0ef-4b0e-8151-1654676ed4ca"),
                    Location = "Stockholm",
                    ProfilePicture = "96ac2c93-a7c5-4ac8-aa66-2ed1d1c59745.jpg",
                },
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
            var socialId = new Guid("5185fe67-a161-468f-ae16-575972553509");
            var mySocialId = new Guid("e6ec400b-a0ef-4b0e-8151-1654676ed4ca");
            var connectionService = new ConnectionService(_contextMock.Object);

            //Act
            bool act = connectionService.Follow(socialId, mySocialId);

            //Assert
            act.Should().Be(true);
        }

        [Fact]
        public void FollowithoutSocialIdTest()
        {
            //Arrange
            var socialId = Guid.NewGuid();
            var connectionService = new ConnectionService(_contextMock.Object);

            //Act
            bool act = connectionService.Follow(socialId, null);

            //Assert
            act.Should().Be(false);
        }

        [Fact]
        public void UnfollowTest()
        {
            //Arrange
            var socialId = Guid.NewGuid();
            var mySocialId = Guid.NewGuid();
            var connectionService = new ConnectionService(_contextMock.Object);

            //Act&Assert
            connectionService.Unfollow(socialId, mySocialId);
        }

        private List<User> GetInitialUserEntities()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "knatte",
                    SocialId = new Guid("5185fe67-a161-468f-ae16-575972553509"),
                    Artworks = new List<Artwork>(),
                    Subscription = new Subscription { Id = (int)ProductEnum.Bas },
                },
                new User
                {
                    Id = 2,
                    Username = "tjatte",
                    SocialId = new Guid("e6ec400b-a0ef-4b0e-8151-1654676ed4ca"),
                    UserProfile = new UserProfile { Location = "Stockholm" },
                    File = new File { Name = "96ac2c93-a7c5-4ac8-aa66-2ed1d1c59745.jpg" },
                    Artworks = new List<Artwork>(),
                    Subscription = new Subscription { Id = (int)ProductEnum.PortfolioPremium },
                },
                new User
                {
                    Id = 3,
                    Username = "fnatte",
                    SocialId = new Guid("35c07292-557d-4e67-8637-68cd9c0235a0"),
                    UserProfile = new UserProfile { Location = "Stockholm" },
                    File = new File { Name = "eb52120a-43b5-40e0-a7c0-f5f8042f8e77.jpg" },
                    Artworks = new List<Artwork>
                    {
                        new Artwork
                        {
                            Id = 2,
                            User = new User { Id = 3, Username = "fnatte" },
                            Tags = new List<Tag>
                            {
                                new Tag { Id = 1, Title = "Tag1" },
                            },
                        },
                    },
                    Subscription = new Subscription { Id = (int)ProductEnum.PortfolioPremium },
                },
                new User
                {
                    Id = 4,
                    Username = "kalle",
                    SocialId = new Guid("3852ebe7-484c-4fe9-8cea-69ba3e612a8e"),
                    UserProfile = new UserProfile { Location = "Stockholm" },
                    File = new File { Name = "eb52120a-43b5-40e0-a7c0-f5f8042f8e77.jpg" },
                    Artworks = new List<Artwork>
                    {
                        new Artwork
                        {
                            Id = 3,
                            User = new User { Id = 4, Username = "kalle" },
                            Tags = new List<Tag>
                            {
                                new Tag { Id = 1, Title = "Tag1" },
                            },
                        },
                    },
                    Subscription = new Subscription { Id = (int)ProductEnum.PortfolioPremium },
                },
            };
        }

        private List<Connection> GetInitialConnectionEntities()
        {
            return new List<Connection>
            {
                new Connection
                {
                    Id = 1,
                    Followee = new User { Id = 1, Username = "knatte" },
                    Follower = new User { Id = 2, Username = "tjatte" },
                },
                new Connection
                {
                    Id = 2,
                    Followee = new User
                    {
                        Id = 4,
                        Username = "kalle",
                        Artworks = new List<Artwork>
                        {
                            new Artwork
                            {
                                Id = 3,
                                User = new User { Id = 3, Username = "kalle" },
                                Tags = new List<Tag>
                                {
                                    new Tag { Id = 1, Title = "Tag1" },
                                },
                            },
                        },
                    },
                    Follower = new User { Id = 1, Username = "knatte" },
                    FollowerId = 1,
                    FolloweeId = 4,
                },
            };
        }

        private List<Like> GetInitialLikesEntities()
        {
            return new List<Like>
            {
                new Like
                {
                    Id = 1,
                    User = new User { Id = 1, Username = "knatte" },
                    Artwork = new Artwork
                    {
                        Id = 1,
                        User = new User { Id = 2, Username = "tjatte" },
                        Tags = new List<Tag>
                        {
                            new Tag { Id = 1, Title = "Tag1" },
                        },
                    },
                },
            };
        }
    }
}
