using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyGameObject : MonoBehaviour
{
    public GameObject copySourceGameObject;
    public Transform parent;
    public void Copy()
    {
        if (copySourceGameObject == null)
        {
            return;
        }
        GameObject newGameObject = Instantiate(copySourceGameObject, parent);
    }
}
