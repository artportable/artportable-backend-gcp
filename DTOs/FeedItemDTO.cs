using System;
using Artportable.API.Enums;

namespace Artportable.API.DTOs
{
  public class FeedItemDTO<T>
  {
    public FeedItemType Type { get; set; }
    public string User { get; set; }
    public string Location { get; set; }
    public DateTime Published { get; set; }
    public T Item { get; set; }
  }
}
