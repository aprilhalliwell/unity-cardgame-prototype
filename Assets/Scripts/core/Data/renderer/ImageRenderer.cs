using Assets.Data;
using core.Data.elements;
using UnityEngine.UI;

namespace area.rendering
{
  public class ImageRenderer: VersionedDataBehaviour<ImageData>
  {
    private Image image;
    protected override void awake()
    {
      image = GetComponent<Image>();
    }

    protected override void dirtyUpdate()
    {
      image.sprite = component.Image;
    }
  }
}