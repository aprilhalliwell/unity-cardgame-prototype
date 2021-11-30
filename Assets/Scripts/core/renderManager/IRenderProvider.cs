using System.Collections.Generic;
using Assets.Data;
using core.Data.elements;

namespace core.renderManager
{
    public interface IRenderProvider
    {
        void GetCards(Dictionary<ElementComposition, VisibilityConfig> cards);
    }
}