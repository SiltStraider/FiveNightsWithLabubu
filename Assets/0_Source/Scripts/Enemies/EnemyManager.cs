using System.Collections;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyConfig[] enemies;

    private void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            StartCoroutine(StartEnemyWithDelay(enemies[i]));
        }
    }

    private IEnumerator StartEnemyWithDelay(EnemyConfig enemyConfig)
    {
        yield return new WaitForSeconds(enemyConfig.DelayBeforeStart);
        enemyConfig.Enemy.StartMovement(enemyConfig.MovementPoints);

        if (enemyConfig.Enemy.TryGetComponent(out EnemyScreamer screamer))
            screamer.SetInteractObject(enemyConfig.InteractObject);
        
    }
    
    [System.Serializable]

    private class EnemyConfig
    {
        public EnemyMove Enemy;
        public Transform MovementPoints;
        public InteractObject InteractObject;
        public float DelayBeforeStart = 3;
    }
}
