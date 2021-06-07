using System;
using Artportable.API.DTOs;
using Artportable.API.Services;
using StreamChat;

namespace Services
{
  public class MessageService : IMessageService
  {
    private readonly Client _streamChatClient;
    public MessageService()
    {
      _streamChatClient = new Client("tqqdjfyxfwjm", "jwk46ru5wattrzt2642xugnj7g4uzp5sv6vkmd3m6yxtxcukhcq8tv2jthxgwmt4"); 
    }
    public TokenDTO ConnectUser(string username)
    {
      try
      {
        var token = _streamChatClient.CreateToken(username);

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