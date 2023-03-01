using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float spawnTime = 0.8f;
    public GameObject monsterPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("createEnemy", 0.6f, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("fighter") && IsInvoking("createEnemy"))
        {
            CancelInvoke();
            GameObject main = GameObject.Find("Game");
            MyGame myGame = main.GetComponent<MyGame>();
            myGame.ShowGameOverPanel();
        }
        }
    void createEnemy()
    {
        float x = Random.Range(-8, 8);
        float y = 6;
        GameObject monster = Instantiate(monsterPrefab);
        monster.transform.position = new Vector3(x, y, 0);
    }
}
