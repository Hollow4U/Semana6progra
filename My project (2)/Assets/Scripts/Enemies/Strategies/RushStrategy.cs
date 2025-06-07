using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushStrategy : MonoBehaviour, IEnemyStrategy
{
    private float timer;
    private bool rushing = true;

    public void Execute(Transform enemyTransform, Transform playerTransform, float moveSpeed)
    {
        if (playerTransform == null) return;

        timer += Time.deltaTime;

        float speedMultiplier = rushing ? 1.5f : -0.5f;
        Vector3 direction = (playerTransform.position - enemyTransform.position).normalized;

        enemyTransform.position += direction * moveSpeed * speedMultiplier * Time.deltaTime;

        if (timer >= 2f)
        {
            rushing = !rushing;
            timer = 0f;
        }
    }
}
