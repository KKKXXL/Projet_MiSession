using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public string target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(target))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

            GameObject main = GameObject.Find("Game");
            MyGame myGame = main.GetComponent<MyGame>();
            myGame.addScore(1);
        }
    }
}
