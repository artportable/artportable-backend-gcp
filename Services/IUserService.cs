using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IUserService
  {
    UserDTO Get(string username);
    List<TinyUserDTO> Search(string q);
    ProfileSummaryDTO GetProfileSummary(string username);
    ProfileDTO GetProfile(string username, string myUsername);
    ProfileDTO UpdateProfile(string username, UpdateProfileDTO updatedProfile);
    List<SimilarProfileDTO> GetSimilarProfiles(string username);
    List<TagDTO> GetTags(string username);
    string GetProfilePicture(string username);
    void UpdateProfilePicture(string filename, string username);
    void UpdateCoverPhoto(string filename, string username);
    bool UserExists(UserDTO user);
    bool UsernameExists(string username);
    bool EmailExists(string email);
    string CreateUser(UserDTO user);
    TinyUserDTO Login(string email);
    IEnumerable<TinyUserDTO> GetFollowers(string username);
    IEnumerable<TinyUserDTO> GetFollowing(string username);
  }
}
