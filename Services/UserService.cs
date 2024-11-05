using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Artportable.API.Enums;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artportable.API.Services
{
    public class UserService : IUserService
  {
    private APContext _context;
    private readonly IMapper _mapper;
    private readonly Random _random;
    public UserService(APContext apContext, IMapper mapper)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
      _mapper = mapper ??
        throw new ArgumentNullException(nameof(mapper));
      _random = new Random();
    }

    public string GetCustomerIdByUsername(string username)
    {
        var customerId = _context.Subscriptions
            .Join(_context.Users,
                subscription => subscription.Id,
                user => user.SubscriptionId,
                (subscription, user) => new { Subscription = subscription, User = user })
            .Where(joinResult => joinResult.User.Username == username)
            .Select(joinResult => joinResult.Subscription.CustomerId)
            .SingleOrDefault();

        return customerId;
    }


    public UserDTO Get(string username)
{
    var user = _context.Users
        .Where(u => u.Username == username)
        .Join(_context.UserProfiles,
            user => user.Id,
            profile => profile.UserId,
            (user, profile) => new { User = user, Profile = profile })
        .Join(_context.Subscriptions,
            userProfile => userProfile.User.Id,
            subscription => subscription.User.Id,
            (userProfile, subscription) => new { userProfile.User, userProfile.Profile, Subscription = subscription })
        .SingleOrDefault();

    return user != null ? new UserDTO()
    {
        Username = user.User.Username,
        Name = user.Profile.Name,
        Surname = user.Profile.Surname,
        Email = user.User.Email,
        DateOfBirth = user.Profile.DateOfBirth,
        Location = user.Profile.Location,
        Created = user.User.Created,
        MonthlyUser = user.User.MonthlyUser,
        ProductId = user.Subscription.ProductId,
        PhoneNumber = user.User.PhoneNumber,

    } : null;
}


    public List<UserDTO> GetAllArtists()
    {
        var user = _context.Users
        .Include(x => x.UserProfile)
        .Join(_context.Subscriptions, 
         x => x.SubscriptionId, y => y.User.SubscriptionId,
        (x, y) => new { User = x, Subscription = y })
        .Where(x => x.User.Subscription.ProductId != 1).Select(x => new UserDTO()
        { Username = x.User.Username, Surname = x.User.UserProfile.Surname, Name = x.User.UserProfile.Name}).ToList();
        return user;
    }


    public List<TinyUserDTO> Search(string q)
    {
      var users = _context.Users
        .Include(u => u.File)
        .Where(u => u.Username.Contains(q));

      return users.Select(u =>
        new TinyUserDTO
        {
          Username = u.Username,
          ProfilePicture = u.File.Name
        })
        .ToList();
    }

    public ConnectionsCountDTO GetConnectionsCount(string username){

      var followers = _context.Connections.Count(c => c.Followee.Username == username);
      var followees = _context.Connections.Count(c => c.Follower.Username == username);

      ConnectionsCountDTO socialsCount = new ConnectionsCountDTO
      { Followers = followers, 
      Followees = followees };
   
      return socialsCount;
    }
    
    public IEnumerable<TinyUserDTO> GetFollowers(string username)
    {
      var users = _context.Connections.Where(c => c.Followee.Username == username);

      return users.Select(c => new TinyUserDTO()
      {
        Username = c.Follower.Username,
        Email = c.Follower.Email,
        Name = c.Follower.UserProfile.Name,
        Surname = c.Follower.UserProfile.Surname,
        ProfilePicture = c.Follower.File != null ? c.Follower.File.Name : null,
        EmailInformedFollowersDate = c.Follower.EmailInformedFollowersDate,
        EmailDeclinedArtworkUpload = c.Follower.EmailDeclinedArtworkUpload
      });
    }

    public IEnumerable<TinyUserDTO> GetFollowees(string username)
    {
      var users = _context.Connections.Where(c => c.Follower.Username == username);

      return users.Select(c => new TinyUserDTO()
      {
        Username = c.Followee.Username,
        Email = c.Follower.Email,
        Name = c.Followee.UserProfile.Name,
        Surname = c.Followee.UserProfile.Surname,
        ProfilePicture = c.Followee.File != null ? c.Followee.File.Name : null,
        EmailDeclinedArtworkUpload= c.Followee.EmailDeclinedArtworkUpload
      });
    }

    public ProfileSummaryDTO GetProfileSummary(string username)
    {
      var user = _context.Users
        .Include(u => u.UserProfile)
        .Include(u => u.File)
        // .Include(u => u.FollowerRef)
        // .Include(u => u.FolloweeRef)
        .Include(u => u.Subscription)
        .Where(i => i.Username == username)
        .SingleOrDefault();

      if (user == null)
      {
        return null;
      }

      return new ProfileSummaryDTO()
      {
        Username = user.Username,
        SocialId = user.SocialId,
        Name = user.UserProfile.Name,
        Surname = user.UserProfile.Surname,
        ProfilePicture = user.File?.Name,
        Headline = user.UserProfile.Headline,
        Title = user.UserProfile.Title,
        Location = user.UserProfile.Location,
        Country = user.UserProfile.Country,
        State = user.UserProfile.State,
        City = user.UserProfile.City,
        HideLikedArtworks = user.UserProfile.HideLikedArtworks,
        EmailInformedFollowersDate = user.EmailInformedFollowersDate,
        EmailDeclinedArtworkUpload = user.EmailDeclinedArtworkUpload,
        ChosenColor = user.UserProfile.ChosenColor,
        ChosenLayout = user.UserProfile.ChosenLayout,
        ChosenCorners = user.UserProfile.ChosenCorners,
        ChosenFont = user.UserProfile.ChosenFont,
        ChosenFrame = user.UserProfile.ChosenFrame,
        ChosenShadow = user.UserProfile.ChosenShadow,

        Artworks = user.Subscription.ProductId != (int)ProductEnum.Bas ?
          _context.Artworks.Count(a => a.UserId == user.Id) :
          _context.Artworks.Count(a => a.UserId == user.Id)
      };
    }

    public ProfileDTO GetProfile(string username, string myUsername)
    {
      var profile = _context.UserProfiles
        .Include(up => up.User)
        .ThenInclude(u => u.File)
        .Include(up => up.User.CoverPhotoFile)
        .Include(up => up.Educations)
        .Include(up => up.Exhibitions)
        .Where(i => i.User.Username == username)
        .SingleOrDefault();

      if (profile == null)
      {
        return null;
      }

      var dto = _mapper.Map<ProfileDTO>(profile);

      if (myUsername != null)
      {
        dto.FollowedByMe = _context.Connections.Any(c => c.Followee.Username == username && c.Follower.Username == myUsername);
      }

      return dto;
    }

    public ProfileDTO UpdateProfile(string username, UpdateProfileDTO updatedProfile)
    {
      var rowToUpdate = _context.UserProfiles
        .Include(up => up.User)
        .Include(up => up.User.File)
        .Include(up => up.User.CoverPhotoFile)
        .Include(up => up.Educations)
        .Include(up => up.Exhibitions)
        .FirstOrDefault(up => up.User.Username == username);

      if (rowToUpdate == null)
      {
        return null;
      }

      setSafely(updatedProfile.Headline, val => { rowToUpdate.Headline = val; });
      setSafely(updatedProfile.Title, val => { rowToUpdate.Title = val; });
      setSafely(updatedProfile.Location, val => { rowToUpdate.Location = val; });
      setSafely(updatedProfile.Country, val => { rowToUpdate.Country = val; });
      setSafely(updatedProfile.State, val => { rowToUpdate.State = val; });
      setSafely(updatedProfile.City, val => { rowToUpdate.City = val; });
      setSafely(updatedProfile.Name, val => { rowToUpdate.Name = val; });
      setSafely(updatedProfile.Surname, val => { rowToUpdate.Surname = val; });
      setSafely(updatedProfile.About, val => { rowToUpdate.About = val; });
      setSafely(updatedProfile.InspiredBy, val => { rowToUpdate.InspiredBy = val; });
      setSafely(updatedProfile.Studio?.Text, val => { rowToUpdate.StudioText = val; });
      setSafely(updatedProfile.Studio?.Location, val => { rowToUpdate.StudioLocation = val; });
      setSafely(updatedProfile.SocialMedia?.Website, val => { rowToUpdate.Website = val; });
      setSafely(updatedProfile.SocialMedia?.Instagram, val => { rowToUpdate.InstagramUrl = val; });
      setSafely(updatedProfile.SocialMedia?.Facebook, val => { rowToUpdate.FacebookUrl = val; });
      setSafely(updatedProfile.SocialMedia?.LinkedIn, val => { rowToUpdate.LinkedInUrl = val; });
      setSafely(updatedProfile.SocialMedia?.Behance, val => { rowToUpdate.BehanceUrl = val; });
      setSafely(updatedProfile.SocialMedia?.Dribble, val => { rowToUpdate.DribbleUrl = val; });
      setSafely(updatedProfile.ChosenColor, val => { rowToUpdate.ChosenColor = val; });
      setSafely(updatedProfile.ChosenCorners, val => { rowToUpdate.ChosenCorners = val; });
      setSafely(updatedProfile.ChosenFont, val => { rowToUpdate.ChosenFont = val; });
      setSafely(updatedProfile.ChosenFrame, val => { rowToUpdate.ChosenFrame = val; });
      setSafely(updatedProfile.ChosenLayout, val => { rowToUpdate.ChosenLayout = val; });
      setSafely(updatedProfile.ChosenShadow, val => { rowToUpdate.ChosenShadow = val; });    
      setSafely(updatedProfile.EmailInformedFollowersDate, val => rowToUpdate.User.EmailInformedFollowersDate = val);

      if (updatedProfile.EmailDeclinedArtworkUpload.HasValue)
      {
          rowToUpdate.User.EmailDeclinedArtworkUpload = updatedProfile.EmailDeclinedArtworkUpload.Value;
        
      }


      if (updatedProfile.Educations != null)
      {
        rowToUpdate.Educations = updatedProfile.Educations.Select(e => new Education()
        {
          Name = e.Name,
          From = e.From,
          To = e.To
        }
        ).ToList();
      }

      if (updatedProfile.Exhibitions != null)
      {
        rowToUpdate.Exhibitions = updatedProfile.Exhibitions.Select(e => new Exhibition()
        {
          Name = e.Name,
          Place = e.Place,
          From = e.From,
          To = e.To
        }
        ).ToList();
      }

      _context.SaveChanges();

      var dto = _mapper.Map<ProfileDTO>(rowToUpdate);

      return dto;
    }

    public List<SimilarProfileDTO> GetSimilarProfiles(string username)
    {
      //Get all tags used by user
      var tagsUsedByUser = _context.Tags
        .Include(t => t.Artworks)
        .ThenInclude(a => a.User)
        .Where(t => t.Artworks.Any(a => a.User.Username == username))
        .ToList();

      //Get 3 random artists if no tags returned
      if (!tagsUsedByUser.Any())
      {
        return _context.Users
        .Include(u => u.File)
        .Include(u => u.Artworks)
        .Where(u => u.Username != username)
        .Where(u => u.Artworks.Count() >= 5)
        .Where(u => u.Subscription.ProductId != (int)ProductEnum.Bas)
        .OrderBy(u => Guid.NewGuid())
        .Take(3)
        .Select(u =>
          new SimilarProfileDTO
          {
            Username = u.Username,
            Name = u.UserProfile.Name,
            Surname = u.UserProfile.Surname,
            ProfilePicture = u.File.Name,
            Artworks = _context.Artworks
              .Include(a => a.PrimaryFile)
              .Where(a => a.UserId == u.Id)
              .Take(5)
              .Select(a =>
                new FileDTO()
                {
                  Name = a.PrimaryFile.Name,
                  Width = a.PrimaryFile.Width,
                  Height = a.PrimaryFile.Height
                }
              )
              .ToList()
          })
        .ToList();
      }


      //Get similar artists
      var similarUsers = (from t in tagsUsedByUser
                          from a in t.Artworks
                          where a.User.Username != username

                          select a.User.Username).Distinct();

      return _context.Users
        .Include(u => u.File)
        .Include(u => u.Artworks)
        .Where(u => similarUsers.Contains(u.Username))
        .Where(u => u.Artworks.Count() >= 5)
        .Where(u => u.Subscription.ProductId != (int)ProductEnum.Bas)
        .OrderBy(u => Guid.NewGuid())
        .Take(3)
        .Select(u =>
          new SimilarProfileDTO
          {
            Username = u.Username,
            Name = u.UserProfile.Name,
            Surname = u.UserProfile.Surname,
            ProfilePicture = u.File.Name,
            Artworks = _context.Artworks
              .Include(a => a.PrimaryFile)
              .Where(a => a.UserId == u.Id)
              .Take(5)
              .Select(a =>
                new FileDTO()
                {
                  Name = a.PrimaryFile.Name,
                  Width = a.PrimaryFile.Width,
                  Height = a.PrimaryFile.Height
                }
              )
              .ToList()
          })
        .ToList();
    }

    public List<TagDTO> GetTags(string username)
    {
      return _context.Tags
        .Where(t => t.Artworks.Any(a => a.User.Username == username))
        .Select(t => new TagDTO { Tag = t.Title })
        .ToList();
    }

    public string GetProfilePicture(string username)
    {
      var user = _context.Users
        .Include(u => u.File)
        .SingleOrDefault(u => u.Username == username);

      return user?.File?.Name;
    }

    public void UpdateProfilePicture(string filename, string username)
    {
      var user = _context.Users
        .Include(u => u.File)
        .SingleOrDefault(u => u.Username == username);

      if (user.File != null)
      {
        // TODO: delete old file ref
      }

      var file = _context.Files
        .SingleOrDefault(f => f.Name == filename);

      user.File = file;
      _context.SaveChanges();
    }

    public void UpdateCoverPhoto(string filename, string username)
    {
      var user = _context.Users
        .Include(u => u.CoverPhotoFile)
        .SingleOrDefault(u => u.Username == username);

      if (user.CoverPhotoFile != null)
      {
        // TODO: delete old file ref
      }

      var file = _context.Files
        .SingleOrDefault(f => f.Name == filename);

      user.CoverPhotoFile = file;
      _context.SaveChanges();
    }

   public bool SetHideLikedArtworks(string username, bool hideLikedArtworks)
    {
        var userProfile = _context.UserProfiles
            .Include(up => up.User)
            .FirstOrDefault(up => up.User.Username == username);

        if (userProfile != null)
        {
            userProfile.HideLikedArtworks = hideLikedArtworks;
            _context.SaveChanges();
            return true; 
        }

        return false; 
    }




    public bool UserExists(UserDTO user)
    {
      return _context.Users.Any(u => u.Username == user.Username || u.Email == user.Email);
    }

    public bool UsernameExists(string username)
    {
      return _context.Users.Any(u => u.Username == username);
    }

    public bool EmailExists(string email)
    {
      return _context.Users.Any(u => u.Email == email);
    }

    public string GetUsername(Guid socialId)
    {
      return _context.Users.FirstOrDefault(u => u.SocialId == socialId)?.Username;
    }

    public string CreateUser(UserDTO user)
    {
      var subscriptionDb = new Entities.Models.Subscription
      {
        ProductId = (int)ProductEnum.Bas,
        CustomerId = null,
        ExpirationDate = null
      };

      var userDb = new User
      {
        Subscription = subscriptionDb,
        SocialId = Guid.NewGuid(),
        Username = user.Username,
        Email = user.Email,
        Created = DateTime.Now,
        Language = "en",
        PhoneNumber = user.PhoneNumber

      };

      var profileDb = new UserProfile
      {
        Name = user.Name,
        Surname = user.Surname,
        DateOfBirth = user.DateOfBirth,
        Location = user.Location,
        User = userDb
      };
      _context.UserProfiles.Add(profileDb);

      _context.SaveChanges();

      return user.Username;
    }
    public TinyUserDTO Login(string email)
    {
      return _context.Users
        .Where(u => u.Email == email)
        .Select(u => new TinyUserDTO()
        {
          Username = u.Username,
          ProfilePicture = u.File != null ? u.File.Name : null,
          Product = u.Subscription != null ? u.Subscription.ProductId : 1,
          SocialId = u.SocialId
        })
        .FirstOrDefault();
    }

    public bool UpdateIsMonthlyArtist(string username, bool isMonthlyArtist)
    {

        var user = _context.Users.SingleOrDefault(u => u.Username == username);


        if (user == null)
        {
            return false;
        }

        user.MonthlyUser = isMonthlyArtist;


        _context.SaveChanges();


        return true;
    }


    private void setSafely<T>(T value, Action<T> setAction)
    {
      if (value != null)
      {
        setAction(value);
      }
    }
  }
}