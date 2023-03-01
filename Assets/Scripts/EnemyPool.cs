using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyList = new List<GameObject>();
    int PoolIndex;
    public static EnemyPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetPoolObject()
    {

      PoolIndex %= enemyList.Count;

        return enemyList[PoolIndex++];
    }
}

