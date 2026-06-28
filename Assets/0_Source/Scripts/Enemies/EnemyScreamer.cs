using System;
using System.Collections;
using UnityEngine;

public class EnemyScreamer : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private EnemyMove enemyMove;
    
    
    private InteractObject _interactObject;
    public static Action<GameObject> ScreamEvent;

    private void OnEnable()
    {
        if (enemyMove)
            enemyMove.OnMovementCompleteEvent += StartScream;
    }

    private void OnDisable()
    {
        if (enemyMove)
            enemyMove.OnMovementCompleteEvent -= StartScream;
    }

    public void StartScream()
    {
        StartCoroutine(DelayScream());
    }

    private IEnumerator DelayScream()
    {
        yield return new WaitForSeconds(delay);
        if (_interactObject)
        {
            if (_interactObject.IsActive)       
                yield break;
        }
        
        ScreamEvent?.Invoke(gameObject);
    }

    public void SetInteractObject(InteractObject interactObject)
    {
        _interactObject = interactObject;
    }
}
