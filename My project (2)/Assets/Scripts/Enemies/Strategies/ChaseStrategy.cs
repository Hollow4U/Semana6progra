using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStrategy : MonoBehaviour, IEnemyStrategy
{
    public void Execute(Transform enemyTransform, Transform playerTransform, float moveSpeed)
    {
        if (playerTransform == null) return;

        Vector3 direction = (playerTransform.position - enemyTransform.position).normalized;
        enemyTransform.position += direction * moveSpeed * Time.deltaTime;
    }
}
