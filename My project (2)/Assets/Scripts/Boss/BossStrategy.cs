using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStrategy : MonoBehaviour
{
    private IEnemyStrategy currentStrategy;

    public Transform playerTransform;
    public Enemy enemy;

    public float someFloatParameter = 0f; 

    private void Awake()
    {
        if (playerTransform == null)
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        ChangeToNextStrategy();
    }

    public void Start()
    {
        enemy.SetStrategy(currentStrategy);
    }

    public void ChangeToNextStrategy()
    {
        currentStrategy = GetRandomBehavior();
    }

    private void Update()
    {
        if (currentStrategy != null && playerTransform != null)
            currentStrategy.Execute(transform, playerTransform, someFloatParameter);
    }

    private IEnemyStrategy GetRandomBehavior()
    {
        int index = Random.Range(0, 4);
        return index switch
        {
            0 => new RushStrategy(),
            1 => new ChaseStrategy(),
            2 => new ZigZagStrategy(),
            3 => new CircleStrategy(),
            _ => new CircleStrategy()
        };
    }
}
