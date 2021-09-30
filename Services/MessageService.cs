using System;
using Artportable.API.DTOs;
using Artportable.API.Services;
using Microsoft.Extensions.Options;
using Options;
using StreamChat;

namespace Services
{
  public class MessageService : IMessageService
  {
    private readonly Client _streamChatClient;
    private readonly IUserService _userService; 
    public MessageService(IOptions<StreamOptions> streamSettings, IUserService userService)
    {
      _streamChatClient = new Client(streamSettings.Value.ApiKey, streamSettings.Value.ApiSecret);
      _userService = userService;
    }

    public TokenDTO ConnectUser(string username)
    {
      try
      {
        var socialId = _userService.GetSocialId(username);
        var token = _streamChatClient.CreateToken(socialId.ToString());

        return new TokenDTO {
          Token = token,
          SocialId = socialId
        };
      }
      catch (Exception e)
      {
        //Add logging
        throw new Exception($"Unknown error when trying to register user with username {username}", e);
      }
    }

    public async void SyncUser(string username, string role)
    {
      // var user = new User() 
      // {
      //     ID = "bob-1",
      //     Role = Role.Admin
      // };
      // user.SetData("mycustomfield", "123");

      // await _streamChatClient.Users.UpsertMany(new User[] { user });


      throw new NotImplementedException();
    }

    public void SyncChannel(string username, string role)
    {
      throw new NotImplementedException();
    }
  }
}