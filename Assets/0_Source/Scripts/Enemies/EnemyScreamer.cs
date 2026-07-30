using System;
using System.Collections;
using UnityEngine;

public class EnemyScreamer : MonoBehaviour
{
    [SerializeField] private float delay;
    [SerializeField] private EnemyMove enemyMove;
    [SerializeField] private GameObject panelWin;
    
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
        
        // Проверяем: активна ли панель победы ИЛИ активен ли интерактивный объект
        bool isWinPanelActive = panelWin != null && panelWin.activeSelf;
        bool isInteractObjectActive = _interactObject != null && _interactObject.IsActive;
        
        if (isWinPanelActive || isInteractObjectActive)
        {
            enemyMove.ReturnToStartPointAndMove();
            yield break;
        }
        
        _animator.SetTrigger(_animationAttack);
        ScreamEvent?.Invoke(gameObject);
    }

    public void SetInteractObject(InteractObject interactObject)
    {
        _interactObject = interactObject;
    }
}
