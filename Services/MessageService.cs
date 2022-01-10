using System;
using Artportable.API.DTOs;
using Artportable.API.Options;
using Artportable.API.Services;
using Microsoft.Extensions.Options;
using StreamChat;

namespace Services
{
  public class MessageService : IMessageService
  {
    private readonly Client _streamChatClient;
    private readonly string _streamSenderId;
    public MessageService(IOptions<StreamOptions> streamSettings)
    {
      _streamChatClient = new Client(streamSettings.Value.ApiKey, streamSettings.Value.ApiSecret);
      _streamSenderId = streamSettings.Value.SenderUserId;
    }

    public TokenDTO ConnectUser(string userId)
    {
      try
      {
        var token = _streamChatClient.CreateToken(userId);

        return new TokenDTO {
          Token = token
        };
      }
      catch (Exception e)
      {
        //Add logging
        throw new Exception($"Unknown error when trying to register user with social id {userId}", e);
      }
    }

    public async void PurchaseRequest(string email, string message, string artworkUrl, string artworkName, string artistId)
    { 
      var exportedUser = new StreamChat.ExportedUser();
      // See if user exists
      try
      {
        exportedUser = await _streamChatClient.Users.Export(artistId);
      }
      catch (Exception)
      {
        //user doesn't exist - add logging.
        return;
      }
      try
      {
        var endOfMessage = "";
        if(!string.IsNullOrEmpty(message)){
          endOfMessage = "\n\n Message from the user:\n" + message;
        }
        var toBeSent = new MessageInput()
        {
          Text = $"Someone is interested in your artwork, {artworkName} ({artworkUrl}).\nPlease send an email to {email}. {endOfMessage}"
        };
        var data = new GenericData();
        data.SetData("name", "Purchase Requests");
        var channel = _streamChatClient.Channel("messaging", $"purchase-requests-{artistId}",data); 
        var chanFromDB = await channel.Create(_streamSenderId, new string[] {artistId});
        await channel.SendMessage(toBeSent, _streamSenderId);

      }
      catch (Exception e)
      {
        //Add logging
        throw new Exception($"Unknown error when trying to send artwork purchase request message with message: {message}, artworkName: {artworkName}, artwork url: {artworkUrl}, artistId: {artistId}, to email: {email}.", e);
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