using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CanvasFaceToCamera : MonoBehaviour
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
        _direction = (base.transform.position - mainCamera.transform.position).normalized;
        transform.forward = new Vector3(_direction.x, 0, _direction.z);
    }
}
