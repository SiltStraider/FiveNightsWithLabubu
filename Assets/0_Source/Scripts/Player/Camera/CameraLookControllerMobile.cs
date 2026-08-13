using System;
using UnityEngine;

public class CameraLookControllerMobile : MonoBehaviour
{
    [SerializeField] private float sensitivity = 1.5f;
    [SerializeField] private float maxAngle = 15;

    private float _currentY;
    private Vector2 _lastPosition;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
            _lastPosition = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            Vector2 delta = (Vector2)Input.mousePosition - _lastPosition;
            _currentY -= delta.x * sensitivity *  Time.deltaTime;
            _lastPosition = Input.mousePosition;
        }
        
        _currentY = Mathf.Clamp(_currentY, -maxAngle, maxAngle);
        transform.localRotation = Quaternion.Euler(0, _currentY, 0);
    }
}