using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Options;
using Artportable.API.Services;
using Mandrill;
using Mandrill.Model;
using Microsoft.Extensions.Options;
using StreamChat;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
  public class MessageService : IMessageService
  {
    private readonly Client _streamChatClient;
    private readonly string _streamSenderId;
    private readonly string _mandrillApiKey;
    private readonly string _mandrillFromEmail;
    private APContext _context;

    private IMandrillApi _mandrillApi;

    public MessageService(APContext apContext, IOptions<StreamOptions> streamSettings, IOptions<MandrillOptions> mandrillSettings, IMandrillApi mandrillApi)
    {
      _streamChatClient = new Client(streamSettings.Value.ApiKey, streamSettings.Value.ApiSecret);
      _streamSenderId = streamSettings.Value.SenderUserId;
      _mandrillApiKey = mandrillSettings.Value.ApiKey;
      _mandrillFromEmail = mandrillSettings.Value.FromEmail;
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
      _mandrillApi = mandrillApi;
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

    public void PurchaseRequest(string email, string message, string artworkUrl, string artworkName, string artistId)
    { 
      try
      {
        //get artist from DB
        var user = _context.Users.First(u => u.SocialId.ToString() == artistId);

        //send chat message
        var toBeSent = new MessageInput();
        if(user.Language == "sv"){
          var endOfMessage = "";
          if(!string.IsNullOrEmpty(message)){
            endOfMessage = "\n\n Meddelande från användaren :\n" + message;
          }
          toBeSent = new MessageInput()
          {
            Text = $"Grattis! Du har fått en förfrågan gällande ditt verk, {artworkName} ({artworkUrl}).\nVänligen maila dem på {email}. {endOfMessage}"
          };
        }else{
          var endOfMessage = "";
          if(!string.IsNullOrEmpty(message)){
            endOfMessage = "\n\n Message from the user:\n" + message;
          }
          toBeSent = new MessageInput()
          {
            Text = $"Someone is interested in your artwork, {artworkName} ({artworkUrl}).\nPlease send an email to {email}. {endOfMessage}"
          };
        }
        var data = new GenericData();
        data.SetData("name", "Purchase Requests");
        var channel = _streamChatClient.Channel("messaging", $"purchase-requests-{artistId}",data); 
        var chanFromDB = channel.Create(_streamSenderId, new string[] {artistId});
        channel.SendMessage(toBeSent, _streamSenderId);
        
        //send email
        var mandrillMessage = new MandrillMessage();
        mandrillMessage.FromEmail = _mandrillFromEmail;
        mandrillMessage.AddTo(user.Email);
        mandrillMessage.ReplyTo = email;
        mandrillMessage.AddGlobalMergeVars("ap_message", message);
        mandrillMessage.AddGlobalMergeVars("ap_artwork_name",artworkName);
        mandrillMessage.AddGlobalMergeVars("ap_artwork_url", artworkUrl);
        mandrillMessage.AddGlobalMergeVars("ap_reply_to",email);
        
        if(user.Language == "sv"){
          var result = _mandrillApi.Messages.SendTemplateAsync(mandrillMessage,"artworkpurchaserequestsv");
        }else{
          var result = _mandrillApi.Messages.SendTemplateAsync(mandrillMessage,"artworkpurchaserequest");
        }

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