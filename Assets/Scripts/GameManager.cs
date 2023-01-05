using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform pool;
    public Transform parentEnemy;
    public LaserController templateBullet;
    public static Transform Pool;
    public MoveObject prefabEnemy;

    private void Awake()
    {
        Pool = pool;
        LaserController.Enqueue(1, templateBullet);
        SpawnEnemy();
    }
    void SpawnEnemy()
    {
        for (int i = 0; i < 12; i++)
        {
            MoveObject enemy = Instantiate(prefabEnemy, parentEnemy);
            enemy.indexEnemy = i;
        }
        
    }
}