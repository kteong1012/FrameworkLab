using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewBase : MonoBehaviour
{
    public static T CreateView<T>(GameObject prefab) where T : ViewBase
    {
        GameObject gob = GameObject.Instantiate(prefab);
        T ret = gob.GetComponent<T>();
        if (ret == null)
        {
            return null;
        }
        return ret;
    }
    protected ControllerBase _controller;
    public ControllerBase Controller { get => _controller; set => _controller = value; }
}
