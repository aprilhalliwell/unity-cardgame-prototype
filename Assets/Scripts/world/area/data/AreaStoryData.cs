using System.Collections.Generic;
using Assets.Data;

namespace area.data
{
  public class AreaStoryData : VersionedDataElement
  {
    public Dictionary<string,string> stories = new Dictionary<string, string>();

    public AreaStoryData(Dictionary<string,string> stories)
    {
      this.stories = stories;
    }

    public string GetStory(string key)
    {
      return stories[key];
    }
    public override DataElement Clone()
    {
      return new AreaStoryData(stories);
    }
  }
}