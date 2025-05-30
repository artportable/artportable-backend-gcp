﻿using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IUserService
  {
    List<UserDTO> GetAllArtists(); 
    UserDTO Get(string username);
    public string GetCustomerIdByUsername(string username);
    List<TinyUserDTO> Search(string q);
    ProfileSummaryDTO GetProfileSummary(string username);
    ProfileDTO GetProfile(string username, string myUsername);
    ProfileDTO UpdateProfile(string username, UpdateProfileDTO updatedProfile);
    bool SetHideLikedArtworks(string username, bool hideLikedArtworks);
    List<SimilarProfileDTO> GetSimilarProfiles(string username);
    List<TagDTO> GetTags(string username);
    string GetProfilePicture(string username);
    void UpdateProfilePicture(string filename, string username);
    void UpdateCoverPhoto(string filename, string username);
    bool UserExists(UserDTO user);
    bool UsernameExists(string username);
    bool EmailExists(string email);
    string GetUsername(Guid socialId);
    string CreateUser(UserDTO user);
    TinyUserDTO Login(string email);
    public ConnectionsCountDTO GetConnectionsCount(string username);
    IEnumerable<TinyUserDTO> GetFollowers(string username);
    IEnumerable<TinyUserDTO> GetFollowees(string username);

    bool UpdateIsMonthlyArtist(string username, bool isMonthlyArtist);
  }
}
