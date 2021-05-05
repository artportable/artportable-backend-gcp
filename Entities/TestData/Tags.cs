using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    private Tag[] getTags() {
      var tags = new Tag[TagList.Length];

      for (int i = 0; i < TagList.Length; i++) {
        tags[i] = new Tag() {
          Id = i+1,
          Title = TagList[i]
        };
      }

      return tags;
    }

    public Tag[] Tags
    {
      get => getTags();
    }

    private string[] TagList = {
      "oil",
      "acrylic",
      "forest",
      "self-portrait",
      "sea",
      "fruit",
      "animal",
      "landscape",
      "mountains",
      "modern",
      "classic",
      "art-noveau",
      "cubism",
      "contemporary",
      "abstract",
      "colors",
      "sky",
      "horse",
      "summer",
      "spring",
      "winter",
      "historical",
      "photography",
      "watercolor",
      "gouache",
      "encaustic",
      "pastel"
    };
  }
}
