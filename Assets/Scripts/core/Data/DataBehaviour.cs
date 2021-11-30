using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Data
{
  /// <summary>
  /// Monobehaviour that exposes compositional data.
  /// </summary>
  abstract public class DataBehaviour : MonoBehaviour
  {
    /// <summary>
    /// Our parent data
    /// </summary>
    public IHasData data;
    /// <summary>
    /// Whether we have been initialized
    /// </summary>
    bool initialized = false;

    /// <summary>
    /// Unity API
    /// Occurrs before initialized
    /// Calls abstract awake
    /// </summary>
    void Awake()
    {
      awake();
    }
    /// <summary>
    /// Called before initialization occurs.
    /// </summary>
    protected virtual void awake(){}

    /// <summary>
    /// Unity API
    /// Waits until data is found within parent objects and then initalizes data
    /// </summary>
    /// <returns></returns>
    IEnumerator Start()
    {
      //waits until our data is found from its parent objects 
      data = GetComponentInParent<IHasData>();
      while (data == null)
      {
        yield return null;
        data = GetComponentInParent<IHasData>();
      }
      while (data != null && data.Composition == null)
      {
        yield return null;
      }
      initialized = true;
      start();
    }

    /// <summary>
    /// Called after our data has been assigned, you can saftly get compositonal data.
    /// </summary>
    protected virtual void start(){}

    /// <summary>
    /// Unity API
    /// Waits till initialized before calling abstract update
    /// </summary>
    void Update()
    {
      if (initialized)
      {
        update();
      }
    }

    /// <summary>
    /// Called after our data has been assigned, you can saftly get compositonal data.
    /// </summary>
    protected virtual void update(){}

    /// <summary>
    /// Unity API
    /// Waits till initialized before calling abstract fixedUpdate
    /// </summary>
    void FixedUpdate()
    {
      if (initialized)
      {
        fixedUpdate();
      }
    }
    /// <summary>
    /// Called after our data has been assigned, you can saftly get compositonal data.
    /// </summary>
    protected virtual void fixedUpdate() { }
  }
}
