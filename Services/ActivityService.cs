using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Services;
using Microsoft.Extensions.Options;
using Options;
using Stream;

namespace Services
{
  public class ActivityService : IActivityService
  {
    private readonly StreamClient _streamClient;
    public ActivityService(IOptions<StreamOptions> streamSettings)
    {
      _streamClient = new StreamClient(streamSettings.Value.ApiKey, streamSettings.Value.ApiSecret);
    }
    public TokenDTO ConnectUser(string username)
    {
      try
      {
        var token = _streamClient.CreateUserToken(username);

        return new TokenDTO
        {
          Token = token
        };
      }
      catch (Exception e)
      {
        //Add logging
        throw new Exception($"Unknown error when trying to register user with username {username}", e);
      }
    }
    public async Task Follow(string follower, string followee)
    {
      var followerFeed = _streamClient.Feed("user_timeline", follower);
      await followerFeed.FollowFeed($"user", followee);
      var followeeFeed = _streamClient.Feed("notification", followee);
      var followActivity = new Activity($"{follower}", "follow", followee)
      {
        ForeignId = $"{follower}:follow:{followee}",
        Time = DateTime.Now.ToUniversalTime(),
        To = new List<string>(){
          $"user:{follower}"
        }
      };
      await followeeFeed.AddActivity(followActivity);
    }
    public async Task UnFollow(string follower, string followee)
    {
      var followerFeed = _streamClient.Feed("user_timeline", follower);
      var followeeFeed = _streamClient.Feed("notification", followee);
      await followerFeed.UnfollowFeed($"user", followee);
      await followeeFeed.RemoveActivity($"{follower}:follow:{followee}", true);
    }
    public async Task LikeArtwork(Guid id, string myUsername, string owner)
    {
      var activity = new Activity($"{myUsername}", "like", $"artwork:{id.ToString()}")
      {
        ForeignId = $"like:artwork-{id.ToString()}:{myUsername}",
        Time = DateTime.Now.ToUniversalTime(),
        To = new List<string>(){
          $"notification:{owner}"
        }
      };
      var artwork = new Dictionary<string, object>();
      artwork.Add("id", id);
      activity.SetData("artwork", artwork);
      var myFeed = _streamClient.Feed("user", myUsername);
      await myFeed.AddActivity(activity);
    }


    public async Task UnLikeArtwork(Guid id, string myUsername, string owner)
    {
      var myFeed = _streamClient.Feed("user", myUsername);
      var ownerFeed = _streamClient.Feed("notification", owner);
      await myFeed.RemoveActivity($"like:artwork-{id.ToString()}:{myUsername}", true);
      await ownerFeed.RemoveActivity($"like:artwork-{id.ToString()}:{myUsername}", true);
    }
    public async Task CreateArtwork(Guid id, string title, string myUsername)
    {
      var myFeed = _streamClient.Feed("user", myUsername);
      var activity = new Activity($"{myUsername}", "upload", $"artwork:{id.ToString()}")
      {
        ForeignId = $"artwork:{id.ToString()}",
        Time = DateTime.Now.ToUniversalTime()
      };
      var artwork = new Dictionary<string, object>();
      artwork.Add("id", id);
      artwork.Add("title", title);
      activity.SetData("artwork", artwork);
      await myFeed.AddActivity(activity);
    }

    public async Task UpdateArtwork(Guid id, string title, string myUsername)
    {
      var myFeed = _streamClient.Feed("user", myUsername);
      var activity = new Activity($"{myUsername}", "update", $"artwork:{id.ToString()}")
      {
        ForeignId = $"artwork:{id.ToString()}",
        Time = DateTime.Now.ToUniversalTime()
      };
      var artwork = new Dictionary<string, object>();
      artwork.Add("id", id);
      artwork.Add("title", title);
      activity.SetData("artwork", artwork);
      await myFeed.AddActivity(activity);
    }
  }
}