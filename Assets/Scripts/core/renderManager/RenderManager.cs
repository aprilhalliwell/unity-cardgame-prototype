using System;
using System.Collections.Generic;
using Assets.Data;
using core.Data.elements;
using core.renderManager;
using UnityEngine;

public class RenderManager : MonoBehaviour
{
    private List<IRenderProvider> _renderProviders = new List<IRenderProvider>();
    Dictionary<ElementComposition,VisibilityConfig> elements = new Dictionary<ElementComposition, VisibilityConfig>();
    public void SetData(Dictionary<ElementComposition, VisibilityConfig> elements)
    {
        this.elements = elements;
    }
    
    public void Unsubscribe(IRenderProvider provider)
    {
        _renderProviders.Remove(provider);
    }

    public void Subscribe(IRenderProvider provider)
    {
        _renderProviders.Add(provider);
    }

    private void Update()
    {
        foreach (var renderProvider in _renderProviders)
        {
            renderProvider.GetCards(elements);
        }
    }
}