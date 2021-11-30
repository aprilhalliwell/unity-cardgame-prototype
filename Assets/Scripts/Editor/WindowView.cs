using Assets.MapPainter.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Editor
{
  abstract class WindowView
  {
    public void RenderView()
    {
      ResetData();
      Render();

    }
    protected virtual void ResetData()
    {
    }

    protected abstract void Render();
  }
}
