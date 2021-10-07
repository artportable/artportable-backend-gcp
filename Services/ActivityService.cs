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
    public TokenDTO ConnectUser(string userId)
    {
      try
      {
        var token = _streamClient.CreateUserToken(userId);

        return new TokenDTO
        {
          Token = token
        };
      }
      catch (Exception e)
      {
        //Add logging
        throw new Exception($"Unknown error when trying to register user with socialId {userId}", e);
      }
    }
    public async Task Follow(Guid follower, Guid followee)
    {
      string followerStr = follower.ToString();
      string followeeStr = followee.ToString();

      var followerFeed = _streamClient.Feed("user_timeline", followerStr);
      await followerFeed.FollowFeed($"user", followeeStr);
      var followeeFeed = _streamClient.Feed("notification", followeeStr);
      var followActivity = new Activity($"{followerStr}", "follow", followeeStr)
      {
        ForeignId = $"{followerStr}:follow:{followeeStr}",
        Time = DateTime.Now.ToUniversalTime(),
        To = new List<string>(){
          $"user:{followerStr}"
        }
      };
      await followeeFeed.AddActivity(followActivity);
    }
    public async Task UnFollow(Guid follower, Guid followee)
    {
      string followerStr = follower.ToString();
      string followeeStr = followee.ToString();

      var followerFeed = _streamClient.Feed("user_timeline", followerStr);
      var followeeFeed = _streamClient.Feed("notification", followeeStr);
      await followerFeed.UnfollowFeed($"user", followeeStr);
      await followeeFeed.RemoveActivity($"{followerStr}:follow:{followeeStr}", true);
    }
    public async Task LikeArtwork(Guid id, Guid mySocialId, Guid owner)
    {
      string mySocialIdStr = mySocialId.ToString();

      var activity = new Activity($"{mySocialId}", "like", $"artwork:{id.ToString()}")
      {
        ForeignId = $"like:artwork-{id.ToString()}:{mySocialIdStr}",
        Time = DateTime.Now.ToUniversalTime(),
        To = new List<string>(){
          $"notification:{owner.ToString()}"
        }
      };
      var artwork = new Dictionary<string, object>();
      artwork.Add("id", id);
      activity.SetData("artwork", artwork);
      var myFeed = _streamClient.Feed("user", mySocialIdStr);
      await myFeed.AddActivity(activity);
    }


    public async Task UnLikeArtwork(Guid id, Guid mySocialId, Guid owner)
    {
      string mySocialIdStr = mySocialId.ToString();

      var myFeed = _streamClient.Feed("user", mySocialIdStr);
      var ownerFeed = _streamClient.Feed("notification", owner.ToString());
      await myFeed.RemoveActivity($"like:artwork-{id.ToString()}:{mySocialIdStr}", true);
      await ownerFeed.RemoveActivity($"like:artwork-{id.ToString()}:{mySocialIdStr}", true);
    }
    public async Task CreateArtwork(Guid id, string title, Guid mySocialId)
    {
      var myFeed = _streamClient.Feed("user", mySocialId.ToString());
      var activity = new Activity($"{mySocialId.ToString()}", "upload", $"artwork:{id.ToString()}")
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

    public async Task UpdateArtwork(Guid id, string title, Guid mySocialId)
    {
      var myFeed = _streamClient.Feed("user", mySocialId.ToString());
      var activity = new Activity($"{mySocialId.ToString()}", "update", $"artwork:{id.ToString()}")
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