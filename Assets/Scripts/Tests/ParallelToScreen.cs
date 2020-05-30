using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ParallelToScreen : MonoBehaviour
{
    public Camera mainCamera;

    private Vector3 _direction;
    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }
    private void Update()
    {
        transform.forward = mainCamera.transform.forward;
    }
}
