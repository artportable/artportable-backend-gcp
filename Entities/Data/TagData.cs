using Artportable.API.Entities.Models;

namespace Artportable.API.SeedData
{
  public class TagData
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
      "aquarelle",
      "mixed-media",
      "ceramic",
      "pencil",
      "charcoal",
      "clay",
      "glass",
      "textile",
      "gouache",
      "ink",

      "impressionism",
      "abstract",
      "realism",
      "surrealism",
      "expressionism",
      "cubism",
      "pop-art",
      "documentary-photography",
      "photorealism",
      "abstract-expressionism",
      "graffiti",
      "portraiture",
      "arts-craft",
      "conceptual",
      "street-art",

      "still-life",
      "landscape",
      "pastel",
      "animal",
      "collage",
      "drawing",
      "architecture",
      "nature",
      "fashion",
      "geometric",
      "flowers",
      "fantasy",
      "pattern",
      "celebrity",
      "pop-culture",
      "minimalism",
      "figurative",
      "places",
      "politics",
      "water",
      "big-city",
      "seasons",
      "cats",
      "dogs",
      "nude",
      "travel",
      "food-drink",
      "seascape",

      "photography",
      "sculpture",
      "digital",
      "illustration",
      "video-art",
      "performance-art",
      "triptych",
      "installation",
      "mural",

      "art-exhibition",
      "gallery",
      "group-exhibition",
      "posters",
      "artwork",
      "print",
      "jewelry",
      "graphic",
    };
  }
}
