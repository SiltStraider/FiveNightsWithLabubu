using System;
using System.Collections;
using UnityEngine;

public class EnemyScreamer : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private EnemyMove enemyMove;
    
    private Animator _animator;
    private string _animationAttack = "Attack";
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
        _animator = GetComponentInChildren<Animator>();
        StartCoroutine(DelayScream());
    }

    private IEnumerator DelayScream()
    {
        yield return new WaitForSeconds(delay);
        if (_interactObject)
        {
            if (_interactObject.IsActive)
            {
                enemyMove.ReturnToStartPointAndMove();
                yield break;
            }       
        }
        
        _animator.SetTrigger(_animationAttack);
        ScreamEvent?.Invoke(gameObject);
    }

    public void SetInteractObject(InteractObject interactObject)
    {
        _interactObject = interactObject;
    }
}
