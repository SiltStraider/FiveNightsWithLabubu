using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float waitTime;

    private int _currentPointIndex;
    private List<Transform> _movePoints = new List<Transform>();

    public event Action OnMovementCompleteEvent;

    public void StartMovement(Transform movePoints)
    {
        if (movePoints == null)
        {
            Debug.LogError("No movePoints found");
            return;
        }
        InitializationPoints(movePoints);
        _currentPointIndex = 0;
        
        StartCoroutine(MoveRoutine());
        
    }
    
    private IEnumerator MoveRoutine()
    {
        while (_currentPointIndex < _movePoints.Count)
        {
            yield return new WaitForSeconds(waitTime);
            transform.position = _movePoints[_currentPointIndex].position;
            transform.rotation = _movePoints[_currentPointIndex].rotation;
            _currentPointIndex++;
        }
        
        OnMovementCompleteEvent?.Invoke();
    }
    
    private void InitializationPoints(Transform movePoints)
    {
        for (int i = 0; i < movePoints.childCount; i++)
            _movePoints.Add(movePoints.GetChild(i));
    }
    
    
}
