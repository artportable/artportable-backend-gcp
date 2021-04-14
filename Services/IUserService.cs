using System;
using System.Collections.Generic;
using Artportable.API.DTOs;

namespace Artportable.API.Services
{
  public interface IUserService
  {
    UserDTO Get(string username);
    ProfileSummaryDTO GetProfileSummary(string username);
    ProfileDTO GetProfile(string username, string myUsername);
    ProfileDTO UpdateProfile(string username, UpdateProfileDTO updatedProfile);
    List<SimilarProfileDTO> GetSimilarProfiles(string username);
    List<TagDTO> GetTags(string username);
    bool UserExists(Guid id);
    bool UserExists(UserDTO user);
    bool UsernameExists(string username);
    bool EmailExists(string email);
    Guid CreateUser(UserDTO user);
    Guid? Login(string email);
  }
}
