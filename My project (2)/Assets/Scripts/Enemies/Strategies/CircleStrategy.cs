using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleStrategy : MonoBehaviour, IEnemyStrategy
{
    [SerializeField] private float amplitude = 2f;
    [SerializeField] private float frequency = 1f;

    public void Execute(Transform enemy, Transform target, float speed)
    {
        if (target == null) return;

        float offsetZ = Mathf.Sin(Time.time * frequency) * amplitude;

        Vector3 newPosition = new Vector3(enemy.position.x, enemy.position.y, target.position.z + offsetZ);
        enemy.position = Vector3.MoveTowards(enemy.position, newPosition, speed * Time.deltaTime);
    }
}