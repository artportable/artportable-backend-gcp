using System;
using Artportable.API.DTOs;
using Artportable.API.Services;
using Stream;

namespace Services
{
  public class ActivityService : IActivityService
  {
    private readonly StreamClient _streamClient;
    public ActivityService()
    {
      _streamClient = new StreamClient("x595terv4p22", "knmjmhh6uxxe6khxtzaaxjp9vawmqskyxwhyrm86jd4vkjcjgkbk69uvc3c37tpr");
    }
    public TokenDTO ConnectUser(string username)
    {
      try
      {
        var token = _streamClient.CreateUserToken(username);

        return new TokenDTO {
          Token = token
        };
      }
      catch (Exception e)
      {
        //Add logging
        throw new Exception($"Unknown error when trying to register user with username {username}", e);
      }
    }

    public void CreateActivity()
    {
      // var userFeed = _streamClient.Feed("notification", "jimpa");
      var userFeed2 = _streamClient.Feed("user", "ronnyconny");
      
      var activity = new Activity("1", "like", "3")
      {
        ForeignId = "post:42"
      };

      // var feed = userFeed.FollowFeed(userFeed2);
      userFeed2.AddActivity(activity);
    }

    // public void CreateNotificationFeed()
    // {
    //   var userFeed = _streamClient.
    //   var activity = new Activity("1", "like", "3")
    //   {
    //     ForeignId = "post:42"
    //   };

    //   userFeed.AddActivity(activity);
    // }

    public FeedDTO GetFeed(string username)
    {
      var userFeed = _streamClient.Feed("jimpa", "jimpa");
      var activity = new Activity("1", "like", "3")
      {
        ForeignId = "post:42"
      };

      userFeed.AddActivity(activity);

      return new FeedDTO();
    }

    public void Follow(string username) {
      var userFeed = _streamClient.Feed("jimpa", "jimpa");
      var userFeed2 = _streamClient.Feed("ronnyconny", "ronnyconny");
      userFeed.FollowFeed(userFeed2);

      // var activity = new Activity("1", "like", "3")
      // {
      //   ForeignId = "post:42"
      // };

      // userFeed.AddActivity(activity);
    }
  }
}