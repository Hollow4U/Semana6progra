using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagStrategy : MonoBehaviour, IEnemyStrategy
{
    private float amplitude = 2f;   
    private float frequency = 2f;  

    public void Execute(Transform enemy, Transform target, float speed)
    {
        if (enemy == null) return;

        enemy.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        Vector3 position = enemy.position;
        position.x = Mathf.Sin(Time.time * frequency) * amplitude;
        enemy.position = position;
    }
}
